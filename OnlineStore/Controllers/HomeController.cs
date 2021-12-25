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
    /// A controller for viewing main page and pages of products. ]
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly GoodsLocalizer _goodsLocalizer;
        
        private Random random = new Random();

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
            _goodsLocalizer = new GoodsLocalizer(db);
        }

        /// <summary>
        /// A GET request for the main page.
        /// </summary>
        /// <returns>Returns view with related, new and discounted products.</returns>
        public IActionResult Index()
        {
            // creating viewmodel
            GoodsForIndexViewModel goodsList = new GoodsForIndexViewModel();

            var allGoods = _goodsLocalizer.GetAll();

            if (allGoods.Count() == 0)
                return View(goodsList);

            int lastId = allGoods.LastOrDefault().Id;
            lastId++;

            // filling Related Goods
            for (int i = 0; i < 3; i++)
            {
                int num = random.Next(lastId);
                LocalizedGoods item = (from goods in allGoods where goods.Id == num select goods).FirstOrDefault();

                if (item == null)
                {
                    i--;
                    continue;
                }
                
                goodsList.RelatedGoodsList.Add(item);
            }

            // filling Discounted Goods
            // TODO: сделать таблицу со скидочными товарами
            for (int i = 0; i < 3; i++)
            {
                int num = random.Next(lastId);
                LocalizedGoods item = (from goods in allGoods where goods.Id == num select goods).FirstOrDefault();

                if (item == null)
                {
                    i--;
                    continue;
                }
                
                goodsList.DiscountGoodsList.Add(item);
            }

            // filling New Goods
            // TODO: добавить в модель поле "дата добавления" чтобы потом выбирать товары, добавленые не позже недели назад
            for (int i = 0; i < 3; i++)
            {
                int num = random.Next(lastId);
                LocalizedGoods item = (from goods in allGoods where goods.Id == num select goods).FirstOrDefault();

                if (item == null)
                {
                    i--;
                    continue;
                }
                
                goodsList.NewGoodsList.Add(item);
            }
            
            return View(goodsList);
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