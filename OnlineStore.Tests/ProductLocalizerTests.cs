using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OnlineStore.Localization;
using OnlineStore.Models;
using Xunit;

namespace OnlineStore.Tests
{
    public class ProductLocalizerTests
    {
        private Product GetProduct()
        {
            return new Product()
            {
                Id = 1,
                Price = 1488,
                Category = new Category()
                {
                    Id = 1,
                    NameEN = "categoryEN",
                    NameRU = "categoryRU",
                    NameUA = "categoryUA"
                },
                NameEN = "nameEN",
                NameRU = "nameRU",
                NameUA = "nameUA",
                CategoryId = 1,
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                DescriptionShortEN = "descrShortEN",
                DescriptionShortRU = "descrShortRU",
                DescriptionShortUA = "descrShortUA",
                DescriptionFullEN = "descrFullEN",
                DescriptionFullRU = "descrFullRU",
                DescriptionFullUA = "descrFullUA",
                Views = 69
            };
        }

        private IEnumerable<Product> GetEnumerableOfProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Price = 1488,
                    Category = new Category()
                    {
                        Id = 1,
                        NameEN = "categoryEN",
                        NameRU = "categoryRU",
                        NameUA = "categoryUA"
                    },
                    NameEN = "nameEN",
                    NameRU = "nameRU",
                    NameUA = "nameUA",
                    CategoryId = 1,
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    DescriptionShortEN = "descrShortEN",
                    DescriptionShortRU = "descrShortRU",
                    DescriptionShortUA = "descrShortUA",
                    DescriptionFullEN = "descrFullEN",
                    DescriptionFullRU = "descrFullRU",
                    DescriptionFullUA = "descrFullUA",
                    Views = 69
                },
                new Product()
                {
                    Id = 2,
                    Price = 1489,
                    Category = new Category()
                    {
                        Id = 1,
                        NameEN = "categoryEN",
                        NameRU = "categoryRU",
                        NameUA = "categoryUA"
                    },
                    NameEN = "nameEN2",
                    NameRU = "nameRU2",
                    NameUA = "nameUA2",
                    CategoryId = 1,
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    DescriptionShortEN = "descrShortEN2",
                    DescriptionShortRU = "descrShortRU2",
                    DescriptionShortUA = "descrShortUA2",
                    DescriptionFullEN = "descrFullEN2",
                    DescriptionFullRU = "descrFullRU2",
                    DescriptionFullUA = "descrFullUA2",
                    Views = 420
                }
            };
        }

        private User GetUser()
        {
            return new User()
            {
                
                ShoppingCart = new ShoppingCart()
                {
                    Id = 1,
                    Products = new List<Product>()
                },
                Wishlist = new Wishlist()
                {
                    Id = 1,
                    Products = new List<Product>()
                }
            };
        }

        private void AssertLocalizedProducts(LocalizedProduct expected, LocalizedProduct actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.DescriptionShort, actual.DescriptionShort);
            Assert.Equal(expected.DescriptionFull, actual.DescriptionFull);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.ImageLink, actual.ImageLink);
            Assert.Equal(expected.Views, actual.Views);
            Assert.Equal(expected.IsInCart, actual.IsInCart);
            Assert.Equal(expected.IsInWishlist, actual.IsInWishlist);
        }

        private void AssertLocalizedProducts(List<LocalizedProduct> expected,
            List<LocalizedProduct> actual)
        {
            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                AssertLocalizedProducts(expected[i], actual[i]);
            }
        }

        #region Single product without user

        [Fact]
        public void LocalizeSingleProductInRussian_WithoutUser()
        {
            // Arrange
            var product = GetProduct();
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameRU",
                Price = 1488,
                DescriptionShort = "descrShortRU",
                DescriptionFull = "descrFullRU",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleProductInUkrainian_WithoutUser()
        {
            // Arrange
            var product = GetProduct();
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameUA",
                Price = 1488,
                DescriptionShort = "descrShortUA",
                DescriptionFull = "descrFullUA",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleProductInEnglish_WithoutUser()
        {
            // Arrange
            var product = GetProduct();
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameEN",
                Price = 1488,
                DescriptionShort = "descrShortEN",
                DescriptionFull = "descrFullEN",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }

        #endregion

        #region Single product with user (shopping cart)

        [Fact]
        public void LocalizeSingleProductInRussian_WithUser_ShoppingCart()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.ShoppingCart.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameRU",
                Price = 1488,
                DescriptionShort = "descrShortRU",
                DescriptionFull = "descrFullRU",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInCart = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleProductInUkrainian_WithUser_ShoppingCart()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.ShoppingCart.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameUA",
                Price = 1488,
                DescriptionShort = "descrShortUA",
                DescriptionFull = "descrFullUA",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInCart = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleProductInEnglish_WithUser_ShoppingCart()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.ShoppingCart.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameEN",
                Price = 1488,
                DescriptionShort = "descrShortEN",
                DescriptionFull = "descrFullEN",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInCart = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }

        #endregion

        #region Single product with user (wishlist)

        [Fact]
        public void LocalizeSingleProductInRussian_WithUser_Wishlist()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.Wishlist.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameRU",
                Price = 1488,
                DescriptionShort = "descrShortRU",
                DescriptionFull = "descrFullRU",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInWishlist = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleProductInUkrainian_WithUser_Wishlist()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.Wishlist.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameUA",
                Price = 1488,
                DescriptionShort = "descrShortUA",
                DescriptionFull = "descrFullUA",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInWishlist = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleProductInEnglish_WithUser_Wishlist()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.Wishlist.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameEN",
                Price = 1488,
                DescriptionShort = "descrShortEN",
                DescriptionFull = "descrFullEN",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInWishlist = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }

        #endregion

        #region Single product with user (wishlist and shopping cart)

        [Fact]
        public void LocalizeSingleProductInRussian_WithUser_ShoppingCartAndWishlist()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.ShoppingCart.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameRU",
                Price = 1488,
                DescriptionShort = "descrShortRU",
                DescriptionFull = "descrFullRU",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInCart = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleProductInUkrainian_WithUser_ShoppingCartAndWishlist()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.ShoppingCart.Products.Add(product);
            user.Wishlist.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameUA",
                Price = 1488,
                DescriptionShort = "descrShortUA",
                DescriptionFull = "descrFullUA",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInCart = true,
                IsInWishlist = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleProductInEnglish_WithUser_ShoppingCartAndWishlist()
        {
            // Arrange
            var product = GetProduct();
            var user = GetUser();
            user.ShoppingCart.Products.Add(product);
            user.Wishlist.Products.Add(product);
            var expected = new LocalizedProduct()
            {
                Id = 1, 
                Name = "nameEN",
                Price = 1488,
                DescriptionShort = "descrShortEN",
                DescriptionFull = "descrFullEN",
                DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                Views = 69,
                IsInCart = true,
                IsInWishlist = true
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(product, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }

        #endregion

        #region IEnumerable<Product> without user

        [Fact]
        public void LocalizeListOfProductsInRussian_WithoutUser()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameRU",
                    Price = 1488,
                    DescriptionShort = "descrShortRU",
                    DescriptionFull = "descrFullRU",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameRU2",
                    Price = 1489,
                    DescriptionShort = "descrShortRU2",
                    DescriptionFull = "descrFullRU2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfProductsInUkrainian_WithoutUser()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameUA",
                    Price = 1488,
                    DescriptionShort = "descrShortUA",
                    DescriptionFull = "descrFullUA",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameUA2",
                    Price = 1489,
                    DescriptionShort = "descrShortUA2",
                    DescriptionFull = "descrFullUA2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfProductsInEnglish_WithoutUser()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameEN",
                    Price = 1488,
                    DescriptionShort = "descrShortEN",
                    DescriptionFull = "descrFullEN",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameEN2",
                    Price = 1489,
                    DescriptionShort = "descrShortEN2",
                    DescriptionFull = "descrFullEN2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }

        #endregion

        #region IEnumerable<Product> with user (shopping cart)

        [Fact]
        public void LocalizeListOfProductsInRussian_WithUser_ShoppingCart()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.ShoppingCart.Products.Add(products.FirstOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameRU",
                    Price = 1488,
                    DescriptionShort = "descrShortRU",
                    DescriptionFull = "descrFullRU",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInCart = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameRU2",
                    Price = 1489,
                    DescriptionShort = "descrShortRU2",
                    DescriptionFull = "descrFullRU2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfProductsInUkrainian_WithUser_ShoppingCart()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.ShoppingCart.Products.Add(products.FirstOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameUA",
                    Price = 1488,
                    DescriptionShort = "descrShortUA",
                    DescriptionFull = "descrFullUA",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInCart = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameUA2",
                    Price = 1489,
                    DescriptionShort = "descrShortUA2",
                    DescriptionFull = "descrFullUA2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfProductsInEnglish_WithUser_ShoppingCart()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.ShoppingCart.Products.Add(products.FirstOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameEN",
                    Price = 1488,
                    DescriptionShort = "descrShortEN",
                    DescriptionFull = "descrFullEN",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInCart = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameEN2",
                    Price = 1489,
                    DescriptionShort = "descrShortEN2",
                    DescriptionFull = "descrFullEN2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }

        #endregion

        #region IEnumerable<Product> with user (wishlist)

        [Fact]
        public void LocalizeListOfProductsInRussian_WithUser_Wishlist()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.Wishlist.Products.Add(products.FirstOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameRU",
                    Price = 1488,
                    DescriptionShort = "descrShortRU",
                    DescriptionFull = "descrFullRU",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInWishlist = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameRU2",
                    Price = 1489,
                    DescriptionShort = "descrShortRU2",
                    DescriptionFull = "descrFullRU2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfProductsInUkrainian_WithUser_Wishlist()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.Wishlist.Products.Add(products.FirstOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameUA",
                    Price = 1488,
                    DescriptionShort = "descrShortUA",
                    DescriptionFull = "descrFullUA",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInWishlist = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameUA2",
                    Price = 1489,
                    DescriptionShort = "descrShortUA2",
                    DescriptionFull = "descrFullUA2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfProductsInEnglish_WithUser_Wishlist()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.Wishlist.Products.Add(products.FirstOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameEN",
                    Price = 1488,
                    DescriptionShort = "descrShortEN",
                    DescriptionFull = "descrFullEN",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInWishlist = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameEN2",
                    Price = 1489,
                    DescriptionShort = "descrShortEN2",
                    DescriptionFull = "descrFullEN2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        #endregion

        #region IEnumerable<Product> with user (wishlist and shopping cart)

        [Fact]
        public void LocalizeListOfProductsInRussian_WithUser_ShoppingCartAndWishlist()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.ShoppingCart.Products.Add(products.FirstOrDefault());
            user.Wishlist.Products.Add(products.LastOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameRU",
                    Price = 1488,
                    DescriptionShort = "descrShortRU",
                    DescriptionFull = "descrFullRU",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInCart = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameRU2",
                    Price = 1489,
                    DescriptionShort = "descrShortRU2",
                    DescriptionFull = "descrFullRU2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420,
                    IsInWishlist = true
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfProductsInUkrainian_WithUser_ShoppingCartAndWishlist()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.ShoppingCart.Products.Add(products.FirstOrDefault());
            user.Wishlist.Products.Add(products.LastOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameUA",
                    Price = 1488,
                    DescriptionShort = "descrShortUA",
                    DescriptionFull = "descrFullUA",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInCart = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameUA2",
                    Price = 1489,
                    DescriptionShort = "descrShortUA2",
                    DescriptionFull = "descrFullUA2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420,
                    IsInWishlist = true
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfProductsInEnglish_WithUser_ShoppingCartAndWishlist()
        {
            // Arrange
            var products = GetEnumerableOfProducts();
            var user = GetUser();
            user.ShoppingCart.Products.Add(products.FirstOrDefault());
            user.Wishlist.Products.Add(products.LastOrDefault());
            var expected = new List<LocalizedProduct>()
            {
                new LocalizedProduct()
                {
                    Id = 1, 
                    Name = "nameEN",
                    Price = 1488,
                    DescriptionShort = "descrShortEN",
                    DescriptionFull = "descrFullEN",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 69,
                    IsInCart = true
                },
                new LocalizedProduct()
                {
                    Id = 2, 
                    Name = "nameEN2",
                    Price = 1489,
                    DescriptionShort = "descrShortEN2",
                    DescriptionFull = "descrFullEN2",
                    DateAdded = new DateTime(2020, 12, 25, 10, 25, 30),
                    Views = 420,
                    IsInWishlist = true
                }
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var productLocalizer = new ProductLocalizer();

            // Act
            var actual = productLocalizer.Localize(products, user);

            // Assert
            AssertLocalizedProducts(expected, actual);
        }

        #endregion
    }
}