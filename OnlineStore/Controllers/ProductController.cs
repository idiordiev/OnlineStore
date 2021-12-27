using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        
        public ProductController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _webHostEnvironment = environment;
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
            return View();
        }
        
        /// <summary>
        /// A POST request for "/product/create".
        /// </summary>
        /// <param name="model">A viewmodel with product's data.</param>
        /// <returns>If model is valid, redirects to "/product/". Otherwise, returns the same page.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductAddViewModel model)
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
                {
                    string path = "/img/" + model.Image.FileName;

                    using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }

                    product.ImageLink = path;
                }
                else
                {
                    product.ImageLink = String.Empty;
                }

                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// A GET request for "/product/edit/id".
        /// </summary>
        /// <param name="id">Product's ID.</param>
        /// <returns>Returns a view with form (inputs might be filled).</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _db.Products.FindAsync(id);

            ProductEditViewModel model = new ProductEditViewModel()
            {
                Id = product.Id,
                NameUA = product.NameUA,
                NameRU = product.NameRU,
                NameEN = product.NameEN,
                Price = product.Price,
                CategoryId = product.CategoryId,
                DescriptionShortUA = product.DescriptionShortUA,
                DescriptionShortRU = product.DescriptionShortRU,
                DescriptionShortEN = product.DescriptionShortEN,
                DescriptionFullUA = product.DescriptionFullUA,
                DescriptionFullRU = product.DescriptionFullRU,
                DescriptionFullEN = product.DescriptionFullEN,
                ImageLink = product.ImageLink
            };
            
            return View(model);
        }

        /// <summary>
        /// A POST request for "/product/edit/id".
        /// </summary>
        /// <param name="model">A product's viewmodel with data.</param>
        /// <returns>If model is valid, redirects to "/product/". Otherwise, returns the same page.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
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
                    {
                        string path = "/img/" + model.Image.FileName;

                        using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await model.Image.CopyToAsync(fileStream);
                        }

                        product.ImageLink = path;
                    }
                    
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