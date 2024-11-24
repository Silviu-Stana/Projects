using System;
using System.Collections.Generic;
using EstateModels;
using EstateDataAccess.Repository.SqlRepository;
using EstateDataAccess;
using EstateDataAccess.Repository;
using System.IO;

namespace EstateConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SQLRepository<Estate> estateRepository = RepositoryFactory.CreateEstateRepository();

                int id = 2;
                Estate estate = estateRepository.GetById(id);
                Console.WriteLine($"Estate with ID {id} retrieved successfully:");
                Console.WriteLine($"Name: {estate.Name}");
                Console.WriteLine($"Address: {estate.Address}");
                Console.WriteLine($"Price: {estate.Price}");
                Console.WriteLine($"Type: {estate.Type}");
                Console.WriteLine($"CreateDate: {estate.CreateDate}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
