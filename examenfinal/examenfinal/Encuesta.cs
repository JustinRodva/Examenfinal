using System;
using System.Collections.Generic;

internal class Examenfinal
{
    static List<Encuesta> encuestas = new List<Encuesta>();
    static int numeroEncuesta = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Encuesta:");

            string nombre = PedirDato("Nombre del participante: ");
            int edad = PedirEdad();
            string correo = PedirCorreoElectronico();
            string partidoPolitico = PedirDato("Partido Político (PLN, PUSC, PAC): ");

            Encuesta nuevaEncuesta = new Encuesta(numeroEncuesta, nombre, edad, correo, partidoPolitico);
            encuestas.Add(nuevaEncuesta);
            numeroEncuesta++;

            Console.WriteLine("Encuesta registrada con éxito.");

            Console.WriteLine("¿Desea realizar otra encuesta? (S/N): ");
            string respuesta = Console.ReadLine();
            if (respuesta.Trim().ToUpper() != "S")
            {
                MostrarReporteEncuestas();
                break;
            }
        }
    }

    static string PedirDato(string mensaje)
    {
        string dato;
        do
        {
            Console.Write(mensaje);
            dato = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(dato));
        return dato;
    }

    static int PedirEdad()
    {
        int edad;
        do
        {
            string input = PedirDato("Edad de Nacimiento (entre 18 y 50): ");
            if (int.TryParse(input, out edad) && edad >= 18 && edad <= 50)
            {
                return edad;
            }
            else
            {
                Console.WriteLine("Edad inválida. Debe estar entre 18 y 50 años.");
            }
        } while (true);
    }

    static string PedirCorreoElectronico()
    {
        string correo;
        do
        {
            correo = PedirDato("Correo Electrónico: ");
        } while (!EsCorreoElectronicoValido(correo));
        return correo;
    }

    static bool EsCorreoElectronicoValido(string correo)
    {
        
        return correo.Contains("@");
    }

    static void MostrarReporteEncuestas()
    {
        Console.WriteLine("\nReporte de Encuestas:");
        foreach (var encuesta in encuestas)
        {
            Console.WriteLine($"Numero de encuesta: {encuesta.NumeroEncuesta}");
            Console.WriteLine($"Nombre: {encuesta.Nombre}");
            Console.WriteLine($"Edad: {encuesta.Edad}");
            Console.WriteLine($"Correo Electrónico: {encuesta.CorreoElectronico}");
            Console.WriteLine($"Partido Político: {encuesta.PartidoPolitico}");
            Console.WriteLine("---------------------------");
        }
    }
}

class Encuesta
{
    public int NumeroEncuesta { get; }
    public string Nombre { get; }
    public int Edad { get; }
    public string CorreoElectronico { get; }
    public string PartidoPolitico { get; }

    public Encuesta(int numeroEncuesta, string nombre, int edad, string correoElectronico, string partidoPolitico)
    {
        NumeroEncuesta = numeroEncuesta;
        Nombre = nombre;
        Edad = edad;
        CorreoElectronico = correoElectronico;
        PartidoPolitico = partidoPolitico;
    }
}
