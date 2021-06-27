using AutoMapper;
using LeaveManagement.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveTypeRepository _leaveTypesRepo;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;

        // GET: LeaveAllocationController
        public LeaveAllocationController(ILeaveTypeRepository leaveTypesRepo,
            ILeaveAllocationRepository leaveAllocationRepo, IMapper mapper, UserManager<Employee> userManager)
        {
            _leaveTypesRepo = leaveTypesRepo;
            _leaveAllocationRepo = leaveAllocationRepo;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var leavetypes = await _leaveTypesRepo.FindAll();
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes.ToList());
            var model = new CreateLeaveAllocationVM
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };
            return View(model);
        }

        public async Task<ActionResult> SetLeave(int id)
        {
            var leaveType = await _leaveTypesRepo.FindById(id);
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            foreach (var emp in employees)
            {
                if (await _leaveAllocationRepo.CheckAllocation(id, emp.Id))
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
                await _leaveAllocationRepo.Create(leaveAllocation);
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
            var allocations = _mapper.Map<List<LeaveAllocationVM>>(await _leaveAllocationRepo.GetLeaveAllocationsByEmployeeId(id));
            var model = new ViewLeaveAllocationsVM
            {
                Employee = employee,
                LeaveAllocations = allocations
            };
            return View(model);
        }

        // GET: LeaveAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
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

        // GET: LeaveAllocationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = _mapper.Map<EditLeaveAllocationVM>(await _leaveAllocationRepo.FindById(id));
            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
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
                var record = await _leaveAllocationRepo.FindById(model.Id);
                record.NumberOfDays = model.NumberOfDays;
                
                var isSuccess = await _leaveAllocationRepo.Update(record);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong!!");
                    return View(model);
                }

                return RedirectToAction(nameof(Details), new { id = model.EmployeeId });

            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong!!");
                return View(model);
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
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
    }
}
