using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back
{
    public class Personas
    {
        public DataTable DT { get; set; } = new DataTable();

        public Personas()
        {
            DT.TableName = "Personas";
            DT.Columns.Add("DNI", typeof(string)); //culumnas
            DT.Columns.Add("Nombre", typeof(string));
            DT.Columns.Add("Apellido", typeof(string));
            DT.Columns.Add("Edad", typeof(int));

            Leer_DT();
        }

        public bool CargarPersona(Persona persona)
        {
            bool res = false;

            if (!Validar(persona))
            {
                //CARGAR DT CON LAS PROPIEDADES DEL OBJETO persona
                DT.Rows.Add();
                int i = DT.Rows.Count - 1;

                DT.Rows[i]["DNI"] = persona.DNI;
                DT.Rows[i]["Nombre"] = persona.Nombre;
                DT.Rows[i]["Apellido"] = persona.Apellido;
                DT.Rows[i]["Edad"] = persona.Edad;

                DT.WriteXml("Personas.xml");

                res = true;
            }
            return res;



        }

        public bool BorrarPersona(string dni)
        {
            bool res = false;
            int fila = BuscarFilaPersona(dni);

            if (fila != -1)
            {
                DT.Rows[fila].Delete(); //delete es borrar
                DT.WriteXml("Personas.xml"); //lo borra del archivo xml
                res = true;
            }

            return res;
        }

        public Persona BuscarPersona(string dni)
        {

            Persona persona = new Persona();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["DNI"].ToString() == dni)
                {
                    persona.DNI = DT.Rows[i]["DNI"].ToString();
                    persona.Nombre = DT.Rows[i]["Nombre"].ToString();
                    persona.Apellido = DT.Rows[i]["Apellido"].ToString();
                    persona.Edad = System.Convert.ToInt32(DT.Rows[i]["Edad"]);

                    break;
                }

            }

            return persona;
        }

        public int BuscarFilaPersona(string dni)
        {
            int fila = -1;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["DNI"].ToString() == dni)
                {
                    fila = i;

                    break;
                }


            }

            return fila;


        }

        private void Leer_DT()
        {
            if (System.IO.File.Exists("Personas.xml"))
            {
                DT.ReadXml("Personas.xml");
            }
        }

        private bool Validar(Persona persona)
        {
            bool res = false;
            int fila = BuscarFilaPersona(persona.DNI);

            if (fila != -1)
            {
                res = true;
            }

            return res;
        }


    }
}
