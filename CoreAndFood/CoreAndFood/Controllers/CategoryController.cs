using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(categoryRepository.List(m=>m.Name==p));
            }
            
            return View(categoryRepository.TList());
        }

        public IActionResult CatAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CatAdd(Category p)
        {
            categoryRepository.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Category p)
        {
            categoryRepository.TDelete(p);
            return RedirectToAction("Index");
        }

        public IActionResult CatGet(short id)
        {
            var catget = categoryRepository.TGet(id);
            Category cat = new Category()
            {
                Name=catget.Name,
                Id=catget.Id

            };
            return View(cat);
        }

        [HttpPost]
        public IActionResult Update(Category p)
        {
            var m = categoryRepository.TGet(p.Id);
            m.Name = p.Name;
            categoryRepository.TUpdate(m);
            return RedirectToAction("Index");
        }

    }
}