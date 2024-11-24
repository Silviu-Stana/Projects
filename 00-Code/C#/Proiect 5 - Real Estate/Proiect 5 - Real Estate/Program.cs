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
                EstateRepository estateRepository = new EstateRepository();
                Estate estate = estateRepository.GetById(2);
                Console.WriteLine($"Name: {estate.Name}");

                PictureRepository pictureRepository = new PictureRepository();
                Picture picture = pictureRepository.GetById(1);
                Console.WriteLine($"Picture Date: {picture.CreateDate}");


                OwnerRepository ownerRepository = new OwnerRepository();
                Owner owner = ownerRepository.GetById(1);
                Console.WriteLine($"Owner Name: {picture.CreateDate}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
