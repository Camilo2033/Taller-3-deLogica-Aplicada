using System;
using CaballosConflictoLib;

class Program
{
    static void Main()
    {
        Console.Write("Enter the horses' location (ej: B7,C5,E2,H7,G5,F6): ");
        string entrada = Console.ReadLine();
        string[] posiciones = entrada.Split(',');

        var analizador = new AnalizadorCaballos(posiciones);
        analizador.Analizar();
    }
}
