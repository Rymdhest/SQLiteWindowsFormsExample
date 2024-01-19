using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWindowsForms
{
    internal class Car
    {
        private string brand;
        private string model;
        private int price_USD;
        private double weight_tonnes;

        public Car(string brand, string model, int price_USD, double weight_tonnes)
        {
            this.Brand = brand;
            this.Model = model;
            this.Price_USD = price_USD;
            this.Weight_tonnes = weight_tonnes;
        }

        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public int Price_USD { get => price_USD; set => price_USD = value; }
        public double Weight_tonnes { get => weight_tonnes; set => weight_tonnes = value; }
    }
}
