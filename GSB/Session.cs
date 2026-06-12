using GSB.Models;

namespace GSB
{
    /// <summary>
    /// Garde en mémoire le médecin actuellement connecté,
    /// accessible depuis n'importe quel formulaire de l'application.
    /// </summary>
    public static class Session
    {
        public static Doctor? MedecinConnecte { get; set; }
    }
}
