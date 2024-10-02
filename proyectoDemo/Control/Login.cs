using proyectoDemo.Model;
using System;

namespace proyectoDemo.Control
{
    internal class Login
    {
        /// <summary>
        /// revisar usuario y contraseña
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ResultLogin(string username, string password)
        {
            var user = new Model.Users() { name = username };
            var userResult = new Repository().GetUsers(user);
            if (userResult != null)
            {
               if( password.Trim()== userResult.password.Trim() ) return true;
               else return false;
            } else return false;
        }

        /// <summary>
        /// Si no hay usuarios en la base crea uno por defecto
        /// </summary>
        internal void Inicialize()
        {

            var repository = new Repository();
            if (repository.GetUsers().Count == 0)
            {
                repository.SetUser("Admin", "123");
            }
        }
    }
}
