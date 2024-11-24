using EstateDataAccess;
using EstateDataAccess.Repository;
using EstateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateDataAccess.Repository.SqlRepository
{
    internal class JsonRepository : SQLRepository<Estate>
    {
        public Owner Create(Owner value)
        {
            throw new NotImplementedException();
        }

        public Owner Update(Owner value)
        {
            throw new NotImplementedException();
        }
    }
}