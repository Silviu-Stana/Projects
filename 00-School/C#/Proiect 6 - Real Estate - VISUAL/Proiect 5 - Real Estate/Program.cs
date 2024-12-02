using System;
using System.Collections.Generic;
using EstateModels;
using EstateDataAccess;
using System.Windows.Forms;
using EstateDataAccess.Repository.SqlRepository;
using System.IO;
using System.Configuration;

namespace EstateConsoleUI
{
    internal class Program
    {
        static EstateRepository Estates = RepositoryFactory.CreateEstateRepository();
        static EstateForms form;

        static void FindPicuresFolderPathLocation()
        {
            // Base directory of the running application
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine with the relative path to your file
            string relativePath = @"Pictures\";
            string fullPath = Path.Combine(baseDirectory, relativePath);

            ConfigurationManager.AppSettings["PicturesFolderPath"] = fullPath;

            Console.WriteLine("Full Path: " + fullPath);
        }

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                FindPicuresFolderPathLocation();



                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                form = new EstateForms();
                Application.Run(form);

                //INSERT
                //Estates.Create(new Estate
                //{
                //    Name = "Casa 2",
                //    Address = "Strada 2",
                //    Price = 200000,
                //    CreateDate = DateTime.Now
                //});

                //UPDATE
                Estates.Update(new Estate
                {
                    Id = 2,
                    Name = "Casa 3",
                    Address = "Strada 3",
                    Price = 300000,
                    CreateDate = DateTime.Now
                });

                //GET BY ID
                Console.WriteLine("GET BY ID");
                Estate estate1 = Estates.GetById(2);

                if (estate1 != null)
                {
                    Console.WriteLine($"Estate ID: {estate1.Id}");
                    Console.WriteLine($"Name: {estate1.Name ?? "Name is null or not found"}");
                    Console.WriteLine($"Address: {estate1.Address ?? "Name is null or not found"}");
                    Console.WriteLine($"Price: {estate1.Price}");
                    Console.WriteLine($"Create Date: {estate1.CreateDate}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("No estate found with the given ID.");
                }

                Estates.Delete(1006);

                //GET ALL
                Console.WriteLine("GET ALL");
                List<Estate> estates = Estates.GetAll();
                foreach (var estate in estates)
                {
                    Console.WriteLine($"Estate ID: {estate.Id}");
                    Console.WriteLine($"Name: {estate.Name ?? "Name is null or not found"}");
                    Console.WriteLine($"Address: {estate.Address ?? "Name is null or not found"}");
                    Console.WriteLine($"Price: {estate.Price}");
                    Console.WriteLine($"Create Date: {estate.CreateDate}");
                    Console.WriteLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
