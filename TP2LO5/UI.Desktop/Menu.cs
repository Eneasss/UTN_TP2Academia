using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios formUsuario = new Usuarios();
            formUsuario.ShowDialog();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidad = new Especialidades();
            formEspecialidad.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes formPlan = new Planes();
            formPlan.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias formMateria = new Materias();
            formMateria.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones formComision = new Comisiones();
            formComision.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos formCurso = new Cursos();
            formCurso.ShowDialog();
        }
    }
}
