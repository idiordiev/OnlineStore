using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    /// <summary>
    /// Localizes a "Product" model.
    /// </summary>
    public class ProductLocalizer
    {

        public ProductLocalizer() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public LocalizedProduct Localize(Product product)
        {
            LocalizedProduct localizedProduct = new LocalizedProduct()
            {
                Id = product.Id,
                Price = product.Price,
                ImageLink = product.ImageLink,
                DateAdded = product.DateAdded,
                IsInCart = false,
                IsInWishlist = false,
                Views = product.Views
            };
            
            string culture = CultureInfo.CurrentCulture.ToString();

            switch (culture)
            {
                case "ua-UA":
                    localizedProduct.Name = product.NameUA;
                    localizedProduct.DescriptionShort = product.DescriptionShortUA;
                    localizedProduct.DescriptionFull = product.DescriptionFullUA;
                    break;
                case "ru-RU":
                    localizedProduct.Name = product.NameRU;
                    localizedProduct.DescriptionShort = product.DescriptionShortRU;
                    localizedProduct.DescriptionFull = product.DescriptionFullRU;
                    break;
                case "en-US":
                    localizedProduct.Name = product.NameEN;
                    localizedProduct.DescriptionShort = product.DescriptionShortEN;
                    localizedProduct.DescriptionFull = product.DescriptionFullEN;
                    break;
                default:
                    localizedProduct.Name = product.NameEN;
                    localizedProduct.DescriptionShort = product.DescriptionShortEN;
                    localizedProduct.DescriptionFull = product.DescriptionFullEN;
                    break;
            }

            return localizedProduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public LocalizedProduct Localize(Product product, User user)
        {
            LocalizedProduct localizedProduct = Localize(product);

            if (user.Wishlist != null &&
                user.Wishlist.Products != null &&
                user.Wishlist.Products.Count != 0 &&
                user.Wishlist.Products.Contains(product))
            {
                localizedProduct.IsInWishlist = true;
            }

            if (user.ShoppingCart != null &&
                user.ShoppingCart.Products != null &&
                user.ShoppingCart.Products.Count != 0 &&
                user.ShoppingCart.Products.Contains(product))
            {
                localizedProduct.IsInCart = true;
            }

            return localizedProduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public List<LocalizedProduct> Localize(IEnumerable<Product> products)
        {
            List<LocalizedProduct> list = new List<LocalizedProduct>();

            foreach (var product in products)
            {
                list.Add(Localize(product));
            }
            
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="products"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<LocalizedProduct> Localize(IEnumerable<Product> products, User user)
        {
            List<LocalizedProduct> list = new List<LocalizedProduct>();

            foreach (var product in products)
            {
                list.Add(Localize(product, user));
            }

            return list;
        }


    }
}