using DataAccessLayer;
using PracticalAddressBook;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Bussiness
    {
        // DataSet d = new DataSet();
        DataAccess dacc = new DataAccess();
        public int InsertAddress(Address std)
        {

            return (dacc.InsertAddress(std));
        }
        public DataSet returndataset()
        {


            return dacc.returndataset();

        }
        public int UpdateAddress(Address std)
        {
            return (dacc.UpdataAddress(std));

        }
        public int DeleteAddress(int sid)
        {
            return (dacc.DeleteAddress(sid));
        }
        public DataRow searchAddress(string lastName)
        {

            return (dacc.searchAddress(lastName));
        }
    }
}
