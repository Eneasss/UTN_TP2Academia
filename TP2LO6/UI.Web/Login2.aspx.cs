using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Usuario usuarioActual { get; set; }
        public Persona personaActual { get; set; }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioLogic usuarioData = new UsuarioLogic();
                usuarioActual = usuarioData.Login(txtUsuario.Text, Encriptacion.encriptar(txtClave.Text));
            
                if (usuarioActual.ID != 0)
                {
                    if (usuarioActual.Habilitado)
                    {
                        Page.Response.Write("Login Correcto");
                        Session["UsuarioActual"] = usuarioActual;
                        PersonaLogic perData = new PersonaLogic();
                        personaActual = perData.GetOne(usuarioActual.IDPersona);
                        Session["PersonaActual"] = personaActual;
                        Page.Response.Redirect("~/Default.aspx");

                    }
                    else
                    {
                        lblMensage2.Visible = true;
                    }
                }
                else
                {
                    lblMensage.Visible = true;
                    this.txtClave.Text="";
                }
            }
            

            catch (Exception)
            {

                Response.Write("<script>alert('Error al iniciar sesion');</script>");
            }

        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('no implementado');</script>");
        }

    }
}