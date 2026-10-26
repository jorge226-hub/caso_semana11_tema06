using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace caso_semana11_tema06
{
    internal class Program
    {
        static int max_estudiantes = 40;
        static int max_cursos = 4;
        static string[] nombre_cursos = { "Matematicas", "Programación", "Fisica", "Base de datos" }; 
        static string [] estudiante=new string[max_estudiantes];
        static double[,] matriznotas=new double[max_estudiantes,max_cursos];
        static int total_estudiantes = 0;
        static string rutaarchivo = "notas_curso.txt";
        public static void RegistrarEstudiante() 
        {
            Console.WriteLine("**********************");
            Console.WriteLine("REGISTRO DE ESTUDIANTE");
            Console.WriteLine("**********************");
            if (total_estudiantes >= max_estudiantes)
            {
                Console.WriteLine("Se alcanzo la capacidad maxima");
                return;
            }
            string nombre = validacion.Leertexto("Ingresar nombres y apellidos: ").ToUpper();
            estudiante[total_estudiantes] = nombre;
            Console.WriteLine("Ingresar las notas de 0 al 20");
            for (int i=0; i< max_cursos; i++) 
            {
                matriznotas[total_estudiantes, i] = validacion.Leerdecimales
                    ($"Ingresar nota de {nombre_cursos[i]}:");
            }
            total_estudiantes++;
            Console.WriteLine("Estudiantes registrado...!");
        }
        public static void guardararchivo() 
        {
            Console.WriteLine("Guardar registros en archivo");
            if (total_estudiantes == 0) 
            {
                Console.WriteLine("Sin registros a guardar");
                return ;

            
            }
            using (StreamWriter escritor = new StreamWriter(rutaarchivo)) 
            {
                for (int i = 0; i < max_cursos; i++) 
                {
                    string linea=estudiante[i];
                    for (int j = 0; j < max_cursos; j++) 
                    
                    {
                        linea+=","+matriznotas[i,j];
                    }
                    escritor.WriteLine(linea);
                }
            
            }
            Console.WriteLine("Registro guardado");
        }
        public static void CargarRegistro() 
        {
            Console.WriteLine("CARGAR REGISTROS DESDE ARCHIVO");
            if (!File.Exists(rutaarchivo)) 
            {
                Console.WriteLine("No existe el archivo");
                return ;
            }
            total_estudiantes = 0;
            using (StreamReader lector = new StreamReader(rutaarchivo)) 
            {
                string linea;
                while ((linea = lector.ReadLine())
                != null & total_estudiantes < max_estudiantes) 
                {
                    string[] partes =linea.Split(',');
                    if (partes.Length == max_cursos + 1) 
                    {
                        estudiante[total_estudiantes] = partes[0];
                        for (int i = 0; i < max_cursos; i++) 
                        {
                            matriznotas[total_estudiantes,i]=Convert.ToDouble(partes[i+1]);
                        }
                        total_estudiantes++;
                    }
                }

                
            }
            Console.WriteLine("Se cargaron los registros del archivo");
        }
        public static void mostrarRegistro() 
        {
            Console.WriteLine(new string('=',100));
            Console.WriteLine("\t\tREGISTRO GENERAL DE NOTAS POR CURSO");
            Console.WriteLine(new string('=',100));
            if (total_estudiantes == 0) 
            {
                Console.WriteLine("No existe registros");
                return;
            }
            Console.WriteLine($"{"ESTUDIANTES",-25}|");
            for (int i = 0; i < max_cursos; i++) 
            {
                Console.Write($"{nombre_cursos[i],-12}|");
            }
            Console.WriteLine("PROMEDIO");
            Console.WriteLine(new string('=',100));
            for (int i = 0; i < total_estudiantes; i++)
            {
                Console.WriteLine($"{estudiante[i],-25}|");
                double suma=0;
                for (int j = 0; j < max_cursos; j++)
                {
                    Console.WriteLine($"{matriznotas[i,j],-12}|");
                    suma += matriznotas[i, j];
                }
                double promedio=suma/max_cursos;
                string estado = promedio >= 12 ? "Aprobado" : "Desaprobado";
                Console.WriteLine($"{promedio:F2}({estado})");
            }
        }

        static void Main(string[] args)
        {
            int opc=0;
            while (opc != 5) 
            {
                Console.Clear();
                Console.WriteLine("*******************************");
                Console.WriteLine("\tMENU DE OPCIONES");
                Console.WriteLine("*******************************");

                Console.WriteLine("[1]REGISTRAR ESTUDIANTE");
                Console.WriteLine("[2]GUARDAR EN ARCHIVO");
                Console.WriteLine("[3]CARGAR REGISTROS DEL ARCHIVO");
                Console.WriteLine("[4]MOSTRAR REGISTROS");
                Console.WriteLine("[5]SALIR");
                opc = validacion.LeerEntero("Seleccionar opcion [1-5]: ");
                switch (opc)  
                {
                    case 1:
                        RegistrarEstudiante(); break;
                    case 2:
                        guardararchivo(); break;
                    case 3:
                        CargarRegistro(); break;
                    case 4:
                        mostrarRegistro(); break;
                    case 5:
                        Console.WriteLine("Muchos exitos para el nuevo semestre"); break;
                }
                Console.ReadKey();
            }
        }
    }
}
