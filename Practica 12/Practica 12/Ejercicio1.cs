using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//Miguel Braghiroli 18/11/19
namespace Practica_12
{
    class Ejercicio1
    {
        [Serializable]
        public struct Mascota
        {
            public string nombre;
            public string especie;
            public string raza;
            public string sexo;
            public int edad;
        }
        static void Main(string[] args)
        {
            Mascota mascota = new Mascota();
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();
            const string Nombre_Archivo = "Mascota.bin";
            try
            {
                Console.WriteLine("Ingrese el nombre de su mascota: ");
                mascota.nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la especie de su mascota: ");
                mascota.especie = Console.ReadLine();
                Console.WriteLine("Ingrese la raza de su mascota: ");
                mascota.raza = Console.ReadLine();
                Console.WriteLine("Ingrese el sexo de su mascota: ");
                mascota.sexo = Console.ReadLine();
                Console.WriteLine("Ingrese la edad de su mascota: ");
                mascota.edad = Convert.ToInt32(Console.ReadLine());
                fs = new FileStream(Nombre_Archivo, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, mascota);
                fs.Close();
                Console.WriteLine();
                Console.WriteLine("Los datos de su mascota se registraron exitosamente...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}