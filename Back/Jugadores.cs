using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
    public class Jugadores
    {
        public DataTable DT { get; set; } = new DataTable();

        public Jugadores()
        {
            DT.TableName = "Jugadores";
            DT.Columns.Add("dni", typeof(string));
            DT.Columns.Add("Club", typeof(string)); //culumnas
            DT.Columns.Add("AñoNacimiento", typeof(string));
            DT.Columns.Add("PosCancha", typeof(string));
            DT.Columns.Add("Goles", typeof(int));

            Leer_DT();
        }

        public bool CargarJugador(Jugador jugador)
        {
            bool res = false;
            if (!Validar(jugador))
            {

                //CARGAR DT CON LAS PROPIEDADES DEL OBJETO persona
                DT.Rows.Add();
                int i = DT.Rows.Count - 1;

                DT.Rows[i]["DNI"] = jugador.dni;
                DT.Rows[i]["Club"] = jugador.Club;
                DT.Rows[i]["AñoNacimiento"] = jugador.Nacimiento;
                DT.Rows[i]["PosCancha"] = jugador.PosCancha;
                DT.Rows[i]["Goles"] = jugador.Goles;

                DT.WriteXml("Jugadores.xml");

                res = true;
            }
            return res;
        }

        public bool BorrarJugadores(string dni)
        {
            bool res = false;
            int fila = BuscarFilaJugador(dni);

            if (fila != -1)
            {
                DT.Rows[fila].Delete(); //delete es borrar
                DT.WriteXml("Jugadores.xml"); //lo borra del archivo xml
                res = true;
            }

            return res;
        }

        public Jugador BuscarJugador(string dni)
        {

            Jugador jugador = new Jugador();

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["dni"].ToString() == dni)
                {
                    jugador.dni = DT.Rows[i]["dni"].ToString();
                    jugador.Club = DT.Rows[i]["Club"].ToString();
                    jugador.Nacimiento = DT.Rows[i]["AñoNacimiento"].ToString();
                    jugador.PosCancha = DT.Rows[i]["PosCancha"].ToString();
                    jugador.Goles = System.Convert.ToInt32(DT.Rows[i]["Goles"]);

                    break;
                }
           
                
            }

            return jugador;
        }

        public int BuscarFilaJugador(string dni)
        {
            int fila = -1;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["dni"].ToString() == dni)
                {
                    fila = i;

                    break;
                }


            }

            return fila;


        }

        private void Leer_DT()
        {
            if (System.IO.File.Exists("Jugadores.xml"))
            {
                DT.ReadXml("Jugadores.xml");
            }
        }

        private bool Validar(Jugador jugador)
        {
            bool res = false;
            int fila = BuscarFilaJugador(jugador.dni);

            if (fila != -1)
            {
                res = true;
            }

            return res;
        }




    }
}
