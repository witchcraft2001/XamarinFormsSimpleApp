using SimpleApp.Helpers;
using SimpleApp.Models;
using SimpleApp.Services;
using SimpleApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    public class EditCarViewModel: BaseViewModel
    {

        #region Fields
        private IDataService<Car> service;
        private Car model;
        private IEditCarView view;
        #endregion

        #region Properties
        public Car Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }

        public Command SaveCommand { get; set; }
        #endregion

        #region ctor
        public EditCarViewModel(IEditCarView view, int id)
        {
            this.view = view;
            service = DependencyService.Get<IDataService<Car>>() ?? throw new ArgumentNullException("Can't find 'IDataService<Car>'");
            if (id == 0)
            {
                Title = "Новая машина";
                Model = new Car();
            }
            else
            {
                Model = service.GetItem(id);
                Title = Model.Model;
            }
            SaveCommand = new Command(DoSaveCommand);
        } 
        #endregion

        #region Commands
        private void DoSaveCommand(object obj)
        {
            Model = service.SaveItem(Model);
            MessagingCenter.Send(this, "EditCar", Model);
            view.CloseView();
        } 
        #endregion
    }
}
