using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Localization;
using OnlineStore.Models;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    /// <summary>
    /// A controller for register new account and login to an existing account. Uses ASP.NET Core Identity.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly ApplicationDbContext _db;

        private readonly ProductLocalizer _productLocalizer;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _productLocalizer = new ProductLocalizer();
        }

        /// <summary>
        /// A GET request for "/account".
        /// </summary>
        /// <returns>Returns a view with form (inputs might be filled).</returns>
        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                string id = _userManager.GetUserId(HttpContext.User);

                User user = await _userManager.FindByIdAsync(id);

                UserPageViewModel model = new UserPageViewModel()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    City = user.City,
                    Address = user.Address
                };
                return View(model);
            }
            return View();
        }

        /// <summary>
        /// A POST request for changing user's data. Called from "/account". Don't have view.
        /// </summary>
        /// <param name="model">A viewmodel with user's data.</param>
        /// <returns>Redirects to "/account".</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(UserPageViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Id = model.Id;
                    user.UserName = model.Username;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    user.City = model.City;
                    user.Address = model.Address;
                    
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(String.Empty, error.Description);
                        }
                    }
                }
            }
            return RedirectToAction("Index", model);
        }

        /// <summary>
        /// A GET request for "/account/ChangePassword".
        /// </summary>
        /// <returns>Returns a view with form for changing password.</returns>
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            if (_signInManager.IsSignedIn(User))
            {
                string id = _userManager.GetUserId(HttpContext.User);

                User user = await _userManager.FindByIdAsync(id);

                ChangePasswordViewModel model = new ChangePasswordViewModel()
                {
                    Id = user.Id,
                    Username = user.UserName
                };

                return View(model);
            }

            return View();
        }

        /// <summary>
        /// A POST request for "/account/ChangePassword".
        /// </summary>
        /// <param name="model">A viewmodel with data.</param>
        /// <returns>If model is valid, redirects to "/account". Otherwise, returns the same page.</returns>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);

                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(String.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "User not found.");
                }
            }
            return View(model);
        }

        /// <summary>
        /// A GET request for "/account/register".
        /// </summary>
        /// <returns>Returns a view with registration form.</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// A POST request for "/account/register".
        /// </summary>
        /// <param name="model">A viewmodel with registration form's data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Email = model.Email, UserName = model.Username};

                Wishlist wishlist = new Wishlist();
                ShoppingCart shoppingCart = new ShoppingCart();

                user.Wishlist = wishlist;
                user.ShoppingCart = shoppingCart;
                
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        /// <summary>
        /// A GET request for "/account/login". Might contain a link to go back.
        /// </summary>
        /// <param name="returnUrl">A link to go back after login.</param>
        /// <returns>Returns a view with form for registration.</returns>
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel() {ReturnUrl = returnUrl});
        }

        /// <summary>
        /// A POST request for "/account/login".
        /// </summary>
        /// <param name="model">A viewmodel with login form's data.</param>
        /// <returns>If login data is OK, returns to page in "returnUrl". Otherwise, returns to the same page.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "NotValidCredentials");
                }
            }

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #region Shopping Cart

        public async Task<IActionResult> ShoppingCart()
        {
            if (_signInManager.IsSignedIn(User))
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                User user = _db.Users.Include(u => u.ShoppingCart).Include(u => u.ShoppingCart.Products).FirstOrDefault(u => u.Id == userId);

                ShoppingCartViewModel model = new ShoppingCartViewModel()
                {
                    Products = _productLocalizer.Localize(user.ShoppingCart.Products.ToList(), user)
                };

                return View(model);
            }
            
            return View();
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int id, string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                User user = _db.Users.Include(u => u.ShoppingCart).Include(u => u.ShoppingCart.Products).FirstOrDefault(u => u.Id == userId);

                Product product = await _db.Products.FindAsync(id);
                
                user.ShoppingCart.Products.Add(product);

                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int id, string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                User user = _db.Users.Include(u => u.ShoppingCart).Include(u => u.ShoppingCart.Products).FirstOrDefault(u => u.Id == userId);

                Product product = await _db.Products.FindAsync(id);
                
                user.ShoppingCart.Products.Remove(product);

                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }

        #endregion


        #region Wishlist

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToWishlist(int id, string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                User user = _db.Users.Include(u => u.Wishlist).Include(u => u.Wishlist.Products).FirstOrDefault(u => u.Id == userId);

                Product product = await _db.Products.FindAsync(id);
                
                user.Wishlist.Products.Add(product);

                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveFromWishlist(int id, string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                string userId = _userManager.GetUserId(HttpContext.User);

                User user = _db.Users.Include(u => u.Wishlist).Include(u => u.Wishlist.Products).FirstOrDefault(u => u.Id == userId);

                Product product = await _db.Products.FindAsync(id);
                
                user.Wishlist.Products.Remove(product);

                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }

        #endregion
    }
}