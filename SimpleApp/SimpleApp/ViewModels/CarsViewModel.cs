using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using SimpleApp.Helpers;
using SimpleApp.Models;
using SimpleApp.Services;
using SimpleApp.Views;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    public class CarsViewModel: BaseViewModel
    {

        #region Fields
        private IDataService<Car> service;

        private ObservableCollection<Car> items;
        private Car selectedItem;

        private IMainPage view;
        #endregion

        #region Properties
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
                SetProperty(ref items, value);
            }
        }

        public Car SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
            }
        }

        public Command DetailCarCommand { get; set; }
        public Command AddCarCommand { get; set; }
        public Command EditCarCommand { get; set; }
        #endregion

        public CarsViewModel(IMainPage view)
        {
            this.view = view;
            service = DependencyService.Get<IDataService<Car>>();
            DetailCarCommand = new Command<Car>(c => DoDetailCarCommand(c));
            AddCarCommand = new Command(DoAddCarCommand);
            EditCarCommand = new Command<Car>(c => DoEditCarCommand(c));
            ExecuteLoadCarsCommand();

            MessagingCenter.Subscribe<EditCarViewModel, Car>(this, "EditCar", async (obj, item) =>
            {
                await ExecuteLoadCarsCommand();
            });
        }

        private async Task ExecuteLoadCarsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Items = await Task.Run(() => new ObservableCollection<Car>(service.GetItems()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #region Commands
        private async void DoAddCarCommand(object obj)
        {
            await view.Navigation.PushAsync(new EditCarView(0));
            SelectedItem = null;
        }

        private async void DoDetailCarCommand(Car c)
        {
            await view.Navigation.PushAsync(new DetailCarView(c.Id));
            SelectedItem = null;
        } 

        private async void DoEditCarCommand(Car c)
        {
            await view.Navigation.PushAsync(new EditCarView(c.Id));
            SelectedItem = null;
        } 
        #endregion
    }
}
