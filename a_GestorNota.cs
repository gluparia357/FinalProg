using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos.AparecioCSharp
{
    public class GestorNota
    {
        string archivo = "notas.txt";
        public Nota[] LeerNotas()
        {

            Nota[] lista = new Nota[1];
            FileStream fs = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader br = new StreamReader(fs);

            string linea = br.ReadLine();
            int i = 0;
            while (linea != null)
            {
                lista[i] = new Nota(linea);
                linea = br.ReadLine();
                if (linea != null)
                {
                    //si hay mas lineas, amplio el vector.
                    Array.Resize(ref lista, lista.Length + 1);
                }
                i++;
            }
            br.Close();
            return lista;
        }


        public Nota[] Ordenar()
        {

            Nota[] notas = LeerNotas();


            for (int i = 0; i < notas.Length; i++)
            {
                var tmp = notas[i];
                for (int x = i + 1; x < notas.Length; x++)
                {

                    if (notas[i].Legajo > notas[x].Legajo)
                    {
                        //si son el mismo legajo, invierto.
                        notas[i] = notas[x];
                        notas[x] = tmp;
                        tmp = notas[x];
                    }
                }
            }


            return notas;


        }

        public void GuardarNota(Nota unaNota)
        {
            FileStream fs = new FileStream(archivo, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            
            sw.WriteLine(unaNota.ObtenerRegistro());
            sw.Close();
        }
    }
}

