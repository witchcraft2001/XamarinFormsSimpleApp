using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Services
{
    public interface IDataService<T>
    {
        T SaveItem(T item);
        bool DeleteItem(T item);
        T GetItem(int id);
        IEnumerable<T> GetItems();
    }
}
