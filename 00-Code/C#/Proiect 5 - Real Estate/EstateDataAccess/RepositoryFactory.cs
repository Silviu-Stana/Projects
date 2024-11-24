using EstateDataAccess.Repository;
using EstateDataAccess.Repository.SqlRepository;
using EstateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstateDataAccess
{
    public enum RepositoryType
    {
        Sql = 1, Json = 2
    }

    public class RepositoryFactory
    {
        public static EstateRepository CreateEstateRepository()
        {
            return new EstateRepository();
        }
        public static PictureRepository CreatePictureRepository()
        {
            return new PictureRepository();
        }

        public static OwnerRepository CreateOwnerRepository()
        {
            return new OwnerRepository();
        }
    }
}