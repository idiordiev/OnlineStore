using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
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

        private readonly ProductLocalizer _productLocalizer;
        
        private Random random = new Random();

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
            _productLocalizer = new ProductLocalizer(db);
        }

        /// <summary>
        /// A GET request for the main page.
        /// </summary>
        /// <returns>Returns view with related, new and discounted products.</returns>
        public async Task<IActionResult> Index()
        {
            MainPageViewModel products = new MainPageViewModel();

            var allProducts = _productLocalizer.GetAll();

            int lastId = allProducts.LastOrDefault().Id;
            lastId++;

            // filling Related Products
            for (int i = 0; i < 3; i++)
            {
                int num = random.Next(lastId);
                LocalizedProduct item = (from goods in allProducts where goods.Id == num select goods).FirstOrDefault();

                if (item == null)
                {
                    i--;
                    continue;
                }
                
                products.RelatedProducts.Add(item);
            }

            // filling New Goods
            var newProducts = allProducts.OrderByDescending(p => p.DateAdded).Take(3);
            
            products.NewProducts.AddRange(newProducts);

            return View(products);
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