using EstateDataAccess;
using EstateDataAccess.Repository;
using EstateModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EstateDataAccess.Repository.SqlRepository
{
    internal class OwnerRepository : SQLRepository<Owner>
    {

        public new Owner Create(Owner value)
        {
            throw new NotImplementedException();
        }

        public new Owner Update(Owner value)
        {
            throw new NotImplementedException();
        }
    }
}