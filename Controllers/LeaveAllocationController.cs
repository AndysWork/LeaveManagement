using AutoMapper;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;

        public LeaveAllocationController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<Employee> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _unitOfWork.LeaveTypes.FindAll();
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveTypes.ToList());
            var model = new CreateLeaveAllocationVM
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };
            return View(model);
        }

        public async Task<ActionResult> SetLeave(int id)
        {
            var leaveType = await _unitOfWork.LeaveTypes.Find(q => q.Id == id);
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            foreach (var emp in employees)
            {
                if (await _unitOfWork.LeaveAllocations.isExists(q => q.Id == id && q.EmployeeId == emp.Id && q.Period == DateTime.Now.Year))
                    continue;
                var allocation = new LeaveAllocationVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };
                var leaveAllocation = _mapper.Map<LeaveAllocation>(allocation);
                await _unitOfWork.LeaveAllocations.Create(leaveAllocation);
                await _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> ListEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            var model = _mapper.Map<List<EmployeeVM>>(employees);
            return View(model);
        }

        // GET: LeaveAllocationController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(id));
            var records = await _unitOfWork.LeaveAllocations.FindAll(expression: q => q.EmployeeId == id && q.Period == DateTime.Now.Year,
                includes: q => q.Include(x => x.LeaveType));

            var allocations = _mapper.Map<List<LeaveAllocationVM>>(records);

            var model = new ViewLeaveAllocationsVM
            {
                Employee = employee,
                LeaveAllocations = allocations
            };
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        public async Task<ActionResult> Edit(int id)
        {
            var model = _mapper.Map<EditLeaveAllocationVM>(await _unitOfWork.LeaveAllocations.Find(q => q.Id == id,
                includes: q => q.Include(x => x.Employee)
                               .Include(x => x.LeaveType)));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditLeaveAllocationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var record = await _unitOfWork.LeaveAllocations.Find(q => q.Id == model.Id);
                record.NumberOfDays = model.NumberOfDays;

                _unitOfWork.LeaveAllocations.Update(record);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Details), new { id = model.EmployeeId });

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong!!");
                return View(model);
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
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
