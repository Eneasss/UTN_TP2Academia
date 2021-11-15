using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic
    {
        public PersonaAdapter DatosPersona { get; set; }

       

        public PersonaLogic()
        {
            DatosPersona = new PersonaAdapter();
        }

        public Persona GetOne(int ID)
        {
            try
            {
                
                return DatosPersona.GetOne(ID);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la persona.", ex);
                throw ExcepcionManejada;
            }
        }

        public List<Persona> GetAll()
        {
            try
            {
                return DatosPersona.GetAll();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las personas.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
        }

        public void Delete(int ID)
        {
            try
            {
                DatosPersona.Delete(ID);
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la persona.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Insert(Persona persona)
        {
            try
            {
                DatosPersona.Insert(persona);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar la persona.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Update(Persona persona)
        {
            try
            {
                DatosPersona.Update(persona);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar la persona.", ex);
                throw ExcepcionManejada;
            }
        }
    }
}
