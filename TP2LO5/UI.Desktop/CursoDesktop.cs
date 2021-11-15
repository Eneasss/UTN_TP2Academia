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
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            CursoLogic curso = new CursoLogic();
            
            cursoActual = curso.GetOne(ID);
            
            
            this.MapearDeDatos();
        }
        public Curso cursoActual { get; set; }

        public override void MapearDeDatos()
        {
            txtID.Text = this.cursoActual.ID.ToString();
            txtCalendario.Text = this.cursoActual.AnioCalendario.ToString();
            txtCupo.Text = this.cursoActual.Cupo.ToString();
            
            //cbPlanes.DisplayMember = this.materiaActual.IDPlan.ToString();

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
            this.MapearADatos();
            CursoLogic cursoLog = new CursoLogic();
            cursoLog.Save(cursoActual);

        }
        public override bool Validar()
        {


            if (string.IsNullOrEmpty(txtCupo.Text))
            {

                this.Notificar("Error", "Cupo incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }


        }





        

        

        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            cbMateria.DataSource = materias;
            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "ID";

            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetAll();
            cbComision.DataSource = comisiones;
            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "ID";

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
