using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAndFood.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();

        public IActionResult Index()
        {
            var getFoodList = foodRepository.TList();
            return View(getFoodList);
        }

        public IActionResult CategoryDetails(int id)
        {
            ViewBag.m = id;
            return View();
        }

    }
}
