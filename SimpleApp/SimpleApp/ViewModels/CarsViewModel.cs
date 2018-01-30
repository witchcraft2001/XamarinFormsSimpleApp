using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SimpleApp.Helpers;
using SimpleApp.Models;
using SimpleApp.Services;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    public class CarsViewModel: ObservableObjects
    {        
        private IDataService<Car> service;

        private ObservableCollection<Car> items;

        public ObservableCollection<Car> Items
        {
            get
            {
                if (items == null)
                {
                    items = new ObservableCollection<Car>();
                }
                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public CarsViewModel()
        {
            service = DependencyService.Get<IDataService<Car>>();
            items = new ObservableCollection<Car>(service.GetItems());
        }
    }
}
