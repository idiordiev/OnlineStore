using System;
using System.Globalization;
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
        
        [Fact]
        public void GetLocalizedProductInRussian()
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
            Assert.Equal(expected, actual);
        }
    }
}