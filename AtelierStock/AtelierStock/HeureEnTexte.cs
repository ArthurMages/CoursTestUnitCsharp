using System;

namespace AtelierStock
{
    public static class HeureEnTexte
    {
        public static string Convertir(DateTime dt)
        {
            int heure = dt.Hour;
            int minute = dt.Minute;
            int minuteArrondie = (minute / 5) * 5;
            int ecart = minute - minuteArrondie;

            // Cas minutes précises (non multiples de 5)
            if (minute % 5 != 0)
            {
                if (minute <= 30)
                    minuteArrondie = ((minute + 4) / 5) * 5;
                else
                    minuteArrondie = ((minute + 4) / 5) * 5;

                string resultat = ConvertirTranche5Min(heure, minuteArrondie);
                int diff = Math.Abs(minute - minuteArrondie);
                return resultat + (diff == 1 ? " à une minute près" : $" à {NombreEnTexte(diff)} minutes près");
            }

            return ConvertirTranche5Min(heure, minute);
        }

        private static string ConvertirTranche5Min(int heure, int minute)
        {
            // Heures pile
            if (minute == 0)
            {
                if (heure == 0) return "minuit";
                if (heure == 12) return "midi";
                if (heure == 1) return "une heure du matin";
                if (heure > 1 && heure < 12) return NombreEnTexte(heure) + " heures du matin";
                if (heure == 13) return "une heure de l'après-midi";
                return NombreEnTexte(heure - 12) + " heures de l'après-midi";
            }

            // Première demi-heure (5 à 30 minutes)
            if (minute <= 30)
            {
                string heureTexte = heure == 0 ? "minuit" : heure == 12 ? "midi" : null;
                string periode = heureTexte == null ? (heure < 12 ? " du matin" : " de l'après-midi") : "";
                
                if (heureTexte == null)
                    heureTexte = (heure == 1 || heure == 13 ? "une heure" : NombreEnTexte(heure > 12 ? heure - 12 : heure) + " heures");

                if (minute == 15) return heureTexte + " et quart" + periode;
                if (minute == 30) return heureTexte + " et demie" + periode;
                return heureTexte + " " + MinuteEnTexte(minute) + periode;
            }

            // Deuxième demi-heure (35 à 55 minutes) - "moins"
            int heureProchaine = (heure + 1) % 24;
            int minutesRestantes = 60 - minute;
            string heureTexteProchaine;
            string periodeProchaine;

            if (heureProchaine == 0 || heureProchaine == 1)
            {
                heureTexteProchaine = "une heure";
                periodeProchaine = " du matin";
            }
            else if (heureProchaine == 12)
            {
                heureTexteProchaine = "midi";
                periodeProchaine = "";
            }
            else if (heureProchaine == 13)
            {
                heureTexteProchaine = "une heure";
                periodeProchaine = " de l'après-midi";
            }
            else if (heureProchaine < 12)
            {
                heureTexteProchaine = NombreEnTexte(heureProchaine) + " heures";
                periodeProchaine = " du matin";
            }
            else
            {
                heureTexteProchaine = NombreEnTexte(heureProchaine - 12) + " heures";
                periodeProchaine = " de l'après-midi";
            }

            if (minutesRestantes == 15) return heureTexteProchaine + " moins le quart";
            return heureTexteProchaine + " moins " + MinuteEnTexte(minutesRestantes) + periodeProchaine;
        }

        private static string NombreEnTexte(int n)
        {
            string[] nombres = { "zéro", "une", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze" };
            return n >= 0 && n <= 12 ? nombres[n] : n.ToString();
        }

        private static string MinuteEnTexte(int minute)
        {
            if (minute == 5) return "cinq";
            if (minute == 10) return "dix";
            if (minute == 20) return "vingt";
            if (minute == 25) return "vingt-cinq";
            return minute.ToString();
        }
    }
}