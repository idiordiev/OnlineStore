using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    /// <summary>
    /// Localizes a "Goods" model.
    /// TODO: total rework using PATTERNS
    /// </summary>
    public class GoodsLocalizer: IGoodsLocalizer
    {
        // db instance
        private readonly ApplicationDbContext _db;

        public GoodsLocalizer(ApplicationDbContext db)
        {
            _db = db;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns list of localized goods.</returns>
        public IEnumerable<LocalizedGoods> GetAll()
        {
            List<LocalizedGoods> goodsList = new List<LocalizedGoods>();

            // for every item in db - choosing 1 of 3 languages
            foreach (var goods in _db.Goods)
            {
                string culture = CultureInfo.CurrentCulture.ToString();
                
                switch (culture)
                {
                    case "ua-UA":
                        goodsList.Add(new LocalizedGoods()
                        {
                            Id = goods.Id,
                            Price = goods.Price,
                            Name = goods.NameUA,
                            DescriptionFull = goods.DescriptionFullUA,
                            DescriptionShort = goods.DescriptionShortUA,
                            ImageLink = goods.ImageLink
                        });
                        break;
                    case "ru-RU":
                        goodsList.Add(new LocalizedGoods()
                        {
                            Id = goods.Id,
                            Price = goods.Price,
                            Name = goods.NameRU,
                            DescriptionFull = goods.DescriptionFullRU,
                            DescriptionShort = goods.DescriptionShortRU,
                            ImageLink = goods.ImageLink
                        });
                        break;
                    case "en-US":
                        goodsList.Add(new LocalizedGoods()
                        {
                            Id = goods.Id,
                            Price = goods.Price,
                            Name = goods.NameEN,
                            DescriptionFull = goods.DescriptionFullEN,
                            DescriptionShort = goods.DescriptionShortEN,
                            ImageLink = goods.ImageLink
                        });
                        break;
                    default:
                        goodsList.Add(new LocalizedGoods()
                        {
                            Id = goods.Id,
                            Price = goods.Price,
                            Name = goods.NameEN,
                            DescriptionFull = goods.DescriptionFullEN,
                            DescriptionShort = goods.DescriptionShortEN,
                            ImageLink = goods.ImageLink
                        });
                        break;
                }
            }

            return goodsList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">String with user`s request</param>
        /// <returns></returns>
        public IEnumerable<LocalizedGoods> Find(string request)
        {
            List<LocalizedGoods> goodsList = new List<LocalizedGoods>();

            // for every item - if one of fiels contains request - choose 1 of 3 languages and add to list
            foreach (var goods in _db.Goods)
            {
                if (goods.NameUA.Contains(request) ||
                    goods.NameRU.Contains(request) ||
                    goods.NameEN.Contains(request) ||
                    goods.DescriptionShortUA.Contains(request) ||
                    goods.DescriptionShortRU.Contains(request) ||
                    goods.DescriptionShortEN.Contains(request) ||
                    goods.DescriptionFullUA.Contains(request) ||
                    goods.DescriptionFullRU.Contains(request) ||
                    goods.DescriptionFullEN.Contains(request))
                {
                    string culture = CultureInfo.CurrentCulture.ToString();
                    
                    switch (culture)
                    {
                        case "ua-UA":
                            goodsList.Add(new LocalizedGoods()
                            {
                                Id = goods.Id,
                                Price = goods.Price,
                                Name = goods.NameUA,
                                DescriptionFull = goods.DescriptionFullUA,
                                DescriptionShort = goods.DescriptionShortUA,
                                ImageLink = goods.ImageLink
                            });
                            break;
                        case "ru-RU":
                            goodsList.Add(new LocalizedGoods()
                            {
                                Id = goods.Id,
                                Price = goods.Price,
                                Name = goods.NameRU,
                                DescriptionFull = goods.DescriptionFullRU,
                                DescriptionShort = goods.DescriptionShortRU,
                                ImageLink = goods.ImageLink
                            });
                            break;
                        case "en-US":
                            goodsList.Add(new LocalizedGoods()
                            {
                                Id = goods.Id,
                                Price = goods.Price,
                                Name = goods.NameEN,
                                DescriptionFull = goods.DescriptionFullEN,
                                DescriptionShort = goods.DescriptionShortEN,
                                ImageLink = goods.ImageLink
                            });
                            break;
                        default:
                            goodsList.Add(new LocalizedGoods()
                            {
                                Id = goods.Id,
                                Price = goods.Price,
                                Name = goods.NameEN,
                                DescriptionFull = goods.DescriptionFullEN,
                                DescriptionShort = goods.DescriptionShortEN,
                                ImageLink = goods.ImageLink
                            });
                            break;
                    }
                }
            }

            return goodsList;
        }
    }
}