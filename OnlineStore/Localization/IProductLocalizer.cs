using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    public interface IProductLocalizer
    {
        LocalizedProduct Localize(Product product);

        LocalizedProduct Localize(Product product, User user);

        List<LocalizedProduct> Localize(IEnumerable<Product> products);

        List<LocalizedProduct> Localize(IEnumerable<Product> products, User user);
    }
}