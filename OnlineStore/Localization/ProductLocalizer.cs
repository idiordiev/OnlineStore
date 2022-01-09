using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    /// <summary>
    /// Localizes a "Product" model.
    /// </summary>
    public class ProductLocalizer : IProductLocalizer
    {

        public ProductLocalizer() { }

        /// <summary>
        /// Localizes and returns a single product without user's preferences, such as wishlist and cart.
        /// </summary>
        /// <param name="product">An instance of "Product" class.</param>
        /// <returns>Returns a localized product without user's preferences.</returns>
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
        /// Localizes and returns a single product with user's preferences, such as wishlist and cart.
        /// </summary>
        /// <param name="product">An instance of "Product" class.</param>
        /// <param name="user">An instance of "User" class.</param>
        /// <returns>Returns a localized product with user's preferences.</returns>
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
        /// Localizes and returns a collection of products without user's preferences, such as wishlist and cart.
        /// </summary>
        /// <param name="products">A collection of "Product" instances.</param>
        /// <returns>Returns a list of localized products without user's preferences.</returns>
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
        /// Localizes and returns a collection of products with user's preferences, such as wishlist and cart.
        /// </summary>
        /// <param name="products">A collection of "Product" instances.</param>
        /// <param name="user">An instance of "User" class.</param>
        /// <returns>Returns a list of localized products with user's preferences.</returns>
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