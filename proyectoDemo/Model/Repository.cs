using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace proyectoDemo.Model
{
    internal class Repository
    {
        private string _strConnection
        {
            get { return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Diana Lavara\source\repos\proyectoDemo\proyectoDemo\Model\DBPrincipal.mdf"";Integrated Security=True;Context Connection=False"; }
        }
        /// <summary>
        /// Consulta el usuario en base al name
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Users GetUsers(Users user) {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection= new SqlConnection( _strConnection );
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="Select id, name,password from Users where name ='"+user.name.Trim()+"'";
            cmd.Connection.Open();
            var reader=cmd.ExecuteReader();

            if (reader.Read()) { 
            return new Users() { 
                Id = int.Parse(reader[0].ToString()), 
                name= reader[1].ToString(),
                password = reader[2].ToString() };
            }
            return null;
        }

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>Lista de modelo users</returns>
        internal List<Users> GetUsers()
        {
            SqlCommand cmd = new SqlCommand();
            List<Users> users = new List<Users>();
            cmd.Connection = new SqlConnection(_strConnection);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select id, name,password from Users ";
            cmd.Connection.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add (new Users()
                {
                    Id = int.Parse(reader[0].ToString()),
                    name = reader[1].ToString(),
                    password = reader[2].ToString()
                });
            }
            cmd.Connection.Close();
            return users;
        }

        /// <summary>
        /// Genera el alta de un usuario
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        internal bool SetUser(string name, string password)
        {
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = new SqlConnection(_strConnection);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Users( name,password) values( '"+name 
                +"','"+password+"')";
            cmd.Connection.Open();
            bool success= cmd.ExecuteNonQuery()>0? true:false ;
            cmd.Connection.Close();
            return success;
        }

        /// <summary>
        /// Consulta los registros de la tabla Person
        /// </summary>
        /// <returns>DataTable </returns>
        internal DataTable GetPersons(SqlDataAdapter adapter)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            cmd.Connection = new SqlConnection(_strConnection);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select id as ID, name as Nombre,address as Dirección, smartphone as [Num. Celular],email as Email from Person ";
          adapter.SelectCommand=cmd;
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Inserta el registro a la tabla  Person
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="smartphone"></param>
        /// <param name="email"></param>
        /// <returns>mensaje de resultado</returns>
        internal string SetPerson(string name, string address, string smartphone, string email)
        {

            SqlConnection con = new SqlConnection(_strConnection);
            
                string mensaje=string.Empty;//cadena vacía
                string query = "INSERT INTO Person (name, address, smartphone, email) " +
                    "VALUES ('"+name.Trim()+"','"+address+"','"+smartphone+"','"+email+"')";
                SqlCommand cmd = new SqlCommand(query, con);
               
                
                cmd.Connection.Open();
                if (cmd.ExecuteNonQuery() > 0) mensaje= "Se agrego el contacto";
                else mensaje= "Error al agregar contacto";
                cmd.Connection.Close();
                return mensaje;
            
        }

        /// <summary>
        /// Guarda los cambios o elimina el registro según el caso
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="bindingSource"></param>
        /// <returns>True si es correcto</returns>
        internal bool UpdatePersons(SqlDataAdapter adapter, BindingSource bindingSource)
        {
            string query = "Select id as ID, name as Nombre,address as Dirección, smartphone as [Num. Celular],email as Email from Person";
            SqlDataAdapter da = new SqlDataAdapter(query, new SqlConnection(_strConnection));

            // Utilizamos el CommandBuilder para generar los comandos de INSERT, UPDATE y DELETE
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            // Obtenemos los cambios realizados en el DataTable enlazado al BindingSource
            DataTable changes = ((DataTable)bindingSource.DataSource).GetChanges();

            if (changes != null)
            {
                da.UpdateCommand = commandBuilder.GetUpdateCommand();
                
                da.DeleteCommand = commandBuilder.GetDeleteCommand();

                // Aplicamos los cambios a la base de datos
                da.Update(changes);

                // Aceptamos los cambios en el DataTable
                ((DataTable)bindingSource.DataSource).AcceptChanges();

               return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Consulta los usuarios
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns>DataTable</returns>
        internal DataTable GetUsers(SqlDataAdapter adapter)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            cmd.Connection = new SqlConnection(_strConnection);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select id as ID, name as Nombre, password as Password from Users ";
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;
        }

        internal bool UpdateUses(SqlDataAdapter adapter, BindingSource bindingSource)
        {
            string query = "Select id as ID, name as Nombre, password as Password from Users ";
            SqlDataAdapter da = new SqlDataAdapter(query, new SqlConnection(_strConnection));

            // Utilizamos el CommandBuilder para generar los comandos de INSERT, UPDATE y DELETE
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            // Obtenemos los cambios realizados en el DataTable enlazado al BindingSource
            DataTable changes = ((DataTable)bindingSource.DataSource).GetChanges();

            if (changes != null)
            {
                da.UpdateCommand = commandBuilder.GetUpdateCommand();
                da.UpdateCommand= commandBuilder.GetInsertCommand();
                da.DeleteCommand = commandBuilder.GetDeleteCommand();

                // Aplicamos los cambios a la base de datos
                da.Update(changes);

                // Aceptamos los cambios en el DataTable
                ((DataTable)bindingSource.DataSource).AcceptChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
