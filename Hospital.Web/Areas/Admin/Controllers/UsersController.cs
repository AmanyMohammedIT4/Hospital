﻿using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private IApplicationUserService _userService;

        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int pageNumber=1,int pageSize=10)
        {
            return View(_userService.GetAll(pageNumber,pageSize));
        }
        public IActionResult AllDoctors(int pageNumber = 1, int pageSize = 10)
        {
            return View(_userService.GetAllDoctor(pageNumber, pageSize));
        }
    }
}
