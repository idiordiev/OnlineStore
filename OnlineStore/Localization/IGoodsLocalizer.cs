using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    /// <summary>
    /// An interface that represents localizer(Goods -> LocalizedGoods).
    /// TODO: total rework using patterns
    /// </summary>
    public interface IGoodsLocalizer
    {
        IEnumerable<LocalizedGoods> GetAll();
        
        IEnumerable<LocalizedGoods> Find(string request);
    }
}