using PracticalAddressBook;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccess
    {

        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public SqlCommandBuilder cmdbuilder;
        public DataRow dr;
        DataSet ds = new DataSet();
        Address s = new Address();

        public SqlConnection getConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

            return con;
        }

        public void filldataintotable()
        {
            SqlConnection con = getConnection();
            da = new SqlDataAdapter("select * from AddressBook", con);
            da.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
            cmdbuilder = new SqlCommandBuilder(da);
            da.Fill(ds);

        }
        public DataSet returndataset()
        {
            SqlConnection con = getConnection();
            da = new SqlDataAdapter("select * from AddressBook", con);
            da.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
            cmdbuilder = new SqlCommandBuilder(da);
            da.Fill(ds);
            return ds;
        }

        public int InsertAddress(Address std)
        {
            filldataintotable();
            DataRow dr = ds.Tables[0].NewRow();
            dr["FirstName"] = std.FistName;
            dr["LastName"] = std.LastName;
            dr["EmailId"] = std.EmailId;
            dr["PhoneNo"] = std.PhoneNo;

            ds.Tables[0].Rows.Add(dr);

            return (da.Update(ds));

        }
        public int UpdataAddress(Address std)
        {
            filldataintotable();
            DataRow dr = ds.Tables[0].Rows.Find(std.AddressId);
            if (dr != null)
            {
                dr["FirstName"] = std.FistName;
                dr["LastName"] = std.LastName;
                dr["EmailId"] = std.EmailId;
                dr["PhoneNo"] = std.PhoneNo;
                return da.Update(ds);
            }
            else
                return 0;
        }

        public int DeleteAddress(int addressid)
        {

            filldataintotable();
            DataRow dr = ds.Tables[0].Rows.Find(addressid);
            if (dr != null)
            {
                dr.Delete();
                return da.Update(ds);

            }
            else
            {

                return 0;
            }


        }
        public DataRow searchAddress(string lastName)
        {
            filldataintotable();
            dr = ds.Tables[0].Rows.Find(lastName);
            if (dr != null)
            {
                return dr;

            }
            else
            {

                return dr;
            }



        }
    }
}
