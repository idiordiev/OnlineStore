using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    /// <summary>
    /// An interface that represents localizer(Product -> LocalizedProduct).
    /// TODO: total rework using patterns
    /// </summary>
    public interface IProductLocalizer
    {
        IEnumerable<LocalizedProduct> GetAll();
    }
}