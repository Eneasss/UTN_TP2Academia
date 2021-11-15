using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        Data.Database.PlanAdapter PlanData;
        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();

        }
        public List<Plan> GetAll()
        {
            try
            {
                List<Plan> planes = PlanData.GetAll();
                return planes;
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los planes.", ex);
                throw ExcepcionManejada;
            }
        }


        public Plan GetOne(int id)
        {
            try
            {
                Plan user = PlanData.GetOne(id);
                return user;
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el plan.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Delete(int id)
        {
            try
            {
                PlanData.Delete(id);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar los planes.", ex);
                throw ExcepcionManejada;
            }
        }


        public void Save(Plan plan)
        {
            try
            {
                PlanData.Save(plan);
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar el plan.", ex);
                throw ExcepcionManejada;
            }

        }
    }
}
