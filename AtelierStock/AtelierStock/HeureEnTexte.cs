using System;

namespace AtelierStock
{
    public static class HeureEnTexte
    {
        public static string Convertir(DateTime dt)
        {
            // Cas spéciaux : minuit et midi
            if (dt.Minute == 0)
            {
                if (dt.Hour == 0)
                    return "minuit";
                if (dt.Hour == 12)
                    return "midi";
                if (dt.Hour == 1)
                    return "une heure du matin";
                if (dt.Hour > 1 && dt.Hour < 12)
                    return NombreEnTexte(dt.Hour) + " heures du matin";
                // Après-midi (13h à 23h)
                if (dt.Hour >= 13 && dt.Hour < 24)
                    return NombreEnTexte(dt.Hour - 12) + " heures de l'après-midi";
            }
            return "";
        }

        private static string NombreEnTexte(int n)
        {
            string[] nombres = { "zéro", "une", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze" };
            if (n >= 0 && n <= 12)
                return nombres[n];
            if (n > 12 && n < 24)
                return nombres[n - 12];
            return n.ToString();
        }
    }
}