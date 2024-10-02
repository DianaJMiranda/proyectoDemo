using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proyectoDemo.View
{
    public partial class Agenda : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter adapter=new SqlDataAdapter();
        public Agenda()
        {
            InitializeComponent();
            LoadData();
            
            dataGridView1.Columns[0].ReadOnly = true;
        }

       
       
        /// <summary>
        /// Llena los datos en el datagridview
        /// </summary>
        private void LoadData()
        {
            var data = new Control.Agenda().GetData(adapter);
            bindingSource1.DataSource = data;
            dataGridView1.DataSource = bindingSource1;
        }

        private void cmdUsersAdmin_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            this.Hide(); //oculta la forma actual
            user.Show(); // muestra la forma2
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //Guarda los datos
            var mensaje= new Control.Agenda().SetRow(txtName.Text,txtAddress.Text,txtSmartphone.Text,txtEmail.Text);
            LoadData();
            //limpiar los datos
            txtAddress.Text =string.Empty;
            txtSmartphone.Text =string.Empty;
            txtEmail.Text =string.Empty;
            txtName.Text =string.Empty;
            MessageBox.Show(mensaje);
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            new Control.Agenda().UpdateRows(adapter, bindingSource1 );
            LoadData();
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(CloseForm);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
