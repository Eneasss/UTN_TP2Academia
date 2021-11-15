using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        Data.Database.ComisionAdapter ComisionData;
        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();

        }
        public List<Comision> GetAll()
        {
            try
            {
                List<Comision> comisiones = ComisionData.GetAll();
                return comisiones;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las comision.", ex);
                throw ExcepcionManejada;
            }
        }
        
       public List<Comision> GetAllxID(int ID)
        {
            try
            {
                List<Comision> comisiones = ComisionData.GetAllxID(ID);
                return comisiones;
            }
            
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la comision.", ex);
                throw ExcepcionManejada;
            }
        }

        public Comision GetOne(int id)
        {
            try
            {
                Comision user = ComisionData.GetOne(id);
                return user;
            }
            
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la comision.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int id)
        {
            try
            {
                ComisionData.Delete(id);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la comision.", ex);
                throw ExcepcionManejada;
            }
        }


        public void Save(Comision comision)
        {
            try
            {
                ComisionData.Save(comision);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar la comision.", ex);
                throw ExcepcionManejada;
            }
        }
    }
}
