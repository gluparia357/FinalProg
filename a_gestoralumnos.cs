using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.AparecioCSharp
{
   public class GestorAlumnos
    {
        string archivo = "alumnos.txt";
        public Alumno[] LeerAlumnos()
        {

            Alumno[] lista = new Alumno[1];
            FileStream fs = new FileStream(archivo,FileMode.OpenOrCreate,FileAccess.Read);
            StreamReader br = new StreamReader(fs);

            string linea = br.ReadLine();
            int i = 0;
            while (linea !=null)
            {
                lista[i]=new Alumno(linea);
                linea = br.ReadLine();
                if (linea!=null)
                {
                    //si hay mas lineas, amplio el vector.
                    Array.Resize(ref lista, lista.Length + 1); 
                }
                i++;
            }
            br.Close();
            return lista;
        }


      public  Alumno[] Ordenar()
        {

            Alumno[] alumnos = LeerAlumnos();


            for (int i = 0; i < alumnos.Length; i++)
            {
                var tmp = alumnos[i];
                for (int x = i+1; x < alumnos.Length; x++)
                {

                    if (alumnos[i].Legajo > alumnos[x].Legajo)
                    {
                        //si son el mismo legajo, invierto.
                        alumnos[i] = alumnos[x];
                        alumnos[x] = tmp;
                        tmp = alumnos[x];
                    }
                }
            }


            return alumnos;


        }


        public void GuardarAlumno(Alumno unAlumno)
        {
            FileStream fs = new FileStream(archivo, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);


            
            sw.WriteLine(unAlumno.ObtenerRegistro());
            sw.Close();
        }
    }
}
