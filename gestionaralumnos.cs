using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArchivosInicio
{
    class gestionaralumnos
    {
        string NombreArchivo = "Alumnos.txt";
        public List<Alumno> Leer()
        {
			
			// Otro
			//   Alumno[] lista = new Alumno[1];
            //   FileStream fs = new FileStream(archivo,FileMode.OpenOrCreate,FileAccess.Read);
            //   StreamReader br = new StreamReader(fs);

            //   string linea = br.ReadLine();
            //   int i = 0;
            //   while (linea !=null)
            //   {
            //      lista[i]=new Alumno(linea);
            //       linea = br.ReadLine();
            //       if (linea!=null)
            //       {
            //           //si hay mas lineas, amplio el vector.
            //           Array.Resize(ref lista, lista.Length + 1); 
            //       }
            //       i++;
            //   }
			
			
            string linea;
            List<Alumno> ListaAlumnos = new List<Alumno>();

            FileStream fs = new FileStream(NombreArchivo, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader rd = new StreamReader(fs))
            {
                linea = rd.ReadLine();
                while(linea != null)
                {
                    Alumno nuevoalumno = new Alumno();
                    nuevoalumno.GenerarRegistro(linea);
                    ListaAlumnos.Add(nuevoalumno);

                    linea = rd.ReadLine();
                }
                fs.Close();
            }
            return ListaAlumnos;
        }

        public void alta(Alumno nuevoalumno)
        {
            FileStream fs = new FileStream(NombreArchivo, FileMode.Append, FileAccess.Write);
            using (StreamWriter wr = new StreamWriter(fs))
            {
                wr.WriteLine(nuevoalumno.Escribir());
            }
            fs.Close();
        }

        public void baja(Int64 dni)
        {
            string output = String.Empty;
            string linea;
            
            FileStream fsr = new FileStream(NombreArchivo, FileMode.Open, FileAccess.Read);
            using (StreamReader rd = new StreamReader(fsr))
            {
                linea = rd.ReadLine();

                while (linea != null)
                {
                    Alumno nuevoalumno = new Alumno();
                    nuevoalumno.GenerarRegistro(linea);

                    if (nuevoalumno.dni != dni)
                    {
                        output = output + linea + Environment.NewLine; 
                    }
                    linea = rd.ReadLine();
                }
                
            }
            fsr.Close();
            FileStream fsw = new FileStream(NombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
            using (StreamWriter wr = new StreamWriter(fsw))
            {
                wr.WriteLine(output);
            }
            fsr.Close();
        }
    }
}
