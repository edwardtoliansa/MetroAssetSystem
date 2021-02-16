using Metro_Asset_System.Context;
using Metro_Asset_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Repositories.Data
{
    public class RequestRepository : GeneralRepository<Request, MyContext, int>
    {
        public RequestRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
