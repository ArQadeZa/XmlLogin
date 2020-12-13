using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Gallery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        // Move the form on mouseclick and mouse move
        public Point mouseLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
            }
        }
        // Move the form on mouseclick and mouse move

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login login = new login(txtUsername.Text,txtPassword.Text);
            //if the account doesnt exist it displays an error
            if (login.valid)
            {
                lblLoggedIn.Show();
                lblLogin.Hide();
            }
            else
            {
                lblLoggedIn.Hide();
                lblLogin.Visible = true;
            }

            //if the login is empty it displays that the values are incorrect
            if (!login.valid)
            {
                lblLogin.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //closes the application
            Application.Exit();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //opens the register form
            Register register = new Register();
            register.Show();

            //hides the login form
            this.Hide();
        }
    }
}
