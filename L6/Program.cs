
using System;
using System.Globalization;

namespace FP
{
    internal partial class Freezer
    {
        private string brand;
        private int capacity;
        private double temperature;
        private bool isOn;
        private decimal price;

        private static int count;
        private static string category;

        static Freezer()
        {
            count = 0;
            category = "Household Appliances";
        }

        public Freezer() : this("Unknown", 0, 0, false, 0) { }

        public Freezer(string brand, int capacity)
            : this(brand, capacity, 0, false, 0)
        {
        }

        public Freezer(string brand, int capacity, double temperature,
                       bool isOn, decimal price)
        {
            this.brand = brand;
            this.capacity = capacity;
            this.temperature = temperature;
            this.isOn = isOn;
            this.price = price;

            count++;
        }

        public string GetBrand()
        {
            return brand;
        }

        public void SetBrand(string brand)
        {
            this.brand = brand;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        public void SetCapacity(int capacity)
        {
            this.capacity = capacity;
        }

        public double GetTemperature()
        {
            return temperature;
        }

        public void SetTemperature(double temperature)
        {
            this.temperature = temperature;
        }

        public bool GetIsOn()
        {
            return isOn;
        }

        public void SetIsOn(bool isOn)
        {
            this.isOn = isOn;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public void SetPrice(decimal price)
        {
            this.price = price;
        }
    }

    internal partial class Freezer
    {
        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine("Freezer is ON.");
        }

        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine("Freezer is OFF.");
        }

        public void ChangeTemperature(double newTemperature)
        {
            temperature = newTemperature;
            Console.WriteLine("Temperature changed.");
        }

        public void Modify(ref double newTemperature, ref bool power)
        {
            if (newTemperature > 0)
            {
                newTemperature = 0;
            }

            temperature = newTemperature;
            isOn = power;
        }

        public static int GetCount()
        {
            return count;
        }

        public static string GetCategory()
        {
            return category;
        }

        public static void SetCategory(string newCategory)
        {
            category = newCategory;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Brand: {brand}, " +
                   $"Capacity: {capacity} L, " +
                   $"Temperature: {temperature} C, " +
                   $"Power: {(isOn ? "ON" : "OFF")}, " +
                   $"Price: {price}$";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter category: ");
            string category = Console.ReadLine()!;

            Freezer.SetCategory(category);

            Freezer[] freezers = new Freezer[5];

            for (int i = 0; i < freezers.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"FREEZER {i + 1}");

                Console.Write("Enter brand: ");
                string brand = Console.ReadLine()!;

                Console.Write("Enter capacity: ");
                int capacity = int.Parse(Console.ReadLine()!);

                Console.Write("Enter temperature: ");
                double temperature = double.Parse(
                    Console.ReadLine()!, CultureInfo.InvariantCulture);

                Console.Write("Is freezer ON? (true/false): ");
                bool isOn = bool.Parse(Console.ReadLine()!);

                Console.Write("Enter price: ");
                decimal price = decimal.Parse(
                    Console.ReadLine()!, CultureInfo.InvariantCulture);

                freezers[i] = new Freezer(
                    brand, capacity, temperature, isOn, price);
            }

            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine("ALL FREEZERS");

            for (int i = 0; i < freezers.Length; i++)
            {
                Console.WriteLine($"Freezer {i + 1}:");
                Console.WriteLine(freezers[i].ToString());
                Console.WriteLine();
            }

            Freezer freezer = freezers[0];

            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("=========================");
                Console.WriteLine("FREEZER MENU");
                Console.WriteLine("1. Show freezer information");
                Console.WriteLine("2. Turn ON");
                Console.WriteLine("3. Turn OFF");
                Console.WriteLine("4. Change temperature");
                Console.WriteLine("5. Modify using ref");
                Console.WriteLine("6. Show static information");
                Console.WriteLine("0. Exit");

                Console.Write("Your choice: ");
                choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        freezer.Print();
                        break;

                    case 2:
                        freezer.TurnOn();
                        break;

                    case 3:
                        freezer.TurnOff();
                        break;

                    case 4:
                        Console.Write("Enter new temperature: ");
                        double newTemperature = double.Parse(
                            Console.ReadLine()!, CultureInfo.InvariantCulture);

                        freezer.ChangeTemperature(newTemperature);
                        break;

                    case 5:
                        Console.Write("Enter temperature: ");
                        double temp = double.Parse(
                            Console.ReadLine()!, CultureInfo.InvariantCulture);

                        Console.Write("Enter power (true/false): ");
                        bool power = bool.Parse(Console.ReadLine()!);

                        freezer.Modify(ref temp, ref power);

                        Console.WriteLine("Modified temperature: " + temp);
                        Console.WriteLine("Modified power: " + power);
                        break;

                    case 6:
                        Console.WriteLine("Category: " +
                            Freezer.GetCategory());

                        Console.WriteLine("Created objects: " +
                            Freezer.GetCount());
                        break;

                    case 0:
                        Console.WriteLine("Program finished.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 0);
        }
    }
}
