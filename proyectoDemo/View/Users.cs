using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proyectoDemo.View
{
    public partial class Users : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        public Users()
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
            var data = new Control.Users().GetData(adapter);
            bindingSource1.DataSource = data;
            dataGridView1.DataSource = bindingSource1;
        }

        private void cmdPerson_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda();
            this.Hide(); //oculta la forma actual
            agenda.Show(); // muestra la forma2
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            new Control.Users().UpdateRows(adapter, bindingSource1);
            LoadData();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(CloseForm);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
