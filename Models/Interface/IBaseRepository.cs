using MagniUniveristy.Models.ViewModel;
using System.Linq;

namespace MagniUniveristy.Models.Interface
{
    public interface IBaseRepository <T> where T : class
    {
        T Find(int id);
        IQueryable<T> List();
        ValidationViewModel Add(T item, ValidationViewModel validation);
        ValidationViewModel Remove(T item, ValidationViewModel validation);
        ValidationViewModel Edit(T item, ValidationViewModel validation);
    }
}
