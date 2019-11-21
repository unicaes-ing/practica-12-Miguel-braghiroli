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
    class Ejercicio2
    {
        static void Main(string[] args)
        {
            Program.Mascota mascota;
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();
            const string Nombre_Archivo = "Mascota.bin";
            if(File.Exists(Nombre_Archivo))
            {
                try
                {
                    fs = new FileStream(Nombre_Archivo, FileMode.Open, FileAccess.Read);
                    mascota = (Program.Mascota)formatter.Deserialize(fs);
                    fs.Close();
                    Console.WriteLine("Dato de la mascota:\n");
                    Console.WriteLine("Nombre de la mascota: {0}", mascota.nombre);
                    Console.WriteLine("Especie de la mascota: {0}", mascota.especie);
                    Console.WriteLine("Raza de la mascota: {0}", mascota.raza);
                    Console.WriteLine("Sexo de la mascota: {0}", mascota.sexo);
                    Console.WriteLine("Edad de la mascota: {0} años", mascota.edad);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadKey();
            }
         }
    }
}
