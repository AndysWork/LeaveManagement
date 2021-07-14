using AutoMapper;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using LeaveManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    [Authorize]
    public class LeaveRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public LeaveRequestController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<Employee> userManager, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.FindAll(
                includes: q => q.Include(x => x.RequestingEmployee)
                                .Include(x => x.LeaveType));

            var leaveRequestsModel = _mapper.Map<List<LeaveRequestVM>>(leaveRequests);
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequestsModel.Count,
                ApprovedRequests = leaveRequestsModel.Count(q => q.Approved == true),
                PendingRequests = leaveRequestsModel.Count(q => q.Approved == null),
                RejectedRequests = leaveRequestsModel.Count(q => q.Approved == false),
                LeaveRequests = leaveRequestsModel
            };
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.Find(q => q.Id == id,
                includes: q => q.Include(x => x.ApprovedBy)
                                .Include(x => x.RequestingEmployee)
                                .Include(x => x.LeaveType));
            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var leaveTypes = await _unitOfWork.LeaveTypes.FindAll();
            var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var model = new CreateLeaveRequestVM
            {
                LeaveTypes = leaveTypeItems
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveRequestVM model)
        {
            try
            {
                var startdate = DateTime.ParseExact(model.StartDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(model.EndDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                int daysRequested = (int)(enddate - startdate).TotalDays;

                var employee = await _userManager.GetUserAsync(User);
                var leaveTypes = await _unitOfWork.LeaveTypes.FindAll();
                var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });

                var allocation = await _unitOfWork.LeaveAllocations.Find(q => q.EmployeeId == employee.Id && q.LeaveTypeId == model.LeaveTypeId);

                model.LeaveTypes = leaveTypeItems;

                if (allocation == null)
                {
                    ModelState.AddModelError("", "You have no Leave Balance!!");
                }
                if (DateTime.Compare(startdate, enddate) > 1)
                {
                    ModelState.AddModelError("", "Start Date cannot be further in the future than the End Date");
                }

                if (daysRequested > allocation.NumberOfDays)
                {
                    ModelState.AddModelError("", "Insufficient Leave Balance!!");
                    return View(model);
                }
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveRequestModel = new LeaveRequestVM
                {
                    LeaveTypeId = model.LeaveTypeId,
                    RequestingEmployeeId = employee.Id,
                    StartDate = startdate,
                    EndDate = enddate,
                    Approved = null,
                    DateRequested = DateTime.Now,
                    DateActioned = DateTime.Now,
                    Cancelled = false,
                    RequestComments = model.RequestComments
                };
                var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestModel);

                await _unitOfWork.LeaveRequests.Create(leaveRequest);
                await _unitOfWork.Save();

                //Send Email to SuperVisor
                //await _emailSender.SendEmailAsync("admin@localhost.com", "Leave Request",
                //    $"Please review this leave request <a href='urlofapp/{leaveRequest.Id}'>Click Here</a>");

                return RedirectToAction(nameof(MyLeave));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong!!");
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> ApproveRequest(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var leaveRequest = await _unitOfWork.LeaveRequests.Find(q => q.Id == id);
                var allocation = await _unitOfWork.LeaveAllocations
                    .Find(q => q.EmployeeId == leaveRequest.RequestingEmployeeId && q.LeaveTypeId == leaveRequest.LeaveTypeId);

                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;
                leaveRequest.Approved = true;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;

                _unitOfWork.LeaveRequests.Update(leaveRequest);
                _unitOfWork.LeaveAllocations.Update(allocation);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<ActionResult> RejectRequest(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var leaveRequest = await _unitOfWork.LeaveRequests.Find(q => q.Id == id);
                leaveRequest.Approved = false;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;
                _unitOfWork.LeaveRequests.Update(leaveRequest);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<ActionResult> MyLeave()
        {
            var employee = await _userManager.GetUserAsync(User);
            var leaveAllocations = await _unitOfWork.LeaveAllocations.FindAll(q => q.EmployeeId == employee.Id,
                includes: q => q.Include(x => x.LeaveType));
            var leaveRequests = await _unitOfWork.LeaveRequests.FindAll(q => q.RequestingEmployeeId == employee.Id);

            var leaveAllocationsModel = _mapper.Map<List<LeaveAllocationVM>>(leaveAllocations);
            var leaveRequestsModel = _mapper.Map<List<LeaveRequestVM>>(leaveRequests);

            var model = new EmployeeLeaveRequestViewVM
            {
                LeaveAllocations = leaveAllocationsModel,
                LeaveRequests = leaveRequestsModel
            };

            return View(model);
        }
        public async Task<ActionResult> CancelRequest(int id)
        {
            try
            {
                var employee = await _userManager.GetUserAsync(User);
                var leaveRequest = await _unitOfWork.LeaveRequests.Find(q => q.Id == id);
                var leaveAllocation = await _unitOfWork.LeaveAllocations
                    .Find(q => q.EmployeeId == employee.Id && q.LeaveTypeId == leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

                leaveRequest.Cancelled = true;
                if (leaveRequest.Approved == true)
                {
                    leaveAllocation.NumberOfDays += daysRequested;
                    _unitOfWork.LeaveAllocations.Update(leaveAllocation);
                }
                _unitOfWork.LeaveRequests.Update(leaveRequest);
                await _unitOfWork.Save();

                return RedirectToAction("MyLeave");
            }
            catch (Exception ex)
            {
                return View("MyLeave");
            }

        }
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
