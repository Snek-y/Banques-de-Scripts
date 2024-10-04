// Le jeu du chameau est un jeu textuel classique qui peut être un excellent projet de programmation, particullièrement pour les débutants ou les intermédiaires.
// Voici une description du jeu et quelques idées pour le réaliser en programmation :
// Description du jeu :

//Le jeu du chameau est une aventure textuelle où le joueur traverse un désert sur un chameau.
// L'objetif est de parcourir une certaine distance tout en gérant ses ressources et en évitant divers dangers.
// éléments clés du jeu :

// 1. Distance à parcourir : le joueur doit atteindre un point d'arrivé spécifique.

// 2. Ressources à gérer :
//                - Eau pour le joueur et le chameau
//                - Nourriture pour le joueur
//                - Fatigue du chameau

// 3. Actions possibles à chaque tour :
//                - Avancer à vitesse normale
//                - Avancer rapidement (couvre plus de distance mais fatigue plus le chameau)
//                - Se reposer (récupère de la fatigue mais consomme des ressources)
//                - Chercher de l'eau/nourriture (chance de trouver des ressources mais risque de rencontrer des dangers)

// 4. Evénement aléatoires :
//               - Tempêtes de sable
//               - Rencontre avec des bandits
//               - Oasis
//               - Puits abandonné

// 5. Fin du jeu :
//              - Victoire : atteindre la destination
//              - Défaite : manquer de ressources vitales ou rencontrer un danger fatal

//idées pour la réalisation en programmation :
//             - Structure : Utilisez une boucle principale pour les tours de jeu.
//             - Gestion de l'état : créez des variables pour suivre les ressources et la distance parcourue.
//             - Intéractivité : Utilisez des entrées utilisateur pour les choix d'actions.
//             - Evénements aléatoires : Implémentez un générateur de nombres aléatoires pour déclencher des événements.
//             - Affichage : Créez des fonctions pour affichez l'état du jeu et les messages.
//             - Logique de jeu : Implémentez des fonctions pour chaque action et événement possible.









/// Itération GD du jeu du chameau :
/// Le joueur est conducteur d'un train à vapeur et il devra gérer le moteur de sa locomotive et son énergie pour remplir le moteur en charbon et en eau.
/// Le train peut avancer à vitesse normal cela consomme un charbon et un d'eau.
/// Le train peut avancer à vitesse rapide cela consomme deux charbons et deux d'eau.
/// La nourriture du joueur sert durant la journée pour le contrôle le train.
/// à la fin de chaque tour le train récupère un peu de charbon et un peu d'eau pour continuer le voyage.
/// rajouter un choix d'éguillage.

/// Gestion de l'état :
///          - nourriture pour le joueur. 
///          - eau de refroidissement moteur du train.
///          - Charbon pour faire avancer le train.
///          - La distance restante à parcourir.

/// événement aléatoire :
///          - Panne de charbon (parce que l'on a mal géré notre réserve de charbon).
///          - fuite d'eau
///          - bandits
///          - Tempête de neige
///          - Surchauffe moteur (lier à l'événement fuite d'eau)
///          - Seulement si possible : Explosion du moteur (lier à l'événement fuite d'eau)

///
namespace Jeu_du_chameau
{
    internal class Program
    {
        // pour garder en mémoire le nombre d'eau, de nourriture et de fatigue des personnages
        static int eau = 10;
        static int charbon = 10;
        static int nourriture = 20;
        static int distance = 250;

        public static void Main()
        {
            Debut();
            Command();
        }

        // Texte d'histoire et d'explication pour le joueur
        public static void Debut()
        {
            Console.WriteLine("Le monde dans lequelle vous vous trouvez a été détruits durant la dernière guerre.");
            Console.WriteLine("seul vous et votre train êtes encore en vie");
            Console.WriteLine("Vous venez de la ville de et votre voyage doit vous emenez jusqu'à la ville de , elle est connue comme étant la seule ville encore debout");

            Console.WriteLine("Pour conduire ton train tu as le choix entre 3 commandes : ");
            Console.WriteLine(" a : La première consiste à faire avancer ton train à la vitesse normal.");
            Console.WriteLine(" b : La seconde consiste à faire avancer ton train à plus grande vitesse.");
            Console.WriteLine(" c : La dernière qui te permet d'afficher le gestionnaire d'état.");
            Console.WriteLine("Que fais-tu ?");
        }

        // Appeler au début du jeu grâce au Main() et permet de récupérer les touches du joueur
        public static void Command()
        {
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine("tu avance de 1");
                    Vitesse1();
                    break;

                case "b":
                    Console.WriteLine("Tu avance de 2");
                    Vitesse2();
                    break;

                case "c": 
                    Console.WriteLine("Gestionnaire de l'UI");
                    UI();
                    break;
            }
        }
        
        // permet d'afficher l'ui quand il est appeler
        public static void UI()
        {
            Console.WriteLine("Eau : reste " + eau + " d'eau");
            Console.WriteLine("Charbon : reste " + charbon + " de charbon");
            Console.WriteLine("Nourriture : reste " + nourriture + " de nourriture");
            Console.WriteLine("Distance : reste " + distance + " km de rail");
            Command();
        }


        public static void Vitesse1()
        {
            eau -= 1;
            charbon -= 1;
            distance -= 1;

            if (eau > 0)
            {
                Command();
            }
            else if (eau == 0)
            {
                Die();
            }
        }

        public static void Vitesse2()
        {
            eau -= 2;
            charbon -= 2;
            distance -= 2;

            if (eau > 0)
            {
                Command();
            }
            else if (eau == 0)
            {
                Die();
            }
        }

        public static void Nuit()
        {
            Console.WriteLine("C'est la nuit.");
            Console.WriteLine("tu arrive à une gare.");
            Console.WriteLine("Veux-tu te reposer ?");
            Console.WriteLine(" y : yes.");
            Console.WriteLine(" n : no.");
            Repos();
        }

        public static void Repos()
        {
            switch (Console.ReadLine())
            {
                case "y":
                    Matin();
                    break;

                case "n":
                    break;
            }
        }

        public static void Matin()
        {
            nourriture -= 2;
            eau +=1;
            charbon += 1;

            if (nourriture > 0)
            {
                Command();
            }
            else if (nourriture == 0)
            {
                Die();
            }
        }

        public static void Evenment(Random random)
        {
            

            switch (random.Next(0, 5))
            {
                case 1:
                    Console.WriteLine("Oh non, on va manquer de charbon !");
                    probChar();
                    break;

                case 2:
                    Console.WriteLine("Oh non, le réservoire d'eau à une fuite !");
                    probEau();
                    break;

                case 3:
                    Console.WriteLine("Oh non, des bandits nous attaque !");
                    probBan();
                    break;

                case 4:
                    Console.WriteLine("Oh non, on va traverser une tempête de neige !");
                    probNei();
                    break;
            }
        }

        public static void probChar()
        {

        }

        public static void probEau()
        {

        }

        public static void probBan()
        {

        }

        public static void probNei()
        {

        }

        public static void Die()
        {
            Console.WriteLine("Tu as perdue");
            Console.WriteLine("Veux-tu recommencer ?");
            Console.WriteLine(" y : yes.");
            Console.WriteLine(" n : no.");
            Retry();
        }

        public static void Retry()
        {
            switch (Console.ReadLine())
            {
                case "y":
                    eau = 10;
                    charbon = 10;
                    nourriture = 20;
                    distance = 250;
                    Main();
                    break;

                case "n":
                    break;
            }
        }
    }
}