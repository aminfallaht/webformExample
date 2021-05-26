using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace webformExample
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=NEWNAMEORDI;Initial Catalog=amin;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonShow_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT PICAdress FROM DataBaseBook WHERE BookID={0}",dropDownListBook.SelectedValue);
            SqlCommand Command = new SqlCommand(query, connection);
            connection.Open();
            string path = Command.ExecuteScalar().ToString();
            //ImageView.Attributes.Clear();
            ImageView.ImageUrl = path;
            
        }

        protected void buttonSave_Click(object sender, EventArgs e)
        {
            string name = Image.PostedFile.FileName;
            if (name != "")
            {
                string BookID = dropDownListBook.SelectedValue;
                string fileName = string.Format("{0}.bmp", BookID);
                string path = "D:\\Amin Fallah\\codes\\webformExample\\webformExample\\Images\\";
                path = path + fileName;
                Image.PostedFile.SaveAs(path);
                string query = string.Format("Update DataBaseBook SET PICAdress ='{0}' WHERE BookID='{1}'", path, BookID);
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            else
            {
                labelmessage.Text = "select a file";
            }
        }
        protected void HTMLcreator(string url)
        {
            using (FileStream FS = new FileStream("D:\\Amin Fallah\\codes\\webformExample\\webformExample\\ShowImage\\ShowImage.htm", FileMode.Create))
            {
                using (StreamWriter W = new StreamWriter(FS))
                {
                }
            }
        }
    }
}

