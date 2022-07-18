using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreAndFood.Controllers
{
    
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context db = new Context();
        public IActionResult Index()
        {
            return View(foodRepository.TList("Category"));
        }

        public IActionResult FAdd()
        {
            List<SelectListItem> val = (from i in db.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.Id.ToString()
                                        }).ToList();
            ViewBag.vls = val;
            return View();
        }

        [HttpPost]
        public IActionResult FAdd(addProduct p)
        {
            Food f = new Food();
            if (p.ImageUrl!=null)
            {
                var extension = Path.GetExtension(p.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"/image",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                f.ImageUrl=newimagename;
                
            }
            f.Name = p.Name;
            f.Price = p.Price;
            f.Stock = p.Stock;
            f.CategoryId = p.CategoryId;
            f.Description = p.Description;
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Food p)
        {
            foodRepository.TDelete(p);
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(short id)
        {
            List<SelectListItem> val = (from i in db.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.Id.ToString()
                                        }).ToList();
            ViewBag.vls = val;
            var m = foodRepository.TGet(id);
            Food fd = new Food()
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Stock = m.Stock,
                Price = m.Price,
                CategoryId = m.CategoryId
            };
            return View(fd);
        }

        [HttpPost]
        public IActionResult Update(Food p)
        {
            var m = foodRepository.TGet(p.Id);
            m.Name = p.Name;
            m.Description = p.Description;
            m.Stock = p.Stock;
            m.Price = p.Price;
            m.CategoryId = p.CategoryId;
            foodRepository.TUpdate(m);
            return RedirectToAction("Index");
        }

    }
}