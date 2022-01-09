using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    public interface ICategoryLocalizer
    {
        LocalizedCategory Localize(Category category);

        List<LocalizedCategory> Localize(IEnumerable<Category> categories);
    }
}