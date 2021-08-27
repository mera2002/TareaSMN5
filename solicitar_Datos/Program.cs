using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace solicitar_Datos
{
    class Program
    {
        static void Main(string[] args)
           
        {
           
            string solici = @"C:\solicitar_Datos\datosRegis\datos.txt";

            //evaluar si el archivo exite
            if (File.Exists(solici))
            {
                Console.WriteLine("El archivo ya existe!");

                
                String[] lines;
                lines = File.ReadAllLines(solici);
                Console.WriteLine("CONTENIDO UTILIZANDO ReadAllLines()");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

            }
            else
            {
                
                using (StreamWriter archivo = File.AppendText(solici))
                {
                    
                    archivo.WriteLine("SISTEMA DE REGISTRO DE ESTUDIANTES");
                    archivo.WriteLine("Tarea semana 5");
                    archivo.Close();
                }
            }


            Console.ReadKey();
        }
    }
}
