using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        private Random random = new Random();

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            // creating viewmodel
            GoodsForIndexViewModel goodsList = new GoodsForIndexViewModel();

            if (_db.Goods.Count() == 0)
                return View(goodsList);

            int lastId = _db.Goods.OrderByDescending(p => p.Id).FirstOrDefault().Id;
            lastId++;

            // filling Related Goods
            for (int i = 0; i < 3; i++)
            {
                int num = random.Next(lastId);
                Goods item = await _db.Goods.FindAsync(num);

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
                Goods item = await _db.Goods.FindAsync(num);

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
                Goods item = await _db.Goods.FindAsync(num);

                if (item == null)
                {
                    i--;
                    continue;
                }
                
                goodsList.NewGoodsList.Add(item);
            }
            
            return View(goodsList);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}