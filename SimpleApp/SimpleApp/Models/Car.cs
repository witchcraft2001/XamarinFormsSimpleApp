using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Models
{
    public class Car: BaseModel
    {
        private String model;
        private String vin;
        private Int16 year;
        private Int32 mileage;
        private String description;

        public string Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }

        public Int16 Year
        {
            get { return year; }
            set { SetProperty(ref year, value); }
        }

        public Int32 Mileage
        {
            get { return mileage; }
            set { SetProperty(ref mileage, value); }
        }

        public string Vin
        {
            get { return vin; }
            set { SetProperty(ref vin, value); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
