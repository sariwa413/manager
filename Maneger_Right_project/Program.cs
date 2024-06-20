using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maneger_Right_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connctionString = "Data Source=SRV2\\PUPILS;Initial Catalog=BabyStore__DB;Integrated Security=True;Encrypt=False";
            DataAccess da = new DataAccess();
            da.InsertCategory(connctionString);
            da.InsertProduct(connctionString);
        

        }
    }
}
