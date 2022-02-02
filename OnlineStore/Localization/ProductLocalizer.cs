using System.Collections.Generic;
using System.Globalization;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    /// <summary>
    /// Localizes a "Product" model.
    /// </summary>
    public class ProductLocalizer : IProductLocalizer
    {
        /// <summary>
        /// Localizes and returns a single product without user's preferences, such as wishlist and cart.
        /// </summary>
        /// <param name="product">An instance of "Product" class.</param>
        /// <returns>Returns a localized product without user's preferences.</returns>
        public LocalizedProduct Localize(Product product)
        {
            string culture = CultureInfo.CurrentCulture.ToString();

            switch (culture)
            {
                case "ua-UA":
                    return GetLocalizedProductInUkrainian(product);
                case "ru-RU":
                    return GetLocalizedProductInRussian(product);
                case "en-US":
                    return GetLocalizedProductInEnglish(product);
                default:
                    return GetLocalizedProductInEnglish(product);
            }
        }

        private LocalizedProduct GetLocalizedProductInEnglish(Product product)
        {
            return new LocalizedProduct()
            {
                Id = product.Id,
                Price = product.Price,
                ImageLink = product.ImageLink,
                DateAdded = product.DateAdded,
                Views = product.Views,
                Name = product.NameEN,
                DescriptionShort = product.DescriptionShortEN,
                DescriptionFull = product.DescriptionFullEN
            };
        }
        
        private LocalizedProduct GetLocalizedProductInRussian(Product product)
        {
            return new LocalizedProduct()
            {
                Id = product.Id,
                Price = product.Price,
                ImageLink = product.ImageLink,
                DateAdded = product.DateAdded,
                Views = product.Views,
                Name = product.NameRU,
                DescriptionShort = product.DescriptionShortRU,
                DescriptionFull = product.DescriptionFullRU
            };
        }
        
        private LocalizedProduct GetLocalizedProductInUkrainian(Product product)
        {
            return new LocalizedProduct()
            {
                Id = product.Id,
                Price = product.Price,
                ImageLink = product.ImageLink,
                DateAdded = product.DateAdded,
                Views = product.Views,
                Name = product.NameUA,
                DescriptionShort = product.DescriptionShortUA,
                DescriptionFull = product.DescriptionFullUA
            };
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

            localizedProduct.IsInWishlist = user.Wishlist.Products.Contains(product);
            localizedProduct.IsInCart = user.ShoppingCart.Products.Contains(product);
            
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
                list.Add(Localize(product));
            
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
                list.Add(Localize(product, user));

            return list;
        }
    }
}