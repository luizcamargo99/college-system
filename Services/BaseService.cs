using MagniUniveristy.DAL;
using MagniUniveristy.DAL.Repositories;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniUniveristy
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        IBaseRepository<T> _repository;

        public BaseService()
        {
            _repository = new BaseRepository<T>(new CollegeContext());
        }

        public ValidationViewModel Add(T item, ValidationViewModel validation)
        {
            return _repository.Add(item, validation);
        }

        public ValidationViewModel Remove(T item, ValidationViewModel validation)
        {
            return _repository.Remove(item, validation);
        }

        public ValidationViewModel Edit(T item, ValidationViewModel validation)
        {
            return _repository.Edit(item, validation);
        }
    }
}