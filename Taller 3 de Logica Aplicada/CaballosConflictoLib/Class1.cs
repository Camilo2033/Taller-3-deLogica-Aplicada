namespace CaballosConflictoLib
{
    public class Caballo
    {
        public string Posicion { get; set; }

        public Caballo(string pos)
        {
            Posicion = pos.ToUpper();
        }

        public (int fila, int col) ObtenerCoordenadas()
        {
            int col = Posicion[0] - 'A' + 1; // A=1, B=2...
            int fila = int.Parse(Posicion[1].ToString());
            return (fila, col);
        }

        public List<string> MovimientosPosibles()
        {
            var (fila, col) = ObtenerCoordenadas();
            int[,] movimientos = {
                {2, 1}, {2, -1}, {-2, 1}, {-2, -1},
                {1, 2}, {1, -2}, {-1, 2}, {-1, -2}
            };

            List<string> posibles = new List<string>();
            for (int i = 0; i < movimientos.GetLength(0); i++)
            {
                int nuevaFila = fila + movimientos[i, 0];
                int nuevaCol = col + movimientos[i, 1];

                if (nuevaFila >= 1 && nuevaFila <= 8 && nuevaCol >= 1 && nuevaCol <= 8)
                {
                    string pos = $"{(char)('A' + nuevaCol - 1)}{nuevaFila}";
                    posibles.Add(pos);
                }
            }
            return posibles;
        }
    }

    public class AnalizadorCaballos
    {
        private List<Caballo> caballos;

        public AnalizadorCaballos(string[] posiciones)
        {
            caballos = new List<Caballo>();
            foreach (var pos in posiciones)
                caballos.Add(new Caballo(pos));
        }

        public void Analizar()
        {
            foreach (var caballo in caballos)
            {
                var movimientos = caballo.MovimientosPosibles();
                Console.Write($"Analyzing Horse in {caballo.Posicion} =>");

                bool conflicto = false;
                foreach (var otro in caballos)
                {
                    if (otro == caballo) continue;
                    if (movimientos.Contains(otro.Posicion))
                    {
                        Console.Write($" Conflict with{otro.Posicion}");
                        conflicto = true;
                    }
                }
                if (!conflicto) Console.Write(" ");
                Console.WriteLine();
            }
        }
    }
}
