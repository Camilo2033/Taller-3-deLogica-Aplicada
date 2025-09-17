using System;
using VigaResistenteLib;

class Program
{
    static void Main()
    {
        Console.Write("Enter the beam: ");
        string entrada = Console.ReadLine();

        var viga = new Viga(entrada);
        Console.WriteLine(viga.Validar());
    }
}
