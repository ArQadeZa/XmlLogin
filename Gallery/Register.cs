using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallery
{
    public partial class Register : Form
    {
        public Point mouseLocation;
        public Register()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //show previous form
            Form1 form1 = new Form1();
            form1.Show();

            //close current form
            this.Close();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //hides labels
            lblReg.Visible = false;
            lblCreated.Visible = false;

            //displlays an error if any of the inputs are empty
            if (txtName.Text == "" || txtPassword.Text == "" || txtSurname.Text == "" || txtUsername.Text =="")
            {
                lblReg.Show();
                return;
            }

            //adds the users' account to the xml file
            login login = new login(txtUsername.Text, txtPassword.Text, txtName.Text, txtSurname.Text); 

            if (login.exist == true)
            {
                lblReg.Visible = true;
            }
            else
            {
                lblCreated.Visible = true;
            }

            //clear textboxes
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        // Move the form on mouseclick and mouse move
        
        private void Register_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void Register_MouseMove(object sender, MouseEventArgs e)
        {
           

            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
            }
        }
    }
}
