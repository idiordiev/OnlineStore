using System.Collections.Generic;
using System.Globalization;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    public class CategoryLocalizer: ICategoryLocalizer
    {
        public LocalizedCategory Localize(Category category)
        {
            LocalizedCategory localizedCategory = new LocalizedCategory()
            {
                Id = category.Id
            };
            
            string culture = CultureInfo.CurrentCulture.ToString();

            switch (culture)
            {
                case "ua-UA":
                    localizedCategory.Name = category.NameUA;
                    break;
                case "ru-RU":
                    localizedCategory.Name = category.NameRU;
                    break;
                case "en-US":
                    localizedCategory.Name = category.NameEN;
                    break;
                default:
                    localizedCategory.Name = category.NameEN;
                    break;
            }

            return localizedCategory;

        }

        public List<LocalizedCategory> Localize(IEnumerable<Category> categories)
        {
            List<LocalizedCategory> localizedCategories = new List<LocalizedCategory>();

            foreach (var category in categories)
            {
                localizedCategories.Add(Localize(category));
            }

            return localizedCategories;
        }
    }
}