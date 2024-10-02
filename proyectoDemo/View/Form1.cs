
using proyectoDemo.View;
using System;
using System.Windows.Forms;

namespace proyectoDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Control.Login().Inicialize();//revisa si hay usuarios existentes
        }

        private void cmdLoginIn_Click(object sender, EventArgs e)
        {
            bool sucess=new Control.Login().ResultLogin(txtUser.Text, txtPassword.Text);
            if (sucess)
            {
                MessageBox.Show("Login exitoso!");
                
                Agenda agenda = new Agenda();
                this.Hide(); //oculta la forma actual
                
                agenda.Show(); // muestra la forma2
                
            }
            else MessageBox.Show("Usuario o contraseña incorrecto");
        }
    }
}
