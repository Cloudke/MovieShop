using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieCreateRequestModel movieCreateRequest)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
