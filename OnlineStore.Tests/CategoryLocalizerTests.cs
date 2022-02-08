using System;
using System.Collections.Generic;
using System.Globalization;
using OnlineStore.Localization;
using OnlineStore.Models;
using Xunit;

namespace OnlineStore.Tests
{
    public class CategoryLocalizerTests
    {
        private Category GetCategory()
        {
            return new Category()
            {
                Id = 1,
                NameEN = "nameEN",
                NameRU = "nameRU",
                NameUA = "nameUA"
            };
        }

        private IEnumerable<Category> GetEnumerableOfCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    NameEN = "nameEN",
                    NameRU = "nameRU",
                    NameUA = "nameUA"
                },
                new Category()
                {
                    Id = 2,
                    NameEN = "nameEN2",
                    NameRU = "nameRU2",
                    NameUA = "nameUA2"
                }
            };
        }

        private void AssertLocalizedCategories(LocalizedCategory expected, LocalizedCategory actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
        }

        private void AssertLocalizedCategories(List<LocalizedCategory> expected, List<LocalizedCategory> actual)
        {
            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                AssertLocalizedCategories(expected[i], actual[i]);
            }
        }

        #region Single category

        [Fact]
        public void LocalizeSingleCategoryInRussian()
        {
            // Arrange
            var category = GetCategory();
            var expected = new LocalizedCategory()
            {
                Id = 1,
                Name = "nameRU"
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var categoryLocalizer = new CategoryLocalizer();

            // Act
            var actual = categoryLocalizer.Localize(category);

            // Assert
            AssertLocalizedCategories(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleCategoryInUkrainian()
        {
            // Arrange
            var category = GetCategory();
            var expected = new LocalizedCategory()
            {
                Id = 1,
                Name = "nameUA"
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var categoryLocalizer = new CategoryLocalizer();

            // Act
            var actual = categoryLocalizer.Localize(category);

            // Assert
            AssertLocalizedCategories(expected, actual);
        }
        
        [Fact]
        public void LocalizeSingleCategoryInEnglish()
        {
            // Arrange
            var category = GetCategory();
            var expected = new LocalizedCategory()
            {
                Id = 1,
                Name = "nameEN"
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var categoryLocalizer = new CategoryLocalizer();

            // Act
            var actual = categoryLocalizer.Localize(category);

            // Assert
            AssertLocalizedCategories(expected, actual);
        }

        #endregion

        #region IEnumerable<Category>

        [Fact]
        public void LocalizeListOfCategoriesInRussian()
        {
            // Arrange
            var category = GetEnumerableOfCategories();
            var expected = new List<LocalizedCategory>()
            {
                new LocalizedCategory() { Id = 1, Name = "nameRU" },
                new LocalizedCategory() { Id = 2, Name = "nameRU2" }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            var categoryLocalizer = new CategoryLocalizer();

            // Act
            var actual = categoryLocalizer.Localize(category);

            // Assert
            AssertLocalizedCategories(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfCategoriesInUkrainian()
        {
            // Arrange
            var category = GetEnumerableOfCategories();
            var expected = new List<LocalizedCategory>()
            {
                new LocalizedCategory() { Id = 1, Name = "nameUA" },
                new LocalizedCategory() { Id = 2, Name = "nameUA2" }
            };
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA");
            var categoryLocalizer = new CategoryLocalizer();

            // Act
            var actual = categoryLocalizer.Localize(category);

            // Assert
            AssertLocalizedCategories(expected, actual);
        }
        
        [Fact]
        public void LocalizeListOfCategoriesInEnglish()
        {
            // Arrange
            var category = GetEnumerableOfCategories();
            var expected = new List<LocalizedCategory>()
            {
                new LocalizedCategory() { Id = 1, Name = "nameEN" },
                new LocalizedCategory() { Id = 2, Name = "nameEN2" }
            };
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            var categoryLocalizer = new CategoryLocalizer();

            // Act
            var actual = categoryLocalizer.Localize(category);

            // Assert
            AssertLocalizedCategories(expected, actual);
        }

        #endregion
    }
}