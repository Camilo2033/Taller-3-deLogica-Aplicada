namespace VigaResistenteLib
{
    public class Viga
    {
        private readonly string _estructura;

        public Viga(string estructura)
        {
            _estructura = estructura;
        }

        public string Validar()
        {
            if (string.IsNullOrWhiteSpace(_estructura))
                return "The beam is poorly built!";

            char baseViga = _estructura[0];
            int resistencia = baseViga switch
            {
                '%' => 10,
                '&' => 30,
                '#' => 90,
                _ => 0
            };

            if (resistencia == 0) return "The beam is poorly built!";

            int pesoTotal = 0;
            int secuenciaLargueros = 0;
            int pesoConexionAnterior = 0;

            for (int i = 1; i < _estructura.Length; i++)
            {
                char c = _estructura[i];

                if (c == '=')
                {
                    secuenciaLargueros++;
                    pesoTotal += secuenciaLargueros;
                }
                else if (c == '*')
                {
                    if (i > 1 && _estructura[i - 1] == '*')
                        return "The beam is poorly built!"; // dos conexiones seguidas no válidas

                    int pesoConexion = (secuenciaLargueros == 0) ? 0 : 2 * secuenciaLargueros;
                    if (pesoConexionAnterior > 0) pesoConexion = 2 * pesoConexionAnterior;

                    pesoTotal += pesoConexion;
                    pesoConexionAnterior = pesoConexion;
                    secuenciaLargueros = 0;
                }
                else
                {
                    return "The beam is poorly built!";
                }
            }

            return (pesoTotal <= resistencia)
                ? "The beam supports the weight!"
                : "The beam does NOT support the weight!";
        }
    }
}
