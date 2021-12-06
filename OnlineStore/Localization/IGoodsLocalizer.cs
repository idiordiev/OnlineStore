using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Localization
{
    /// <summary>
    /// An interface that represents localizer(Goods -> LocalizedGoods).
    /// </summary>
    public interface IGoodsLocalizer
    {
        IEnumerable<LocalizedGoods> GetAll(int cultureId);
        
        IEnumerable<LocalizedGoods> Find(string request, int cultureId);
    }
}