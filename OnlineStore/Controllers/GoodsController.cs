using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Localization;
using OnlineStore.Models;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    public class GoodsController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly GoodsLocalizer _goodsLocalizer;

        public GoodsController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _webHostEnvironment = environment;
            _goodsLocalizer = new GoodsLocalizer(db);
        }

        // GET
        public IActionResult Index()
        {
            var goodsList = _db.Goods.ToList();

            return View(goodsList);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(GoodsAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Goods goods = new Goods()
                {
                    Price = model.Price,
                    NameUA = model.NameUA,
                    NameRU = model.NameRU,
                    NameEN = model.NameEN,
                    DescriptionShortUA = model.DescriptionShortUA,
                    DescriptionShortRU = model.DescriptionShortRU,
                    DescriptionShortEN = model.DescriptionShortEN,
                    DescriptionFullUA = model.DescriptionFullUA,
                    DescriptionFullRU = model.DescriptionFullRU,
                    DescriptionFullEN = model.DescriptionFullEN,
                    CategoryId = model.CategoryId,
                    DateAdded = DateTime.Today
                };
                if (model.Image != null)
                {
                    string path = "/img/" + model.Image.FileName;

                    using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }

                    goods.ImageLink = path;
                }
                else
                {
                    goods.ImageLink = String.Empty;
                }

                await _db.Goods.AddAsync(goods);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var goods = _db.Goods.FindAsync(id).Result;

            GoodsEditViewModel model = new GoodsEditViewModel()
            {
                Id = goods.Id,
                NameUA = goods.NameUA,
                NameRU = goods.NameRU,
                NameEN = goods.NameEN,
                Price = goods.Price,
                CategoryId = goods.CategoryId,
                DescriptionShortUA = goods.DescriptionShortUA,
                DescriptionShortRU = goods.DescriptionShortRU,
                DescriptionShortEN = goods.DescriptionShortEN,
                DescriptionFullUA = goods.DescriptionFullUA,
                DescriptionFullRU = goods.DescriptionFullRU,
                DescriptionFullEN = goods.DescriptionFullEN,
                ImageLink = goods.ImageLink
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GoodsEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var goods = _db.Goods.FindAsync(model.Id).Result;

                if (goods != null)
                {
                    goods.NameUA = model.NameUA;
                    goods.NameRU = model.NameRU;
                    goods.NameEN = model.NameEN;
                    goods.Price = model.Price;
                    goods.CategoryId = model.CategoryId;
                    goods.DescriptionShortUA = model.DescriptionShortUA;
                    goods.DescriptionShortRU = model.DescriptionShortRU;
                    goods.DescriptionShortEN = model.DescriptionShortEN;
                    goods.DescriptionFullUA = model.DescriptionFullUA;
                    goods.DescriptionFullRU = model.DescriptionFullRU;
                    goods.DescriptionFullEN = model.DescriptionFullEN;

                    if (model.Image != null)
                    {
                        string path = "/img/" + model.Image.FileName;

                        using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await model.Image.CopyToAsync(fileStream);
                        }

                        goods.ImageLink = path;
                    }
                    
                    _db.Goods.Update(goods);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var goods = _db.Goods.FindAsync(id).Result;
            if (goods != null)
            {
                _db.Goods.Remove(goods);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}