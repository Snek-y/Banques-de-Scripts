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



namespace Jeu_du_chameau
{
    using Microsoft.VisualBasic.FileIO;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Reflection.Metadata.Ecma335;
    using NAudio.Wave;
    using System.Threading;

    internal class Program
    {
        // pour garder en mémoire le nombre d'eau, de nourriture et de fatigue des personnages
        static int eau = 20;
        static int charbon = 20;
        static int nourriture = 20;
        static int distance = 2500;
        static int distanceParcourue = 0;

        static Random random = new Random();

        public static void Main()
        {
            string filepath = @"C:\Users\rebel\Documents\GitHub\Banques-de-Scripts\Jeu_du_chameau\PlayMusic\The-Legend-of-Zelda-Spirit-Tracks-Music-Realm-Overworld.wav";

            Thread musicThread = new Thread(() => PlayMusic(filepath));
            musicThread.IsBackground = true;
            musicThread.Start();

            Debut();
            Command();

            while (true)
            {
                var key = Console.ReadKey(intercept: true).Key;
            }
        }

        // Texte d'histoire et d'explication pour le joueur
        public static void Debut()
        {
            Console.WriteLine("Le monde dans lequel vous vous trouvez a été détruit durant la dernière guerre.");
            Console.WriteLine("Seuls vous et votre train êtes encore en vie.");
            Console.WriteLine("Vous venez de la ville de Soleanna et votre voyage doit vous mener jusqu'à la ville d'Hibernia, connue comme la seule ville encore debout.");


            Console.WriteLine("Pour conduire ton train tu as le choix entre 3 commandes : ");
            Console.WriteLine(" a : La première consiste à faire avancer ton train à vitesse normale.");
            Console.WriteLine(" b : La seconde consiste à faire avancer ton train à une plus grande vitesse.");
            Console.WriteLine(" c : La dernière qui te permet d'afficher le gestionnaire d'état.");
            Console.WriteLine("Que veux-tu faire ?");
        }

        // Appeler au début du jeu grâce au Main() et permet de récupérer les touches du joueur
        public static void Command()
        {
            
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine("tu avances de 20 km");
                    Vitesse1();
                    break;

                case "b":
                    Console.WriteLine("Tu avances de 40 km");
                    Vitesse2();
                    break;

                case "c": 
                    Console.WriteLine("Gestionnaire de l'UI");
                    UI();
                    break;
                
                default:
                    Console.WriteLine("Tu t'es trompé de touche !");
                    Console.WriteLine("Que veux-tu faire ?");
                    Console.WriteLine("Tu as le choix entre : a, b ou c");
                    Console.Beep();
                    Command();
                    break;
            }
        }
        
        // permet d'afficher l'ui quand il est appeler
        public static void UI()
        {
            Console.WriteLine($"Eau restante : {eau} unités");
            Console.WriteLine($"Charbon restant : {charbon} unités");
            Console.WriteLine($"Nourriture restante : {nourriture} unités");
            Console.WriteLine($"Distance restante : {distance} km");
            Console.WriteLine($"Distance parcourue : {distanceParcourue} km");
            Command();
        }


        public static void Vitesse1()
        {
            eau -= 1;
            charbon -= 1;
            distance -= 20;
            distanceParcourue += 20;

            if(distanceParcourue % 50 == 0)
            {
                Nuit();
            }

            if (distanceParcourue % 30 == 0)
            {
                Evenment();
            }

            VerifiedRessources();
            Command();
        }

        public static void Vitesse2()
        {
            eau -= 2;
            charbon -= 2;
            distance -= 40;
            distanceParcourue += 40;

            if (distanceParcourue % 50 == 0)
            {
                Nuit();
            }

            if(distanceParcourue % 30 == 0)
            {
                Evenment();
            }
            
           VerifiedRessources();
            VerifiedDistance();
            Command();
        }

        public static void VerifiedRessources()
        {
            if (charbon <= 0 || eau <= 0 || nourriture <= 0)
            {
                Die();
            }
        }

        public static void VerifiedDistance()
        {
            if (distance <= 0)
            {
                Victory();
            }
        }

        public static void Nuit()
        {
            Console.WriteLine("C'est la nuit.");
            Console.WriteLine("Tu arrives à une gare.");
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
                    Console.WriteLine("Tu te décides à continuer ton chemin de nuit !");
                    Command();
                    break;

                default:
                    Console.WriteLine("Tu t'es trompé de touche !");
                    Console.WriteLine("Que veux-tu faire ?");
                    Console.WriteLine("Tu as le choix entre : y ou n");
                    Console.Beep();
                    Repos();
                    break;
            }
        }

        public static void Matin()
        {
            nourriture -= 5;
            eau  = Math.Min(eau + 10, 20);
            charbon = Math.Min(charbon +10, 20);
            
            VerifiedRessources();
            Command();
        }

        public static void Evenment()
        {
            int eventNum = random.Next(1, 5);

            switch (eventNum)
            {
                case 1:
                    ProbEau();
                    break;

                case 2:
                    ProbBan();
                    break;

                case 3:
                    ProbNei();
                    break;
                
                case 4:
                    Bouffe();
                    break;
                      
                default :
                    Console.WriteLine("Il ne se passe rien aujourd'hui !");
                    Command();
                    break;
            }
        }

        public static void ProbEau()
        {
            int eventFuite = random.Next(0, 3);
            switch (eventFuite)
            {
                case 1:
                    Console.WriteLine("Oh non, le réservoir d'eau a une fuite, nous avons perdue 5 unités d'eau !");
                    Console.WriteLine("Regarde avec la touche c pour vérifier ce qu'il te reste en eau !");
                    eau -= 5;
                    break;
                    
                case 2:
                    Console.WriteLine("Pas de prôblème avec l'eau aujourd'hui !");
                    break;
            }

            Command();
        }

        public static void ProbBan()
        {
            int eventBandie = random.Next(0, 3);
            switch (eventBandie)
            {
                case 1:
                    Console.WriteLine("Nous avons croisez des bandits et ils nous ont volé de la nourriture !");
                    Console.WriteLine($"Ils nous ont volé 5 unités de nourriture.");
                    nourriture -= 5;
                    break;
                
                case 2:
                    Console.WriteLine("Nous avons croiser des bandits mais heureusement ils ne nous ont rien voler !");
                    break;

            }

            Command();
        }

        public static void ProbNei()
        {
            int eventNeige = random.Next(0, 3);
            switch (eventNeige)
            {
                case 1:
                    Console.WriteLine("Nous avons traversons une tempête de neige, nous devons utiliser plus de charbon pour garder la chaudière chaude !");
                    Console.WriteLine($"Nous avons perdue 5 unités de charbon.");
                    charbon -= 5;
                    break;

                case 2:
                    Console.WriteLine("La tempête de neige est heureusement passé loin du train !");
                    break;

            }

            Command();
        }

        public static void Bouffe()
        {
            Console.WriteLine("Tu as trouver une caisse de nourriture sur les rails.");
            Console.WriteLine("Veux-tu la récupéré ?");
            Console.WriteLine(" y : yes.");
            Console.WriteLine(" n : no.");

            switch (Console.ReadLine())
            {
                case "y":
                    Console.WriteLine("tu récupère 5 unités de nourritures");
                    nourriture += 5;
                    Command();
                    break;

                case "n":
                    Console.WriteLine("tu ne récupère pas de nourriture");
                    Command();
                    break;
                
                default:
                    Console.Beep();
                    Console.WriteLine("Tu t'es trompé de touche !");
                    Bouffe();
                    break;
            }
        }

        public static void Die()
        {
            Console.WriteLine("Tu as perdu.");
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
                    ResetGame();
                    Main();
                    break;

                case "n":
                    Console.WriteLine("Merci d'avoir joué !");
                    Environment.Exit(0);
                    break;
                    
                default:
                    Console.WriteLine("Tu t'es trompé de touche !");
                    Console.WriteLine("Que veux-tu faire ?");
                    Console.WriteLine("Tu as le choix entre : y ou n");
                    Console.Beep();
                    Retry();
                    break;
            }
        }

        public static void ResetGame()
        {
            eau = 20;
            charbon = 20;
            nourriture = 20;
            distance = 2500;
            distanceParcourue = 0;
        }

        public static void Victory()
        {
            Console.WriteLine("Bravo, tu as gagné !");
        }

        public static void PlayMusic(string filepath)
        {
            using (var audioFile = new AudioFileReader(filepath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
        }
    }
}