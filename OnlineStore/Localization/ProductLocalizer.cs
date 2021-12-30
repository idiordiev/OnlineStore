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
    public class ProductLocalizer: IProductLocalizer
    {
        // db instance
        private readonly ApplicationDbContext _db;

        public ProductLocalizer(ApplicationDbContext db)
        {
            _db = db;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns list of localized goods.</returns>
        public List<LocalizedProduct> GetAll()
        {
            List<LocalizedProduct> localizedProducts = new List<LocalizedProduct>();

            // for every item in db - choosing 1 of 3 languages
            foreach (var product in _db.Products)
            {
                string culture = CultureInfo.CurrentCulture.ToString();
                
                switch (culture)
                {
                    case "ua-UA":
                        localizedProducts.Add(new LocalizedProduct()
                        {
                            Id = product.Id,
                            Price = product.Price,
                            Name = product.NameUA,
                            DescriptionFull = product.DescriptionFullUA,
                            DescriptionShort = product.DescriptionShortUA,
                            ImageLink = product.ImageLink,
                            DateAdded = product.DateAdded
                        });
                        break;
                    case "ru-RU":
                        localizedProducts.Add(new LocalizedProduct()
                        {
                            Id = product.Id,
                            Price = product.Price,
                            Name = product.NameRU,
                            DescriptionFull = product.DescriptionFullRU,
                            DescriptionShort = product.DescriptionShortRU,
                            ImageLink = product.ImageLink,
                            DateAdded = product.DateAdded
                        });
                        break;
                    case "en-US":
                        localizedProducts.Add(new LocalizedProduct()
                        {
                            Id = product.Id,
                            Price = product.Price,
                            Name = product.NameEN,
                            DescriptionFull = product.DescriptionFullEN,
                            DescriptionShort = product.DescriptionShortEN,
                            ImageLink = product.ImageLink,
                            DateAdded = product.DateAdded
                        });
                        break;
                    default:
                        localizedProducts.Add(new LocalizedProduct()
                        {
                            Id = product.Id,
                            Price = product.Price,
                            Name = product.NameEN,
                            DescriptionFull = product.DescriptionFullEN,
                            DescriptionShort = product.DescriptionShortEN,
                            ImageLink = product.ImageLink,
                            DateAdded = product.DateAdded
                        });
                        break;
                }
            }

            return localizedProducts;
        }
    }
}