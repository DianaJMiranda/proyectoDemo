using proyectoDemo.Model;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proyectoDemo.Control
{
    internal class Agenda
    {
        /// <summary>
        /// Gestona la consulta lo datos para la agenda
        /// </summary>
        /// <returns>DataTable de resultados</returns>
        internal System.Data.DataTable GetData(System.Data.SqlClient.SqlDataAdapter adapter)
        {
            return new Repository().GetPersons(adapter);
        }

        /// <summary>
        /// Gestiona el guardado de los datos
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="smartphone"></param>
        /// <param name="email"></param>
        internal string SetRow(string name, string address, string smartphone, string email)
        {
            return new Repository().SetPerson(name, address, smartphone, email);
        }

        /// <summary>
        /// Administra  lo datos a actualizar o borrar
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="bindingSource1"></param>
        internal string UpdateRows(SqlDataAdapter adapter, BindingSource bindingSource1)
        {
            if (new Repository().UpdatePersons(adapter, bindingSource1))
                return "Cambios y eliminaciones actualizadas";
            else return "No hay actualizaciones por guardar";
        }
    }
}
