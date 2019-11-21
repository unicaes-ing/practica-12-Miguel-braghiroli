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
    class Ejercicio3
    {
        [Serializable]
        public struct Alumnno
        {
            public string carnet;
            public string nombre;
            public string carrera;
            public double cum;
        }
        private static Dictionary<string, Alumnno> diccAlumno = new Dictionary<string, Alumnno>();
        private static BinaryFormatter formatter = new BinaryFormatter();
        private const string Nombre_Archivo = "Alumno.bin";
        public static bool guardarDiccionario(Dictionary<string, Alumnno> diccionario)
        {
            try
            {
                FileStream fs = new FileStream(Nombre_Archivo, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, diccionario);
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static bool leerDiccionario()
        {
            try
            {
                FileStream fs = new FileStream(Nombre_Archivo, FileMode.Open, FileAccess.Read);
                diccAlumno = (Dictionary<string, Alumnno>)formatter.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            if (File.Exists(Nombre_Archivo))
            {
                leerDiccionario();
            }
            else guardarDiccionario(diccAlumno);
            int menu;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú:\n[1] Agregar Alumno\n[2] Mostrar Alumnos\n[3] Buscar Alumno\n[4] Editar Alumno\n[5] Eliminar Alumno\n[6] Salir");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Agregar Alumno:\n");
                            Alumnno alumnos = new Alumnno();
                            do
                            {
                                Console.WriteLine("Carnet del alumno:");
                                alumnos.carnet = Console.ReadLine();
                                if (diccAlumno.ContainsKey(alumnos.carnet))
                                {
                                    Console.WriteLine("El carnet ya existe, ingrese uno diferente");
                                }
                            } while (diccAlumno.ContainsKey(alumnos.carnet));
                            Console.WriteLine("Nombre del alumno:");
                            alumnos.nombre = Console.ReadLine();
                            Console.WriteLine("Carrera que cursa:");
                            alumnos.carrera = Console.ReadLine();
                            Console.WriteLine("CUM del alumno:");
                            alumnos.cum = Convert.ToDouble(Console.ReadLine());
                            diccAlumno.Add(alumnos.carnet, alumnos);
                            guardarDiccionario(diccAlumno);
                            Console.WriteLine("El alumno ha sido registrado ...");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Listado de Alumnos:\n");
                            Console.WriteLine("{0,9} {1,-10} {2,-30} {3,2}", "Carnet", "Nombre", "Carrera", "CUM");
                            Console.WriteLine("------------------------------------------------------------------");
                            leerDiccionario();
                            foreach (KeyValuePair<string, Alumnno> elemento in diccAlumno)
                            {
                                Alumnno al = elemento.Value;
                                Console.WriteLine("{0,9} {1,-10} {2,-30} {3:N1}", al.carnet, al.nombre, al.carrera, al.cum);
                            }
                            Console.WriteLine("------------------------------------------------------------------");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        string ID;
                        do
                        {
                            Console.WriteLine("Ingrese el carnet del estudiantes:");
                            ID = Console.ReadLine();
                            if (diccAlumno.ContainsKey(ID))
                            {
                                foreach (KeyValuePair<string, Alumnno> elemento in diccAlumno)
                                {
                                    Alumnno alumnos = elemento.Value;
                                    if (elemento.Key.Equals(ID))
                                    {
                                        Console.WriteLine("{0,9} {1,-10} {2,-30} {3,2}", "Carnet", "Nombre", "Carrera", "CUM");
                                        Console.WriteLine("------------------------------------------------------------------");
                                        Console.WriteLine("{0,9} {1,-10} {2,-30} {3:N1}", alumnos.carnet, alumnos.nombre, alumnos.carrera, alumnos.cum);
                                    }
                                }
                                break;
                            }
                        } while (diccAlumno.ContainsKey(ID));
                        Console.ReadKey();
                        break;
                    case 4:
                        string id;
                        do
                        {
                            Console.WriteLine("Ingrese el carnet del estudiante:");
                            id = Console.ReadLine();
                            if (diccAlumno.ContainsKey(id))
                            {
                                foreach (KeyValuePair<string, Alumnno> elemento in diccAlumno)
                                {
                                    Alumnno alumno = elemento.Value;
                                    if (elemento.Key.Equals(id))
                                    {
                                        diccAlumno.Remove(elemento.Key);
                                        Console.WriteLine("Ingrese el nuevo carnet del estudiante:");
                                        alumno.carnet = Console.ReadLine();
                                        Console.WriteLine("Ingrese nombre del estudiante:");
                                        alumno.nombre = Console.ReadLine();
                                        Console.WriteLine("Ingrese la carrera que cursa:");
                                        alumno.carrera = Console.ReadLine();
                                        Console.WriteLine("Ingrese el CUM del estudiante:");
                                        alumno.cum = Convert.ToDouble(Console.ReadLine());
                                        diccAlumno.Add(alumno.carnet, alumno);
                                        guardarDiccionario(diccAlumno);
                                        break;
                                    }
                                }
                                Console.WriteLine("{0,9} {1,-10} {2,-30} {3,2}", "Carnet", "Nombre", "Carrera", "CUM");
                                Console.WriteLine("------------------------------------------------------------------");
                                foreach (KeyValuePair<string, Alumnno> elemento in diccAlumno)
                                {
                                    Alumnno student = elemento.Value;
                                    Console.WriteLine("{0,9} {1,-10} {2,-30} {3:N1}", student.carnet, student.nombre, student.carrera, student.cum);
                                }
                                Console.ReadKey();
                            }
                        } while (diccAlumno.ContainsKey(id));
                        break;
                    case 5:
                        string codigo;
                        do
                        {
                            Console.WriteLine("Ingrese carnet del estudiante:");
                            codigo = Console.ReadLine();
                            if (diccAlumno.ContainsKey(codigo))
                            {
                                foreach (KeyValuePair<string, Alumnno> elemento in diccAlumno)
                                {
                                    if (elemento.Key.Equals(codigo))
                                    {
                                        diccAlumno.Remove(codigo);
                                        guardarDiccionario(diccAlumno);
                                        Console.WriteLine("Elemento eliminado... ");
                                        break;
                                    }
                                }
                            }
                        } while (diccAlumno.ContainsKey(codigo));
                        Console.ReadKey();
                        break;
                }
            } while (menu != 6);
        }
    }
}
