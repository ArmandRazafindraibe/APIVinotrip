using System;

namespace APIVinotrip.Helpers
{
    public static class PasswordHasher
    {
        // Coût du hachage (nombre d'itérations)
        // Plus cette valeur est élevée, plus le hachage sera lent mais sécurisé
        // Recommandé : entre 10 et 12 pour un bon équilibre performance/sécurité
        private const int WorkFactor = 12;

        /// <summary>
        /// Hache un mot de passe en utilisant BCrypt
        /// </summary>
        /// <param name="password">Mot de passe en clair</param>
        /// <returns>Hachage BCrypt du mot de passe</returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        /// <summary>
        /// Vérifie si un mot de passe correspond à un hachage
        /// </summary>
        /// <param name="password">Mot de passe en clair à vérifier</param>
        /// <param name="hashedPassword">Hachage BCrypt stocké</param>
        /// <returns>True si le mot de passe correspond, False sinon</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}