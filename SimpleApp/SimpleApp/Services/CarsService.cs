﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SimpleApp.Models;
using SimpleApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(CarsService))]
namespace SimpleApp.Services
{
    public class CarsService: IDataService<Car>
    {
        private static List<Car> items = new List<Car>();

        public CarsService()
        {
            SaveItem(new Car() { Model = "Kia Rio", Year = 2010, Mileage = 54000, Description = "This is my lovely car!"});
            SaveItem(new Car() { Model = "Kia Pikanto", Year = 2014, Mileage = 66000, Description = "This is my wife's car" });
        }

        public Car SaveItem(Car item)
        {
            if (item.Id == 0)
            {
                item.Id = (items.Count > 0) ? items.Max(c => c.Id) + 1 : 1;
                items.Add(item);
            } else
            {
                items.RemoveAt(items.FindIndex(c => c.Id == item.Id));
                items.Add(item);
            }
            return item;
        }

        public bool DeleteItem(Car item) {
            return items.Remove(item);
        }

        public Car GetItem(int id) {
            return items.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Car> GetItems() {
            return items.OrderBy(c => c.Model).ToList();
        }
    }
}
