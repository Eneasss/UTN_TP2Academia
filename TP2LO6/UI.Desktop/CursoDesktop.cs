using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            this.modo = modo;
            CursoLogic curso = new CursoLogic();

        }
        public CursoDesktop(ModoForm modo, int idplan) : this()
        {
            this.modo = modo;
            CursoLogic curso = new CursoLogic();
            cargarCb(idplan);

        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            try
            {
                this.modo = modo;
                CursoLogic curso = new CursoLogic();
            
                cursoActual = curso.GetOne(ID);
                ComisionLogic cl = new ComisionLogic();
                cargarCb(cl.GetOne(cursoActual.IDComision).IDPlan);
            
                this.MapearDeDatos();
                if (modo == ModoForm.Baja)
                {

                    txtCupo.ReadOnly = true;
                    txtCalendario.ReadOnly = true;
                    cbMateria.Enabled = false;
                    cbComision.Enabled = false;
                }
            }

            catch (Exception)
            {
                Notificar("Error", "Error al recuperar los planes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Curso cursoActual { get; set; }

        public override void MapearDeDatos()
        {
            txtID.Text = this.cursoActual.ID.ToString();
            txtCalendario.Text = this.cursoActual.AnioCalendario.ToString();
            txtCupo.Text = this.cursoActual.Cupo.ToString();

            //cbPlanes.DisplayMember = this.materiaActual.IDPlan.ToString();
            cbComision.SelectedValue = this.cursoActual.IDComision;
            cbMateria.SelectedValue = this.cursoActual.IDMateria;

            switch (this.modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;

            }


        }
        public override void MapearADatos()
        {
            switch (modo)
            {
                case ModoForm.Alta:
                    {
                        Curso curso = new Curso();
                        cursoActual = curso;

                        cursoActual.AnioCalendario = int.Parse(this.txtCalendario.Text);
                        cursoActual.Cupo = int.Parse(this.txtCupo.Text);
                        cursoActual.IDComision = int.Parse(this.cbComision.SelectedValue.ToString());
                        cursoActual.IDMateria = int.Parse(this.cbMateria.SelectedValue.ToString());
                        
                        cursoActual.State = BusinessEntity.States.New;
                        btnAceptar.Text = "Guardar";

                    }
                    break;
                case ModoForm.Modificacion:
                    {
                        Curso curso = new Curso();
                        cursoActual = curso;
                        cursoActual.ID = int.Parse(txtID.Text);
                        cursoActual.AnioCalendario = int.Parse(this.txtCalendario.Text);
                        cursoActual.Cupo = int.Parse(this.txtCupo.Text);
                        
                        cursoActual.IDComision = int.Parse(this.cbComision.SelectedValue.ToString());
                        cursoActual.IDMateria = int.Parse(this.cbMateria.SelectedValue.ToString());

                        cursoActual.State = BusinessEntity.States.Modified;
                        btnAceptar.Text = "Alta";

                    }
                    break;
                case ModoForm.Baja:
                    {
                        Curso curso = new Curso();
                        cursoActual = curso;

                        cursoActual.ID = int.Parse(txtID.Text);
                        cursoActual.AnioCalendario = int.Parse(this.txtCalendario.Text);
                        cursoActual.Cupo = int.Parse(this.txtCupo.Text);

                        cursoActual.IDComision = int.Parse(this.cbComision.SelectedValue.ToString());
                        cursoActual.IDMateria = int.Parse(this.cbMateria.SelectedValue.ToString());

                        cursoActual.State = BusinessEntity.States.Deleted;
                        btnAceptar.Text = "Eliminar";

                    }
                    break;

            }
        }
        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                CursoLogic cursoLog = new CursoLogic();
                cursoLog.Save(cursoActual);
            }
            catch (Exception)
            {
                Notificar("Error", "Error al guardar los cambios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public override bool Validar()
        {
            if (Validaciones.esCampoValido(txtCupo.Text))
            {
                if (Validaciones.esCampoValido(txtCalendario.Text))
                {
                    if (cbMateria.SelectedValue != null)
                    {
                        if (cbComision.SelectedValue != null)
                        {
                            return true;
                        }
                        else
                        {
                            Notificar("Error", "comision Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        Notificar("Error", "Materia Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    Notificar("Error", "fecha invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                Notificar("Error", "Cupo invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           


        }


        public void cargarCb(int ID)
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                List<Materia> materias = ml.GetAllxID(ID);
                cbMateria.DataSource = materias;
                cbMateria.DisplayMember = "Descripcion";
                cbMateria.ValueMember = "ID";

                ComisionLogic cl = new ComisionLogic();
                List<Comision> comisiones = cl.GetAllxID(ID);
                cbComision.DataSource = comisiones;
                cbComision.DisplayMember = "Descripcion";
                cbComision.ValueMember = "ID";
            }

            catch (Exception)
            {
                Notificar("Error", "Error al recuperar las materias y comisiones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        

        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            

        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
