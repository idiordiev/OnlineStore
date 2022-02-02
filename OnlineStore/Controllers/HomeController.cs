using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        private readonly ICategoryLocalizer _categoryLocalizer;
        private readonly IProductLocalizer _productLocalizer;

        public HomeController(ApplicationDbContext db, 
            SignInManager<User> signInManager, 
            UserManager<User> userManager, 
            IProductLocalizer productLocalizer,
            ICategoryLocalizer categoryLocalizer)
        {
            _db = db;
            _productLocalizer = productLocalizer;
            _categoryLocalizer = categoryLocalizer;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// A GET request for the main page.
        /// </summary>
        /// <returns>Returns view with related, new and discounted products.</returns>
        public IActionResult Index()
        {
            MainPageViewModel model = new MainPageViewModel()
            {
                NewProducts = GetNewLocalizedProducts(),
                RelatedProducts = GetRelatedLocalizedProducts()
            };

            ViewBag.Categories = GetLocalizedCategories();
            return View(model);
        }

        private ICollection<LocalizedProduct> GetAllLocalizedProducts()
        {
            List<LocalizedProduct> products;

            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                var user = GetUser();
                products = _productLocalizer.Localize(_db.Products, user);
            }
            else
                products = _productLocalizer.Localize(_db.Products);

            return products;
        }

        private ICollection<LocalizedProduct> GetRelatedLocalizedProducts()
        {
            return GetAllLocalizedProducts().OrderByDescending(p => p.Views).Take(3).ToList();
        }

        private ICollection<LocalizedProduct> GetNewLocalizedProducts()
        {
            return GetAllLocalizedProducts().OrderByDescending(p => p.DateAdded).Take(3).ToList();
        }

        private ICollection<LocalizedCategory> GetLocalizedCategories()
        {
            return _categoryLocalizer.Localize(_db.Categories);
        }

        private User GetUser()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            
            User user = _db.Users.Include(u => u.Wishlist)
                .Include(u => u.Wishlist.Products)
                .Include(u => u.ShoppingCart)
                .Include(u => u.ShoppingCart.Products)
                .FirstOrDefault(u => u.Id == userId);

            return user;
        }
        
        public IActionResult Search(string request, int? categoryId)
        {
            IList<LocalizedProduct> model;

            if (request != null)
                model = Localize(SearchByRequest(request));
            else if (categoryId != null)
                model = Localize(SearchByCategory((int)categoryId));
            else
                model = GetAllLocalizedProducts().ToList();

            ViewBag.Categories = GetLocalizedCategories();
            return View(model);
        }

        private IList<Product> SearchByRequest(string request)
        {
            return _db.Products.Where(p => p.NameUA.Contains(request) || 
                                           p.NameRU.Contains(request) ||
                                           p.NameEN.Contains(request) ||
                                           p.DescriptionShortUA.Contains(request) ||
                                           p.DescriptionShortRU.Contains(request) ||
                                           p.DescriptionShortEN.Contains(request) ||
                                           p.DescriptionFullUA.Contains(request) ||
                                           p.DescriptionFullRU.Contains(request) ||
                                           p.DescriptionFullEN.Contains(request)).ToList();
        }

        private IList<Product> SearchByCategory(int categoryId)
        {
            return _db.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        private IList<LocalizedProduct> Localize(IEnumerable<Product> products)
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
                return _productLocalizer.Localize(products, GetUser());
            
            return _productLocalizer.Localize(products);
        }
            
        /// <summary>
        /// A GET request for "/home/product/id". 
        /// </summary>
        /// <param name="id">Product's ID.</param>
        /// <returns>Returns a view with product information.</returns>
        public async Task<IActionResult> Product(int id)
        {
            Product product = await FindProductAndIncrementViews(id);
            var model = Localize(product);
            
            ViewBag.Categories = GetLocalizedCategories();
            return View(model);
        }

        private async Task<Product> FindProductAndIncrementViews(int id)
        {
            Product product = await _db.Products.FindAsync(id);

            if (product != null)
            {
                product.Views++;
                await _db.SaveChangesAsync();
            }

            return product;
        }

        private LocalizedProduct Localize(Product product)
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
                return _productLocalizer.Localize(product, GetUser());

            return _productLocalizer.Localize(product);
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