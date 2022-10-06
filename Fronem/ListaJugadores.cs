using Back;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fronem
{
    public partial class ListaJugadores : Form
    {
        private Back.Personas personas = new Back.Personas();
        private Back.Jugadores Jugadores = new Back.Jugadores(); //preguntar

        public ListaJugadores()
        {
            InitializeComponent();
            dg.DataSource = personas.DT;
            dgJugador.DataSource = Jugadores.DT;
            LimpiarPantalla();
        }

    
        private void btCargar_Click_1(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            Jugador jugador = new Jugador();

            persona.DNI = txtDNI.Text;
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Edad = Convert.ToInt32(txtEdad.Text);



            //----------------------------------------------------
            jugador.dni = txtDNI.Text; 
            jugador.Club = txtClub.Text;
            jugador.Nacimiento = txtNacimineto.Text;
            jugador.PosCancha = txtPosi.Text;
            jugador.Goles = Convert.ToInt32(txtGoles.Text);

            Jugadores.CargarJugador(jugador);
            personas.CargarPersona(persona);

            LimpiarPantalla();

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {





            //---------------------------------------------------------
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";

            Persona persona = new Persona();

            persona = personas.BuscarPersona(txtDNI.Text);

            if (persona.DNI != null)
            {
                //txtDNI.Text = jugador.dni;
                txtDNI.Text = persona.DNI;
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtEdad.Text = persona.Edad.ToString();

            }

            txtDNI.Focus();
            txtDNI.SelectAll();

            //-------------------------------------------------

            txtClub.Text = "";
            txtNacimineto.Text = "";
            txtPosi.Text = "";
            txtGoles.Text = "";

            Jugador jugador = new Jugador();

            jugador = Jugadores.BuscarJugador(txtDNI.Text);

            if (jugador.dni != null)
            {
                //txtDNI.Text = jugador.dni;
                txtDNI.Text = jugador.dni;
                txtClub.Text = jugador.Club;
                txtNacimineto.Text = jugador.Nacimiento;
                txtGoles.Text = jugador.Goles.ToString();
                txtPosi.Text = jugador.PosCancha;


            }

            txtDNI.Focus();
            txtDNI.SelectAll();
        }

        private void btBorrar_Click_1(object sender, EventArgs e)
        {
            bool res = personas.BorrarPersona(txtDNI.Text);
            bool res2 = Jugadores.BorrarJugadores(txtDNI.Text);

            if (res2)
            {
                LimpiarPantalla();
            }
            else
            {
                txtDNI.Focus();
                txtDNI.SelectAll();
            }

            if (res)
            {
                LimpiarPantalla();
            }
            else
            {
                txtDNI.Focus();
                txtDNI.SelectAll();
            }
        }

        private void LimpiarPantalla()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtClub.Text = "";
            txtGoles.Text = "";
            txtPosi.Text = "";
            txtNacimineto.Text = "";

            txtDNI.Focus(); //
        }

        private void ListaJugadores_Load(object sender, EventArgs e)
        {

        }
    }
}

