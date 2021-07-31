using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public override void MapearDeDatos()
        {
            txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            txtApellido.Text = this.UsuarioActual.Apellido;
            txtEmail.Text = this.UsuarioActual.Email;
            txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            txtClave.Text = this.UsuarioActual.Clave;
            txtConfirmarClave.Text = this.UsuarioActual.Clave;
            switch (this.modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Modificar";
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
                        Usuario usu = new Usuario();
                        UsuarioActual = usu;


                        UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                        UsuarioActual.Nombre = this.txtNombre.Text;
                        UsuarioActual.Apellido = txtApellido.Text;
                        UsuarioActual.Email = txtEmail.Text;
                        UsuarioActual.NombreUsuario = txtUsuario.Text;
                        UsuarioActual.Clave = txtClave.Text;
                        UsuarioActual.State = BusinessEntity.States.New;
                        btnAceptar.Text = "Guardar";
                        
                    } break;
                case ModoForm.Modificacion:
                    {
                        Usuario usu = new Usuario();
                        UsuarioActual = usu;
                        UsuarioActual.ID = int.Parse(txtID.Text);
                        UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                        UsuarioActual.Nombre = this.txtNombre.Text;
                        UsuarioActual.Apellido = txtApellido.Text;
                        UsuarioActual.Email = txtEmail.Text;
                        UsuarioActual.NombreUsuario = txtUsuario.Text;
                        UsuarioActual.NombreUsuario = txtUsuario.Text;
                        UsuarioActual.Clave = txtClave.Text;
                        UsuarioActual.State = BusinessEntity.States.Modified;
                        btnAceptar.Text = "Alta";
                        
                    }
                    break;
                case ModoForm.Baja:
                    {
                        Usuario usu = new Usuario();
                        UsuarioActual = usu;

                        UsuarioActual.ID = int.Parse(txtID.Text);
                        UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                        UsuarioActual.Nombre = this.txtNombre.Text;
                        UsuarioActual.Apellido = txtApellido.Text;
                        UsuarioActual.Email = txtEmail.Text;
                        UsuarioActual.NombreUsuario = txtUsuario.Text;
                        UsuarioActual.NombreUsuario = txtUsuario.Text;
                        UsuarioActual.Clave = txtClave.Text;
                        UsuarioActual.State = BusinessEntity.States.Deleted;
                        btnAceptar.Text = "Eliminar";
                        
                    }
                    break;
                
            }
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic usuLog = new UsuarioLogic();
            usuLog.Save(UsuarioActual);
            
        }
        public override bool Validar()
        {


            if (string.IsNullOrEmpty(txtNombre.Text))
            {

                this.Notificar("Error", "Nombre incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {

                this.Notificar("Error", "Apellido incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            }

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {

                this.Notificar("Error", "Usuario incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {

                this.Notificar("Error", "Email incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(txtEmail.Text, expresion))
                {
                    if (Regex.Replace(txtEmail.Text, expresion, String.Empty).Length == 0)
                    {

                    }
                    else
                    {
                        this.Notificar("Error", "Email incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    this.Notificar("Error", "Email incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }
            }
            

            if (string.IsNullOrEmpty(txtClave.Text))
            {

                this.Notificar("Error", "Clave incompleto", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            } else if (txtClave.Text.Length >= 8)
            {
                if (txtClave.Text == txtConfirmarClave.Text)
                {
                    return true;
                }
                else
                {
                    this.Notificar("Error", "Las clave no coinciden", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                this.Notificar("Error", "Clave menor a 8 caracteres", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        

        public UsuarioDesktop(ModoForm modo) : this() 
        {
            this.modo = modo;
            UsuarioLogic usu = new UsuarioLogic();
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.modo = modo;
            UsuarioLogic usu = new UsuarioLogic();

            UsuarioActual= usu.GetOne(ID);
            this.MapearDeDatos();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
