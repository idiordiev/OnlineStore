using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    /// <summary>
    /// A controller for CRUD operations for users.
    /// </summary>
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// A GET request for "/users/" or "/users/index".
        /// </summary>
        /// <returns>Returns view with a list of all users</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        
        
        /// <summary>
        /// A GET request for "/users/create".
        /// </summary>
        /// <returns>Returns view with a page with registration form. </returns>
        public IActionResult Create()
        {
            return View();
        }
        
        
        /// <summary>
        /// A POST request for "/users/create".
        /// </summary>
        /// <param name="model">A viewmodel with user's data.</param>
        /// <returns>If model is valid, redirects to "/users". Otherwise, returns the same page.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(UserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { 
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    City = model.City,
                    Address = model.Address
                };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
        /// A GET request for "/users/edit/id".
        /// </summary>
        /// <param name="id">User's ID.</param>
        /// <returns>Returns view with form for editing (inputs might be filled).</returns>
        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            UserEditViewModel model = new UserEditViewModel()
            {
                Id = user.Id, 
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                PhoneNumber = user.PhoneNumber
            };
            return View(model);
        }
        
        /// <summary>
        /// A POST request for "/users/edit/id".
        /// </summary>
        /// <param name="model">A model with fields filled in form.</param>
        /// <returns>If model is valid, redirects to "/users/". Otherwise, returns the same page.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.UserName = model.Username;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Address = model.Address;
                    user.City = model.City;
                    user.PhoneNumber = model.PhoneNumber;

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

            return View(model);
        }

        /// <summary>
        /// A POST action for deleting users. Don't have view, just use form with asp-route-id.
        /// </summary>
        /// <param name="id">User's ID.</param>
        /// <returns>Redirects to "/users/".</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
            }

            return RedirectToAction("Index");
        }

    }
}