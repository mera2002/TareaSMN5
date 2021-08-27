using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_InicioSS
{
    class Program
    {
        static void Main(string[] args)
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
    Console.WriteLine("Seleccion la operación a realizar: ");
    Console.WriteLine("1. Registrar nuevo estudiante");
    Console.WriteLine("2. Actualizar datos de estudiante");
    Console.WriteLine("3. Eliminar datos de estudiante");
    Console.WriteLine("4. Mostrar listado de estudiantes");
    Console.WriteLine("5. Salir");
    Console.Write("\nOpcion: ");

    switch (Console.ReadLine())
    {
        case "1":
            register(); //llamado al metodo registrar
            return true;
        case "2":
            updateData(); //llamdo al metodo para actualizar
            Console.ReadKey();
            return true;
        case "3":
            return true;
        case "4":
            //mostrar el contenido del archivo
            Console.WriteLine("LISTADO DE ESTUDIANTES");
            foreach (KeyValuePair<object, object> data in readFile())
            {
                Console.WriteLine("{0}: {1}", data.Key, data.Value);
            }
            Console.ReadKey();
            return true;
        case "5":
            return false;
        default:
            return false;
    }
}

//metodo para obtener la ruta del archivo
private static string getPath()
{
    string path = @"E:\ejemplo\registros.txt";
    return path;
}

//metodo para registrar datos en el archivo
private static void register()
{
    //solicitar los datos del estudiante
    Console.WriteLine("DATOS DEL ESTUDIANTE");
    Console.Write("Nombre Completo: ");
    string fullname = Console.ReadLine();
    Console.Write("Edad: ");
    int age = Convert.ToInt32(Console.ReadLine());

    //crear el archivo, uso de StreamWriter para escribir el archivo
    using (StreamWriter sw = File.AppendText(getPath()))
    {
        sw.WriteLine("{0}; {1}", fullname, age);
        sw.Close();
    }
}

//metodo para leer el contenido del archivo
private static Dictionary<object, object> readFile()
{
    //declarar el diccionario
    Dictionary<object, object> listData = new Dictionary<object, object>();

    //uso del StreamReader para leer el archivo
    using (var reader = new StreamReader(getPath()))
    {
        //variable para almacenar el contenido del archivo
        string lines;

        while ((lines = reader.ReadLine()) != null) //mientras no se encuentre una linea vacia se ejecuta el ciclo
        {
            string[] keyvalue = lines.Split(';');
            if (keyvalue.Length == 2)
            {
                listData.Add(keyvalue[0], keyvalue[1]);
            }
        }

    }

    //retornar el diccionario
    return listData;
}

//metodo para buscar por clave
private static bool search(string name)
{
    if (!readFile().ContainsKey(name))
    {
        return false;
    }
    return true;
}

//metodo para actualizar
private static void updateData()
{
    //solicitar el elemnto a modificar
    Console.Write("Escriba el nombre del estudiante a actualizar: ");
    var name = Console.ReadLine();

    //realizar la busqueda
    if (search(name))
    {
        Console.WriteLine("El registro existe!");
        Console.Write("Nueva edad: ");
        var newAge = Console.ReadLine();

        //declarar un diccionario
        Dictionary<object, object> temp = new Dictionary<object, object>();
        temp = readFile();

        temp[name] = newAge; //actualizar el valor
        Console.WriteLine("El registro ha sido actualizado!");
        File.Delete(getPath()); //eliminamos archivos y posteriormente lo volvemos a crear

        using (StreamWriter sw = File.AppendText(getPath()))
        {
            //leer diccionario temporal y almacenar los elementos en el archivo
            foreach (KeyValuePair<object, object> values in temp)
            {
                sw.WriteLine("{0}; {1}", values.Key, values.Value);
                // sw.Close();
            }
        }

    }
    else
    {
        Console.WriteLine("El registro no se encontro!");
    }
}
    }
}
        {
        }
    }
}
