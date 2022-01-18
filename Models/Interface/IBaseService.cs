using MagniUniveristy.Models.ViewModel;
using System.Linq;

namespace MagniUniveristy.Models.Interface
{
    public interface IBaseService<T> where T : class
    {
        ValidationViewModel Add(T item, ValidationViewModel validation);
        ValidationViewModel Remove(T item, ValidationViewModel validation);
        ValidationViewModel Edit(T item, ValidationViewModel validation);
    }
}
