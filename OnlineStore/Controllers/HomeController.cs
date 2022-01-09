﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.Localization;
using OnlineStore.Models;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    /// <summary>
    /// A controller for viewing main page and pages of products.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IProductLocalizer _productLocalizer;

        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        private Random random = new Random();

        public HomeController(ApplicationDbContext db, 
            SignInManager<User> signInManager, 
            UserManager<User> userManager, 
            IProductLocalizer productLocalizer)
        {
            _db = db;
            _productLocalizer = productLocalizer;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// A GET request for the main page.
        /// </summary>
        /// <returns>Returns view with related, new and discounted products.</returns>
        public async Task<IActionResult> Index()
        {
            MainPageViewModel model = new MainPageViewModel();
            
            List<LocalizedProduct> allProducts = new List<LocalizedProduct>();
            
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                User user = _db.Users.Include(u => u.Wishlist).Include(u => u.Wishlist.Products)
                    .Include(u => u.ShoppingCart).Include(u => u.ShoppingCart.Products)
                    .FirstOrDefault(u => u.Id == userId);

                allProducts.AddRange(_productLocalizer.Localize(_db.Products, user));
            }
            else
            {
                allProducts.AddRange(_productLocalizer.Localize(_db.Products));
            }
            
            var relatedProducts = allProducts.OrderByDescending(p => p.Views).Take(3);
            model.RelatedProducts.AddRange(relatedProducts);
            
            // filling New Goods
            var newProducts = allProducts.OrderByDescending(p => p.DateAdded).Take(3);
            model.NewProducts.AddRange(newProducts);

            return View(model);
        }

        public async Task<IActionResult> Search(string request)
        {
            List<Product> products = _db.Products.Where(p => p.NameUA.Contains(request) ||
                                                             p.NameRU.Contains(request) ||
                                                             p.NameEN.Contains(request) ||
                                                             p.DescriptionShortUA.Contains(request) ||
                                                             p.DescriptionShortRU.Contains(request) ||
                                                             p.DescriptionShortEN.Contains(request) ||
                                                             p.DescriptionFullUA.Contains(request) ||
                                                             p.DescriptionFullRU.Contains(request) ||
                                                             p.DescriptionFullEN.Contains(request)).ToList();

            List<LocalizedProduct> model = new List<LocalizedProduct>();

            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                User user = _db.Users.Include(u => u.Wishlist).Include(u => u.Wishlist.Products)
                    .Include(u => u.ShoppingCart).Include(u => u.ShoppingCart.Products)
                    .FirstOrDefault(u => u.Id == userId);

                model.AddRange(_productLocalizer.Localize(products, user));
            }
            else
            {
                model.AddRange(_productLocalizer.Localize(products));
            }
            
            return View(model);
        }

        /// <summary>
        /// A GET request for "/home/product/id". 
        /// </summary>
        /// <param name="id">Product's ID.</param>
        /// <returns>Returns a view with product information.</returns>
        public async Task<IActionResult> Product(int id)
        {
            Product product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            
            product.Views++;
            await _db.SaveChangesAsync();

            LocalizedProduct localizedProduct;
            
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                User user = _db.Users.Include(u => u.Wishlist).Include(u => u.Wishlist.Products)
                    .Include(u => u.ShoppingCart).Include(u => u.ShoppingCart.Products)
                    .FirstOrDefault(u => u.Id == userId);

                localizedProduct = _productLocalizer.Localize(product, user);
            }
            else
            {
                localizedProduct = _productLocalizer.Localize(product);
            }

            return View(localizedProduct);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}