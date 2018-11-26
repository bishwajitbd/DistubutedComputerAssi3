using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Client authentication that web service is provided. 
        String Auth1 = "Mark";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //comsume implementation code
        protected void btnGetPerson_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePerson.ServicePersonClient client = new ServicePerson.ServicePersonClient();

                ServicePerson.Person person = client.GetPerson(Convert.ToInt32(txtID.Text), Auth1);

                txtName.Text = person.Name;
                txtGender.Text = person.Gender;
                txtDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
                lblMessage.Text = "Person's data retrieved";
            }
            catch (Exception ex)
            {
                txtName.Text = null;
                txtGender.Text = null;
                txtDateOfBirth.Text = null;
                lblMessage.Text = "Service is not working";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePerson.Person person = new ServicePerson.Person();
                person.Id = Convert.ToInt32(txtID.Text);
                person.Name = txtName.Text;
                person.Gender = txtGender.Text;
                person.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);

                ServicePerson.ServicePersonClient client = new
                    ServicePerson.ServicePersonClient();
                client.SavePerson(person, Auth1);

                lblMessage.Text = "Person's data saved";
                txtName.Text = null;
                txtGender.Text = null;
                txtDateOfBirth.Text = null;
            }
            catch
            {
                txtName.Text = null;
                txtGender.Text = null;
                txtDateOfBirth.Text = null;
                lblMessage.Text = "Service is not working";
            }
        }
    }
}