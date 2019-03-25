using BussinessLayer;
using PracticalAddressBook;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentaionLayer
{
    public partial class Presentaion : System.Web.UI.Page
    {
        Bussiness b = new Bussiness();
        DataSet d = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertAddress_Click(object sender, EventArgs e)
        {
            txtAddressId.Text = "Id is auto generated";
            Address  address = new Address();
           
            address.FistName = txtFirstname.Text;
            address.LastName = TxtLastName.Text;
            address.EmailId = txtEmailId.Text;
            address.PhoneNo = txtPhoneNo.Text;

            int a = b.InsertAddress(address);
            if (a > 0)
            {
                //std.sname = txtsname.Text;
                //std.saddress = txtsaddress.Text;
                //std.scourse = txtscourse.Text;
           meslabel.Text   = "record inserted";
            }
            else
            {
                meslabel.Text = "record not inserted";
            }


        }

        

        protected void btndelete0_Click(object sender, EventArgs e)
        {
            d = b.returndataset();
            GridViewAddressBook.DataSource = d;
            GridViewAddressBook.DataBind();
            meslabel.Text = "data is being displayed";
        }

        protected void btnUpdateAddress_Click(object sender, EventArgs e)
        {
            Address address = new Address();
            address.AddressId = Convert.ToInt16(txtAddressId.Text);

            address.FistName = txtFirstname.Text;
            address.LastName = TxtLastName.Text;
            address.EmailId = txtEmailId.Text;
            address.PhoneNo = txtPhoneNo.Text;
            if ( b.UpdateAddress(address) != 0  ) 
            {
                //std.sname = txtsname.Text;
                //std.saddress = txtsaddress.Text;
                //std.scourse = txtscourse.Text;
                meslabel.Text = "record found and updated";
            }
            else
            {
                meslabel.Text = "record not found";
            }


        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            int ab = b.DeleteAddress(Convert.ToInt16(txtAddressId.Text));
            if (ab != 0)
            {
                meslabel.Text = "Record deleted";
            }
            else
            {
                meslabel.Text = "record not found";
            }

        }

       

        protected void btnfind_Click1(object sender, EventArgs e)
        {
            meslabel.Text = "i am facing some problems while displaying RowData in gridview";
            //if (b.searchAddress(txtlastnamefind.Text) != null)
            //{

            //    meslabel.Text = "data found";

            //    //GridViewAddressBook.DataSource = b.searchAddress(Convert.ToInt16(txtsid.Text));
            //    //GridViewAddressBook.DataBind();


            //}
            //else
            //{

            //    meslabel.Text = "data does not found";
            //}
        }
    }
}
    
