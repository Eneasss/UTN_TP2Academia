using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        Data.Database.UsuarioAdapter UsuarioData;
        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();

        }
        public List<Usuario> GetAll()
        {
            try
            {
                List<Usuario> usuarios = UsuarioData.GetAll();
                return usuarios;
            }


            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los usuarios.", ex);
                throw ExcepcionManejada;
            }
        }


        public Usuario GetOne(int id)
        {
            try
            {
                Usuario user = UsuarioData.GetOne(id);
                return user;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el usuario.", ex);
                throw ExcepcionManejada;
            }

        }

        public void Delete(int id)
        {
            try
            {
                UsuarioData.Delete(id);
            }

            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuario.", ex);
                throw ExcepcionManejada;
            }
        }


        public void Save(Usuario usuario)
        {
            try
            {
                UsuarioData.Save(usuario);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar el usuario.", ex);
                throw ExcepcionManejada;
            }
        }

        
         
         public Usuario Login(string user, string pass)
        {
            try
            {
                Usuario usuario = UsuarioData.Login(user, pass);
                return usuario;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los usuarios.", ex);
                throw ExcepcionManejada;
            }
        }
         
         

    }
}
