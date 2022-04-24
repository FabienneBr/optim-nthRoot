/*
Write a method that returns the nth root of a given positive number.
Method signature
public static double GetNthRoot(double number, int n)
Assume following
·         number >= +1.00
·         root   >= +1
Rules:
·         You can only use 4 basic math operations + - * /
·         You cannot use any Math.* methods
*/
namespace optim_nthRoot
{
    /// <summary>
    /// Ensemble de méthodes utiles pour des calculs mathématique
    /// </summary>
    public static class MathTools
    {
        /// <summary>
        /// Obtient la racine Nième du nombre avec une précision à 10 décimales
        /// </summary>
        public static double GetNthRoot(double number, int n)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException(nameof(number));
            if (n < 1)
                throw new ArgumentOutOfRangeException(nameof(n));

            int iteration = 0;
            //choix de l'approximation initiale
            double approx = 5.0;
            double previous = approx;
            //On itère pour affiner l'approximation jusqu'à la précision à 10 décimales
            do
            {
                iteration++;
                previous = approx;
                approx = GetNthRootNext(number, n, approx);
                Console.WriteLine(approx);
            }
            while (!Stop(previous, approx));           
            return approx;
        }

        /// <summary>
        /// Obtient vrai si la condition de fin d'itération est atteinte :
        /// - Ecart entre les 2 dernières approximations de moins de 0.0000000001 par défaut
        /// </summary>
        private static bool Stop(double previous, double current, double precision = 0.0000000001)
        {
            var diff = previous - current;
            if (diff < 0) diff *= -1;
            return diff < precision;
        }

        /// <summary>
        /// Obtient la valeur d'approximation à partir de l'approximation précédente x
        /// Implémentation de la formule de racine Nième https://fr.wikipedia.org/wiki/Algorithme_de_calcul_de_la_racine_n-i%C3%A8me
        /// </summary>
        private static double GetNthRootNext(double number, int n, double x)
        {
            return (1 / (double)n) * ((n - 1) * x + (number / GetPowNth(x, n - 1)));
        }

        /// <summary>
        /// Obtient la puissance "n" du nombre fourni.
        /// </summary>
        public static double GetPowNth(double number, int n)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException(nameof(number));
            if (n < 1)
                throw new ArgumentOutOfRangeException(nameof(n));

            var result = number;
            //On préfère la boucle à la récursivité pour éviter d'empiler les appels.
            for (int i = n; i > 1; i--)
                result *= number;
            return result;
        }
    }
}
