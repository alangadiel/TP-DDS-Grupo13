using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model;
using System.Linq;

namespace DONDE_INVIERTO.Service
{
    public class UserService
    {
        public Usuario Login(Usuario usuario)
        {
            var loggedUser = Context.Session.Query<Usuario>().Where(user => user.Username == usuario.Username
                    && user.Contrasenia == usuario.Contrasenia).ToList();
            if (loggedUser.Count > 0)
                return loggedUser[0];
            return null;
        }

        public static int GetUserId(string username)
        {
            return Context.Session.Query<Usuario>().Where(user => user.Username == username).First().Id;
        }
    }
}
