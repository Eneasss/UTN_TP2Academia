using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic: BusinessLogic
    {
        Data.Database.MateriaAdapter MateriaData;
        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();

        }
        public List<Materia> GetAll()
        {
            try
            {
                List<Materia> materias = MateriaData.GetAll();
                 return materias;
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las materias.", ex);
                throw ExcepcionManejada;
            }
        }
        public List<Materia> GetAllxID(int ID)
        {
            try
            {
                List<Materia> materias = MateriaData.GetAllxID(ID);
                return materias;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las materias.", ex);
                throw ExcepcionManejada;
            }
        }

        public Materia GetOne(int id)
        {
            try
            {
                Materia materia = MateriaData.GetOne(id);
                return materia;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la materia.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }


        public void Save(Materia materia)
        {
            try
            {
                MateriaData.Save(materia);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar las materias.", ex);
                throw ExcepcionManejada;
            }
        }

        public List<Materia> TraerTodosPorIdPlan(int ID)
        {
            try
            {
                return MateriaData.TraerTodosPorIdPlan(ID);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las materias.", ex);
                throw ExcepcionManejada;
            }
        }
    }
}
