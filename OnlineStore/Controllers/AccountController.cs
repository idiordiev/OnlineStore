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
        private readonly ApplicationDbContext _db;
        
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IProductLocalizer _productLocalizer;

        public AccountController(UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            ApplicationDbContext db, 
            IProductLocalizer productLocalizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _productLocalizer = productLocalizer;
        }

        /// <summary>
        /// A GET request for "/account".
        /// </summary>
        /// <returns>Returns a view with form (inputs might be filled).</returns>
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = GetUser();

                UserViewModel model = new UserViewModel()
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

        private User GetUser()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            
            User user = _db.Users.Include(u => u.Wishlist)
                .Include(u => u.Wishlist.Products)
                .Include(u => u.ShoppingCart)
                .Include(u => u.ShoppingCart.Products)
                .Include(u => u.Receipts)
                .FirstOrDefault(u => u.Id == userId);

            return user;
        }

        /// <summary>
        /// A POST request for changing user's data. Called from "/account". Don't have view.
        /// </summary>
        /// <param name="model">A viewmodel with user's data.</param>
        /// <returns>Redirects to "/account".</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
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
                        return RedirectToAction("Index");
                    else
                        foreach (var error in result.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return RedirectToAction("Index", model);
        }

        /// <summary>
        /// A GET request for "/account/ChangePassword".
        /// </summary>
        /// <returns>Returns a view with form for changing password.</returns>
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = GetUser();

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
                        return RedirectToAction("Index");
                    else
                        foreach (var error in result.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                }
                else
                    ModelState.AddModelError(string.Empty, "User not found.");
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
                User user = new User() 
                { 
                    Email = model.Email,
                    UserName = model.Username,
                    Wishlist = new Wishlist(),
                    ShoppingCart = new ShoppingCart()
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        /// <summary>
        /// A GET request for "/account/login". Might contain a link to go back.
        /// </summary>
        /// <param name="returnUrl">A link to go back after login.</param>
        /// <returns>Returns a view with form for registration.</returns>
        [HttpGet]
        public IActionResult Login(string returnUrl = default)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
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
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,
                    model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(string.Empty, "NotValidCredentials");
            }

            return View(model);
        }

        /// <summary>
        /// A POST request for logging out.
        /// </summary>
        /// <returns>Redirects to home page "/".</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #region Shopping Cart

        /// <summary>
        /// A GET request for shopping cart. Used in modal window.
        /// </summary>
        /// <returns>Returns a view with list of products added to cart.</returns>
        public IActionResult ShoppingCart()
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = GetUser();
                ShoppingCartViewModel model = new ShoppingCartViewModel()
                {
                    Products = _productLocalizer.Localize(user.ShoppingCart.Products.ToList(), user)
                };

                return View(model);
            }
            
            return View();
        }
        
        
        /// <summary>
        /// A POST request for adding product to user's shopping cart.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="returnUrl">URL of current page or another page you want redirect to.</param>
        /// <returns>Redirects to URL, specified in "returnUrl" parameter.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int id, string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = GetUser();
                Product product = await _db.Products.FindAsync(id);
                
                user.ShoppingCart.Products.Add(product);

                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }
        
        /// <summary>
        /// A POST request for removing product from user's shopping cart.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="returnUrl">URL of current page or another page you want redirect to.</param>
        /// <returns>Redirects to URL, specified in "returnUrl" parameter.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int id, string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = GetUser();
                Product product = await _db.Products.FindAsync(id);
                user.ShoppingCart.Products.Remove(product);
                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }

        #endregion


        #region Wishlist

        public IActionResult Wishlist()
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = GetUser();

                WishlistViewModel model = new WishlistViewModel()
                {
                    Products = _productLocalizer.Localize(user.Wishlist.Products.ToList(), user)
                };

                return View(model);
            }
            
            return View();
        }
        
        
        /// <summary>
        /// A POST request for adding product to user's wishlist.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="returnUrl">URL of current page or another page you want redirect to.</param>
        /// <returns>Redirects to URL, specified in "returnUrl" parameter.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToWishlist(int id, string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = GetUser();
                Product product = await _db.Products.FindAsync(id);
                
                user.Wishlist.Products.Add(product);

                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }
        
        /// <summary>
        /// A POST request for removing product from user's wishlist.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="returnUrl">URL of current page or another page you want redirect to.</param>
        /// <returns>Redirects to URL, specified in "returnUrl" parameter.</returns>
        public async Task<IActionResult> RemoveFromWishlist(int id, string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                User user = GetUser();
                Product product = await _db.Products.FindAsync(id);
                
                user.Wishlist.Products.Remove(product);

                await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }

        #endregion

        #region Orders
        
        // DO NOT UNCOMMENT!!! NOT WORK
        public IActionResult Order()
        {
        //     if (_signInManager.IsSignedIn(HttpContext.User))
        //     {
        //         var user = GetUser();
        //
        //         var model = new OrderViewModel()
        //         {
        //             Products = _productLocalizer.Localize(user.Wishlist.Products, user)
        //         };
        //         
        //         return View(model);
        //     }
        //
            return View();
        }
        //
        // [HttpPost]
        // public async Task<IActionResult> Order(OrderViewModel model)
        // {
        //     if (_signInManager.IsSignedIn(HttpContext.User))
        //     {
        //         if (ModelState.IsValid)
        //         {
        //             var user = GetUser();
        //             user.Receipts.Add(new Receipt()
        //             {
        //                 Date = DateTime.Now,
        //                 Products = user.ShoppingCart.Products,
        //                 User = user,
        //                 City = model.City,
        //                 Address = model.Address,
        //                 Comment = model.Comment
        //             });
        //
        //             await _db.SaveChangesAsync();
        //             
        //             user.ShoppingCart.Products.Clear();
        //             await _db.SaveChangesAsync();
        //
        //         }
        //
        //         return View(model);
        //     }
        //
        //     return View();
        // }

        #endregion
    }
}