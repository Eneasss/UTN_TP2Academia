using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class InscripcionLogic
    {
        AlumnoInscripcionAdapter _DatosInscripcion;
        public AlumnoInscripcionAdapter DatosInscripcion
        {
            get
            {
                return _DatosInscripcion;
            }
            set
            {
                _DatosInscripcion = value;
            }
        }

        public InscripcionLogic()
        {
            _DatosInscripcion = new AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAllxIdPersona(int IdPersona)
        {
            try
            {
                return DatosInscripcion.GetAllxIdPersona(IdPersona);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Inscribir(AlumnoInscripcion alum)
        {
            try
            {
                DatosInscripcion.Inscribir(alum);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar la inscripcion.", ex);
                throw ExcepcionManejada;
            }
        }
        public List<AlumnoInscripcion> GetAllxIdCurso(int idCurso)
        {
            try
            {
                AlumnoInscripcionAdapter aia = new AlumnoInscripcionAdapter();
                return aia.GetAllxIdCurso(idCurso);
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones.", ex);
                throw ExcepcionManejada;
            }
        }

        public void Update(Inscripciones ins)
        {
            try
            {
                _DatosInscripcion.Update(ins);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar la inscripcion.", ex);
                throw ExcepcionManejada;
            }
        }

        public Inscripciones ConseguirInscripcionXid(int id)
        {
            try
            {
                return DatosInscripcion.ConseguirInscripcionXid(id);
            }
            
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la inscripcion.", ex);
                throw ExcepcionManejada;
            }

        }
    }

    
}
