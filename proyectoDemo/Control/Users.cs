using proyectoDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoDemo.Control
{
    internal class Users
    {
        /// <summary>
        /// Gestona la consulta lo datos para la agenda
        /// </summary>
        /// <returns>DataTable de resultados</returns>
        internal System.Data.DataTable GetData(System.Data.SqlClient.SqlDataAdapter adapter)
        {
            return new Repository().GetUsers(adapter);
        }

        /// <summary>
        /// Administra las actualizaciones de usuarios
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="bindingSource1"></param>
        /// <returns></returns>
        internal string UpdateRows(SqlDataAdapter adapter, BindingSource bindingSource1)
        {
            if (new Repository().UpdateUses(adapter, bindingSource1))
                return "Cambios y eliminaciones actualizadas";
            else return "No hay actualizaciones por guardar";
        }
    }
}
