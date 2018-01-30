using SimpleApp.Helpers;
using SimpleApp.Models;
using SimpleApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    public class DetailCarViewModel: ObservableObjects
    {

        #region Fields
        private IDataService<Car> service;
        private Car model;
        #endregion

        #region Properties
        public Car Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }
        #endregion

        public DetailCarViewModel(int id)
        {
            service = DependencyService.Get<IDataService<Car>>() ?? throw new ArgumentNullException("Can't find 'IDataService<Car>'");
            Model = service.GetItem(id);
        }
    }
}
