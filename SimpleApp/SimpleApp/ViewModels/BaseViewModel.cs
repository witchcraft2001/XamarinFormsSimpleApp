using SimpleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.ViewModels
{
    public class BaseViewModel: ObservableObjects
    {
        #region Fields
        bool isBusy = false;
        string title = string.Empty;
        #endregion

        #region Properties
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        } 
        #endregion
    }
}
