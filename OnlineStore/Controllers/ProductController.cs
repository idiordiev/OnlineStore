using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Localization;
using OnlineStore.Models;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    /// <summary>
    /// A controller for CRUD operations for products
    /// </summary>
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryLocalizer _categoryLocalizer;
        
        public ProductController(ApplicationDbContext db, IWebHostEnvironment environment, ICategoryLocalizer categoryLocalizer)
        {
            _db = db;
            _webHostEnvironment = environment;
            _categoryLocalizer = categoryLocalizer;
        }

        /// <summary>
        /// A GET request for "/product/"
        /// </summary>
        /// <returns>Returns view with list of products. </returns>
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();

            return View(products);
        }
        
        /// <summary>
        /// A GET request for "/product/create/".
        /// </summary>
        /// <returns>Returns view with form.</returns>
        public IActionResult Create()
        {
            ProductViewModel model = new ProductViewModel()
            {
                Categories = GetCategoriesAsDropdownItems()
            };

            return View(model);
        }

        private IEnumerable<SelectListItem> GetCategoriesAsDropdownItems()
        {
            return _categoryLocalizer.Localize(_db.Categories)
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
        }

        /// <summary>
        /// A POST request for "/product/create".
        /// </summary>
        /// <param name="model">A viewmodel with product's data.</param>
        /// <returns>If model is valid, redirects to "/product/". Otherwise, returns the same page.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
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
                    product = AddImageToProduct(product, model.Image);
                else
                    product.ImageLink = string.Empty;

                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        private Product AddImageToProduct(Product product, IFormFile image)
        {
            string path = "/img/" + image.FileName;
            using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            product.ImageLink = path;
            
            return product;
        }

        /// <summary>
        /// A GET request for "/product/edit/id".
        /// </summary>
        /// <param name="id">Product's ID.</param>
        /// <returns>Returns a view with form (inputs might be filled).</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _db.Products.FindAsync(id);

            ProductViewModel model = new ProductViewModel()
            {
                Id = product.Id,
                NameUA = product.NameUA,
                NameRU = product.NameRU,
                NameEN = product.NameEN,
                Price = product.Price,
                DescriptionShortUA = product.DescriptionShortUA,
                DescriptionShortRU = product.DescriptionShortRU,
                DescriptionShortEN = product.DescriptionShortEN,
                DescriptionFullUA = product.DescriptionFullUA,
                DescriptionFullRU = product.DescriptionFullRU,
                DescriptionFullEN = product.DescriptionFullEN,
                ImageLink = product.ImageLink,
                Categories = GetCategoriesAsDropdownItems(product)
            };
            
            return View(model);
        }
        
        private IEnumerable<SelectListItem> GetCategoriesAsDropdownItems(Product product)
        {
            return _categoryLocalizer.Localize(_db.Categories).Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = c.Id == product.CategoryId
            });
        } 

        /// <summary>
        /// A POST request for "/product/edit/id".
        /// </summary>
        /// <param name="model">A product's viewmodel with data.</param>
        /// <returns>If model is valid, redirects to "/product/". Otherwise, returns the same page.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await _db.Products.FindAsync(model.Id);

                if (product != null)
                {
                    product.NameUA = model.NameUA;
                    product.NameRU = model.NameRU;
                    product.NameEN = model.NameEN;
                    product.Price = model.Price;
                    product.CategoryId = model.CategoryId;
                    product.DescriptionShortUA = model.DescriptionShortUA;
                    product.DescriptionShortRU = model.DescriptionShortRU;
                    product.DescriptionShortEN = model.DescriptionShortEN;
                    product.DescriptionFullUA = model.DescriptionFullUA;
                    product.DescriptionFullRU = model.DescriptionFullRU;
                    product.DescriptionFullEN = model.DescriptionFullEN;

                    if (model.Image != null)
                        product = AddImageToProduct(product, model.Image);

                    _db.Products.Update(product);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        /// <summary>
        /// A POST request for deleting products. Don't have view, just use form with asp-route-id.
        /// </summary>
        /// <param name="id">Product's ID.</param>
        /// <returns>Redirects to "/product".</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _db.Products.FindAsync(id).Result;
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}