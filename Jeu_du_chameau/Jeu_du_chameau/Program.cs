namespace Jeu_du_chameau
{
    using System;
    using NAudio.Wave;
    using System.Threading;

    internal class Program
    {
        // pour garder en mémoire le nombre d'eau, de nourriture et de nourriture du personnage
        static int eau = 20;
        static int charbon = 20;
        static int nourriture = 20;
        static int distance = 2500;
        static int distanceParcourue = 0;

        static Random random = new Random();

        public static void Main()
        {
            Thread musicThread = new Thread(PlayBackgroundMusic);
            musicThread.IsBackground = true;
            musicThread.Start();

            Debut();
            Command();
        }

        public static void PlayBackgroundMusic()
        {
            try
            {
                string cheminFichier = @"C:\Users\phili\Documents\GitHub\Banques-de-Scripts\Jeu_du_chameau\Jeu_du_chameau\The-Legend-of-Zelda-Spirit-Tracks-Music-Realm-Overworld.wav";
                if (!System.IO.File.Exists(cheminFichier))
                {
                    Console.WriteLine("Le fichier audio est introuvable !");
                    return;
                }

                using (var audioFile = new AudioFileReader(cheminFichier))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    // Maintenir la lecture tant qu'elle est active
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(1000); // Pause pour éviter de surcharger le CPU
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture de la musique : {ex.Message}");
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
            Console.WriteLine(" c : La dernière qui te permet d'afficher le gestionnaire des ressources.");
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
                    Console.WriteLine("Gestionnaire de l'interface de gestion des ressources");
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
            Console.WriteLine("Veux-tu t'arrêter ?");
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
            // rajoute 10 d'eau mais ne permet pas de faire dépasser la capacité max d'eau.
            eau  = Math.Min(eau + 10, 20);
            // rajoute 10 de charbon mais ne permet pas de faire dépasser la capacité max de charbon.
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
                    Console.WriteLine("Ils nous ont volé 5 unités de nourriture.");
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
                    Console.WriteLine("Nous allons traverser une tempête de neige, nous devons utiliser plus de charbon pour garder la chaudière chaude !");
                    Console.WriteLine("Nous avons perdue 5 unités de charbon.");
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
            Console.WriteLine("Veux-tu rejouer ?");
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
            Console.WriteLine("Merci d'avoir jouer !");
            Environment.Exit(0);
        }
    }
}