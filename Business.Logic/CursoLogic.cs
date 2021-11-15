using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic: BusinessLogic
    {
        Data.Database.CursoAdapter CursoData;
        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();

        }
        public List<Curso> GetAll()
        {
            try
            {
                List<Curso> cursos = CursoData.GetAll();
                return cursos;
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los cursos.", ex);
                throw ExcepcionManejada;
            }
        }


        public Curso GetOne(int id)
        {
            try
            {
                Curso curso = CursoData.GetOne(id);
                return curso;
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el curso.", ex);
                throw ExcepcionManejada;
            }

        }

        public void Delete(int id)
        {
            try
            {
                CursoData.Delete(id);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso.", ex);
                throw ExcepcionManejada;
            }
        }


        public void Save(Curso curso)
        {
            try
            {
                CursoData.Save(curso);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar el curso.", ex);
                throw ExcepcionManejada;
            }
        }

        public List<Curso> GetAllxPlan(int id_plan, int id)
        {
            try
            {
                return CursoData.GetAllxPlan(id_plan, id);
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los cursos.", ex);
                throw ExcepcionManejada;
            }
        }
    }
}

