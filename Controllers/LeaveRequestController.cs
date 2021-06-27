using AutoMapper;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ILeaveRequestRepository _leaveRequestRepo;
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;

        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepo, ILeaveTypeRepository leaveTypeRepo,
            ILeaveAllocationRepository leaveAllocationRepo,
            IMapper mapper, UserManager<Employee> userManager)
        {
            _leaveRequestRepo = leaveRequestRepo;
            _leaveTypeRepo = leaveTypeRepo;
            _leaveAllocationRepo = leaveAllocationRepo;
            _userManager = userManager;
            _mapper = mapper;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var leaveRequests = await _leaveRequestRepo.FindAll();
            var leaveRequestsModel = _mapper.Map<List<LeaveRequestVM>>(leaveRequests);
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequestsModel.Count(q => q.Cancelled != true),
                ApprovedRequests = leaveRequestsModel.Count(q => q.Approved == true && q.Cancelled != true),
                PendingRequests = leaveRequestsModel.Count(q => q.Approved == null && q.Cancelled != true),
                RejectedRequests = leaveRequestsModel.Count(q => q.Approved == false && q.Cancelled != true),
                LeaveRequests = leaveRequestsModel
            };
            return View(model);
        }

        // GET: LeaveRequestController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveRequest = await _leaveRequestRepo.FindById(id);
            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            return View(model);
        }

        // GET: LeaveRequestController/Create
        public async Task<ActionResult> Create()
        {
            var leaveTypes = await _leaveTypeRepo.FindAll();
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

        // POST: LeaveRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveRequestVM model)
        {
            try
            {
                var startdate = DateTime.ParseExact(model.StartDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(model.EndDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                var leaveTypes = await _leaveTypeRepo.FindAll();
                var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                model.LeaveTypes = leaveTypeItems;
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                if (DateTime.Compare(startdate, enddate) > 1)
                {
                    ModelState.AddModelError("", "Start Date cannot be further in the future than the End Date");
                }
                var employee = await _userManager.GetUserAsync(User);
                var allocation = await _leaveAllocationRepo.GetLeaveAllocationsByEmployeeAndType(employee.Id, model.LeaveTypeId);
                int daysRequested = (int)(enddate - startdate).TotalDays;
                if (daysRequested > allocation.NumberOfDays)
                {
                    ModelState.AddModelError("", "Insufficient Leave Balance!!");
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
                var isSuccess = await _leaveRequestRepo.Create(leaveRequest);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong!!");
                    return View(model);
                }

                return RedirectToAction(nameof(MyLeave));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong!!");
                return View(model);
            }
        }

        // GET: LeaveRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Edit/5
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

        // GET: LeaveRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Delete/5
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
                var leaveRequest = await _leaveRequestRepo.FindById(id);
                var allocation = await _leaveAllocationRepo.GetLeaveAllocationsByEmployeeAndType(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                leaveRequest.Approved = true;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;

                await _leaveRequestRepo.Update(leaveRequest);
                await _leaveAllocationRepo.Update(allocation);
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
                var leaveRequest = await _leaveRequestRepo.FindById(id);
                leaveRequest.Approved = false;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;

                var isSuccess = await _leaveRequestRepo.Update(leaveRequest);
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
            var leaveAllocations = await _leaveAllocationRepo.GetLeaveAllocationsByEmployeeId(employee.Id);
            var leaveRequests = await _leaveRequestRepo.GetLeaveRequestsByEmployeeId(employee.Id);

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
                var isLeaveAllocationRevertSuccess = true;
                var employee = await _userManager.GetUserAsync(User);
                var leaveRequest = await _leaveRequestRepo.FindById(id);
                var leaveAllocation = await _leaveAllocationRepo.GetLeaveAllocationsByEmployeeAndType(employee.Id, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

                leaveRequest.Cancelled = true;
                if (leaveRequest.Approved == true)
                {
                    leaveAllocation.NumberOfDays += daysRequested;
                    isLeaveAllocationRevertSuccess = await _leaveAllocationRepo.Update(leaveAllocation);
                }
                var isLeaveRequestCancelSuccess = await _leaveRequestRepo.Update(leaveRequest);

                if (!isLeaveAllocationRevertSuccess || !isLeaveRequestCancelSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View("MyLeave");
                }
                return RedirectToAction("MyLeave");
            }
            catch (Exception ex)
            {
                return View("MyLeave");
            }

        }
    }
}
