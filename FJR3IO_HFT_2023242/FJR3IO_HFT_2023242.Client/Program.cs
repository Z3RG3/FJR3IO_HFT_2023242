using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using ConsoleTools;
using FJR3IO_HFT_2023242.Models;

namespace FJR3IO_HFT_2023242.Client
{
    internal class Program
    {
        static RestService rest;

        static void Update(string data)
        {
            if (data == "Motorcycle")
            {
                Console.Write("Enter motorcycle ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Motorcycle motorcycle = rest.Get<Motorcycle>(id, "api/motorcycle");
                Console.Write($"[UPDATE] Enter new motorcycle model (old: {motorcycle.Model}): ");
                string model = Console.ReadLine();
                Console.Write($"[UPDATE] Enter new manufacturing year (old: {motorcycle.ManufacturingYear}): ");
                int manufacturingYear = int.Parse(Console.ReadLine());
                Console.Write($"[UPDATE] Enter new manufacturer ID (old: {motorcycle.ManufacturerID}): ");
                int manufacturerID = int.Parse(Console.ReadLine());
                Console.Write($"[UPDATE] Enter new garage ID (old: {motorcycle.GarageID}): ");
                int garageID = int.Parse(Console.ReadLine());

                motorcycle.Model = model;
                motorcycle.ManufacturingYear = manufacturingYear;
                motorcycle.ManufacturerID = manufacturerID;
                motorcycle.GarageID = garageID;

                rest.Put(motorcycle, "api/motorcycle");
            }
            else if (data == "Manufacturer")
            {
                Console.Write("Enter manufacturer ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Manufacturer manufacturer = rest.Get<Manufacturer>(id, "api/manufacturer");
                Console.Write($"[UPDATE] Enter new manufacturer name (old: {manufacturer.ManufacturerName}): ");
                string name = Console.ReadLine();
                manufacturer.ManufacturerName = name;
                manufacturer.ManufacturerID = id;
                rest.Put(manufacturer, "api/manufacturer");
            }
            else if (data == "Garage")
            {
                Console.Write("Enter garage ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Garage garage = rest.Get<Garage>(id, "api/garage");
                Console.Write($"[UPDATE] Enter new garage name (old: {garage.GarageName}): ");
                string name = Console.ReadLine();
                garage.GarageName = name;
                garage.GarageID = id;
                rest.Put(garage, "api/garage");
            }
        }

        static void Create(string data)
        {
            if (data == "Motorcycle")
            {
                Console.Write("Enter motorcycle model: ");
                string model = Console.ReadLine();
                Console.Write("Enter manufacturing year: ");
                int manufacturingYear = int.Parse(Console.ReadLine());
                Console.Write("Enter manufacturer ID: ");
                int manufacturerID = int.Parse(Console.ReadLine());
                Console.Write("Enter garage ID: ");
                int garageID = int.Parse(Console.ReadLine());
                rest.Post(new Motorcycle()
                {
                    Model = model,
                    ManufacturingYear = manufacturingYear,
                    ManufacturerID = manufacturerID,
                    GarageID = garageID
                }, "api/motorcycle");
            }
            else if (data == "Manufacturer")
            {
                Console.Write("Enter manufacturer name: ");
                string name = Console.ReadLine();
                Console.Write("Enter manufacturer ID: ");
                int manufacturerID = int.Parse(Console.ReadLine());
                rest.Post(new Manufacturer()
                {
                    ManufacturerName = name,
                    ManufacturerID = manufacturerID
                }, "api/manufacturer");
            }
            else if (data == "Garage")
            {
                Console.Write("Enter garage name: ");
                string name = Console.ReadLine();
                Console.Write("Enter garage ID: ");
                int garageID = int.Parse(Console.ReadLine());
                rest.Post(new Garage()
                {
                    GarageName = name,
                    GarageID = garageID
                }, "api/garage");
            }
        }

        static void Delete(string data)
        {
            if (data == "Motorcycle")
            {
                Console.Write("Enter motorcycle ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "api/motorcycle");
            }
            else if (data == "Manufacturer")
            {
                Console.Write("Enter manufacturer ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "api/manufacturer");
            }
            else if (data == "Garage")
            {
                Console.Write("Enter garage ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "api/garage");
            }
        }

        static void List(string data)
        {
            if (data == "Motorcycle")
            {
                List<Motorcycle> motorcycles = rest.Get<Motorcycle>("api/motorcycle");
                foreach (var motorcycle in motorcycles)
                {
                    Console.WriteLine($"[{motorcycle.MotorcycleID}] - {motorcycle.Model}");
                }
            }
            else if (data == "Manufacturer")
            {
                List<Manufacturer> manufacturers = rest.Get<Manufacturer>("api/manufacturer");
                foreach (var manufacturer in manufacturers)
                {
                    Console.WriteLine($"[{manufacturer.ManufacturerID}] - {manufacturer.ManufacturerName}");
                }
            }
            else if (data == "Garage")
            {
                List<Garage> garages = rest.Get<Garage>("api/garage");
                foreach (var garage in garages)
                {
                    Console.WriteLine($"[{garage.GarageID}] - {garage.GarageName}");
                }
            }
            Console.ReadLine();
        }

        // Non-Crud methods
        // vegre mukodnek, csak elfelejtettem megírni őket
        // 1
        static void GetMotorcycleNumberByManufacturer()
        {
            Console.Write("Enter manufacturer name to count motorcycles: ");
            string name = Console.ReadLine();
            Console.Write("\nNumber of motorcycles: ");
            var result = rest.GetSingle<int>($"/Stat/GetMotorcycleNumberByManufacturer/{name}");
            Console.WriteLine(result);
            Console.ReadLine();
        }
        // 2
        static void GetMotorcycleNumberByYear()
        {
            Console.Write("Enter year to count motorcycles: ");
            string year = Console.ReadLine();
            Console.Write("\nNumber of motorcycles: ");
            var result = rest.GetSingle<int>($"/Stat/GetMotorcycleNumberByYear/{year}");
            Console.WriteLine(result);
            Console.ReadLine();
        }
        // 3
        static void GetMotorcycleModelByManufacturer()
        {
            Console.Write("Enter manufacturer to list motorcycles: ");
            string name = Console.ReadLine();
            var result = rest.Get<string>($"/Stat/GetMotorcycleModelByManufacturer/{name}");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        // 4
        static void GetMotorcycleModelByGarageName()
        {
            Console.Write("Enter garage to list motorcycles: ");
            string garageName = Console.ReadLine();
            var result = rest.Get<string>($"/Stat/GetMotorcycleModelByGarageName/{garageName}");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        // 5
        static void GetGarageNameByManufacturerName()
        {
            Console.Write("Enter manufacturer name to list garages: ");
            string name = Console.ReadLine();
            var result = rest.Get<string>($"/Stat/GetGarageNameByManufacturerName/{name}");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            // Menu settings
            rest = new RestService("http://localhost:22181/");
          
            var motorcycleSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Motorcycle"))
                .Add("Create", () => Create("Motorcycle"))
                .Add("Delete", () => Delete("Motorcycle"))
                .Add("Update", () => Update("Motorcycle"))
                .Add("Exit", ConsoleMenu.Close);

            var manufacturerSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Manufacturer"))
                .Add("Create", () => Create("Manufacturer"))
                .Add("Delete", () => Delete("Manufacturer"))
                .Add("Update", () => Update("Manufacturer"))
                .Add("Exit", ConsoleMenu.Close);

            var garageSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Garage"))
                .Add("Create", () => Create("Garage"))
                .Add("Delete", () => Delete("Garage"))
                .Add("Update", () => Update("Garage"))
                .Add("Exit", ConsoleMenu.Close);

            var statMenu = new ConsoleMenu(args, level: 1)
                .Add("GetMotorcycleNumberByManufacturer", () => GetMotorcycleNumberByManufacturer())
                .Add("GetMotorcycleNumberByYear", () => GetMotorcycleNumberByYear())
                .Add("GetMotorcycleModelByManufacturer", () => GetMotorcycleModelByManufacturer())
                .Add("GetMotorcycleModelByGarageName", () => GetMotorcycleModelByGarageName())
                .Add("GetGarageNameByManufacturerName", () => GetGarageNameByManufacturerName())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Motorcycles", () => motorcycleSubmenu.Show())
                .Add("Manufacturers", () => manufacturerSubmenu.Show())
                .Add("Garages", () => garageSubmenu.Show())
                .Add("Exit", ConsoleMenu.Close);
             menu.Show();
        }
    }
}
