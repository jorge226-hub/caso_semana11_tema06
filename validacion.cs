using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace caso_semana11_tema06
{
    internal class validacion
    {
        public static int LeerEntero(string mensaje) 
        {
            int valor;
            while (true) { 
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor<0 || valor > 20)
                    {
                        Console.WriteLine("ERROR 001: El valor debe ser entre [1,5]");
                        continue;
                    }
                    return valor ;
                }
                Console.WriteLine("ERROR 002: El valor debe ser numerico entero");
            }
       
        
        }
        public static double Leerdecimales(string mensaje) 
        {
            double valor;
            while (true) 
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 0 || valor > 20) 
                    {
                        Console.WriteLine("Error 003: La nota es entre [0-20]");
                        continue;
                    }
                    return valor ;
                }
                Console.WriteLine("Error 004: El valor debe ser numerico decimal");
         
            }
        
        }
        public static string Leertexto(string mensaje) 
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(texto)) 
                
                    return texto;
                Console.WriteLine("Error 005: Este campo no puede estar vacio");
                
            }
            
        }   
    }
        
}
