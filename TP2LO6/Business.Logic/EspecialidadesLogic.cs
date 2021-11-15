using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadesLogic : BusinessLogic
    {
        Data.Database.EspecialidadesAdapter EspecialidadData;
        public EspecialidadesLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadesAdapter();

        }
        public List<Especialidad> GetAll()
        {
            try
            {
                List<Especialidad> especialidades = EspecialidadData.GetAll();
                return especialidades;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las especialidades.", ex);
                throw ExcepcionManejada;
            }
        }


        public Especialidad GetOne(int id)
        {
            try
            {
                Especialidad especialidad = EspecialidadData.GetOne(id);
                return especialidad;
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la especialidad.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int id)
        {
            try
            {
                EspecialidadData.Delete(id);
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la especialidad.", ex);
                throw ExcepcionManejada;
            }
        }


        public void Save(Especialidad especialidad)
        {
            try
            {
                EspecialidadData.Save(especialidad);
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar la especialidad.", ex);
                throw ExcepcionManejada;
            }
        }
    }
}
