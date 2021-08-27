using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace solicitar_Datos
{
    class Registro_InicioSS
    {
        static void Main()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu(); //llamdo al metodo Menu()
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {
            //crear el menu para mostrar al usuario
            //Console.Clear(); //permite limpiar la consola
            Console.WriteLine("REGISTRO E INICIO DE SESION DE ESTUDIANTES ");
            Console.WriteLine("                                           ");
            Console.WriteLine("Seleccion la operación a realizar: ");
            Console.WriteLine("1. Registrarse");
            Console.WriteLine("2. Iniciar sesion");
            Console.WriteLine("3. Mostrar listado de estudiantes registrados");
            Console.WriteLine("4. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    registrarse(); //llamado al metodo registrar
                    return true;
                case "2":
                   
                    return true;
                case "3":
                    //mostrar el contenido del archivo
                    Console.WriteLine("---------------LISTADO DE ESTUDIANTES REGISTRADOS--------------");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return false;
            }
        }

        //metodo para obtener la ruta del archivo
        private static string getPath()
        {
            string solici = @"C:\Registro\datos.txt";
            return solici;
        }

        //metodo para registrar datos en el archivo
        private static void registrarse()
        {
            //solicitar los datos del estudiante
            Console.WriteLine("DATOS DEL ESTUDIANTE");
            Console.Write("Nombre Completo: ");
            string fullname = Console.ReadLine();
            Console.Write("Codigo: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Contraseña: ");
            int cont = Convert.ToInt32(Console.ReadLine());

         
            using (StreamWriter sw = File.AppendText(getPath()))
            {
                sw.WriteLine("{0}; {1}", fullname, age, cont);
                sw.Close();
            }
        }

   
        private static Dictionary<object, object> readFile()
        {
     
            Dictionary<object, object> lista_de_Data = new Dictionary<object, object>();

            using (var reader = new StreamReader(getPath()))
            {
 
                string lines;

                while ((lines = reader.ReadLine()) != null) 
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        lista_de_Data.Add(keyvalue[0], keyvalue[1]);
                    }
                }

            }

            //retornar el diccionario
            return lista_de_Data;
        }
    }
}
