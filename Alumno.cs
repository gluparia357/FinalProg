using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivosInicio
{
    public class Alumno
    {
        public string nombre;
        public Int64 dni;
        public int edad;

        public void GenerarRegistro(string param)
        {
            string[] linea = param.Split(',');
            nombre = linea[0];
            dni = Int64.Parse(linea[1]);
            edad = Int32.Parse(linea[2]);
           
        }

        public Alumno()
        {

        }
        public Alumno(string nombre, Int64 dni, int edad)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.edad = edad;
        }

        public string Escribir()
        {
            return $"{nombre},{dni},{edad}";
        }
    }
}
