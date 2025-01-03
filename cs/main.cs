using System;
using System.IO;

public static partial class Yams {

  public struct Player
  {
    public int id;               // id du joueur, 1 ou 2 etant donnée que le nombre max de jouer est 2
    public string pseudo;        // pseudo du joueur
    public int[,] dices;         // on va stocker tous les des finaux de chaque rounds
    public bool[] challRestants;     // les challenges encore utilisable par le joueur"▶",
    public int[] challTour;
    public int[] scoreTour;   // les scores de chaque round
    public int bonus;
    public int scoreTotal;       // le score final

    public Player(int id) {
      this.id = id;
      this.pseudo = "Unknown";
      this.dices = new int [13,5];
      this.challRestants = new bool [13] {true, true, true, true, true, true, true, true, true, true, true, true ,true};
      this.challTour = new int [13];
      this.scoreTour = new int [13];
      this.bonus = 0;
      this.scoreTotal = 0;
    }
  }

  public struct Challenge {     // structure de création des challenges
    public string challenge;
    public string objectif;
    public string nombreDePoints;

    public Challenge(string challenge, string objectif, string nombreDePoints) {  // on cree la fonction createchallege pour simplifier l'attribution des differentes valeurs
      this.challenge = challenge;
      this.objectif = objectif;
      this.nombreDePoints = nombreDePoints;
    }

    public override string ToString() {
      return $"| {challenge.PadRight(15)} | {objectif.PadRight(52)}| {nombreDePoints.PadRight(30)} |";
    }

  }
  // on initialise tous les challenges
  public static Challenge nombreDe1 = new Challenge("Nombre de 1","Obtenir le plus grand nombre de 1","Somme des dés ayant obtenu 1");
  public static Challenge nombreDe2 = new Challenge("Nombre de 2","Obtenir le plus grand nombre de 2","Somme des dés ayant obtenu 2");
  public static Challenge nombreDe3 = new Challenge("Nombre de 3","Obtenir le plus grand nombre de 3","Somme des dés ayant obtenu 3");
  public static Challenge nombreDe4 = new Challenge("Nombre de 4","Obtenir le plus grand nombre de 4","Somme des dés ayant obtenu 4");
  public static Challenge nombreDe5 = new Challenge("Nombre de 5","Obtenir le plus grand nombre de 5","Somme des dés ayant obtenu 5");
  public static Challenge nombreDe6 = new Challenge("Nombre de 6","Obtenir le plus grand nombre de 6","Somme des dés ayant obtenu 6");
  public static Challenge brelan = new Challenge("Brelan","Obtenir 3 dés de même valeur","Somme des 3 dés identiques");
  public static Challenge carre = new Challenge("Carré","Obtenir 4 dés de même valeur","Somme des 4 dés identiques");
  public static Challenge full = new Challenge("Full","Obtenir 3 dés de même valeur + 2 dés de même valeur","25 points");
  public static Challenge petiteSuite = new Challenge("Petite Suite","Obtenir 1-2-3-4 ou 2-3-4-5 ou 3-4-5-6","30 points");
  public static Challenge grandeSuite = new Challenge("Grande Suite","Obtenir 1-2-3-4-5 ou 2-3-4-5-6","40 points");
  public static Challenge yams = new Challenge("yams","Obtenir 5 dés de même valeur","50 points");
  public static Challenge chance = new Challenge("Chance","Obtenir le maximum de points","Somme des dés obtenus");

  // on met les challenges dans un tableau challenges, les [0-5] sont pour les challenges mineurs, les [6-12] pour les majeurs.
  public static Challenge[] challenges = new Challenge[13] {nombreDe1,nombreDe2,nombreDe3,nombreDe4,nombreDe5,nombreDe6,brelan,carre,full,petiteSuite,grandeSuite,yams,chance};


  // generateur aleatoire, en dehors de la boucle pour etre accessible partout et garantir plus d'aleatoire
  public static Random rnd = new Random();



  static void Main() {

    Player player1 = new Player(1); // creation du premier joueur dont l'id vaut 1
    Player player2 = new Player(2); // creation du premier joueur dont l'id vaut 2

    Console.Write("Entrez le pseudo du premier joueur : ");
    player1.pseudo = Console.ReadLine();

    Console.Write("Entrez le pseudo du second joueur : ");
    player2.pseudo = Console.ReadLine();

    // tours de jeu
    for ( int i = 0 ; i < 13 ; i++ ) 
    {
      tour(i, ref player1, ref player2);
      tour(i, ref player2, ref player1);
    }

    calcBonus(ref player1);
    calcBonus(ref player2);

    jason(player1, player2);

    Console.WriteLine("La partie est finis, voici vos scores : ");
    Console.WriteLine($"{player1.pseudo} : {player1.scoreTotal}");
    Console.WriteLine($"{player2.pseudo} : {player2.scoreTotal}");
  }

  // numTour indexé à 0, on l'utilise pour attribuer correctement les des et les scores à chaque jouer et noter a quel tour chaque challenge est utilisé
  static void tour (int numTour, ref Player currentPlayer, ref Player adversaire) {

    Console.WriteLine();
    Console.WriteLine($"Debut du tour {numTour+1} de {currentPlayer.pseudo}.");   // numTour+1 car numTour indexé à 0 mais ici info destinée au joueur index à 1. 
    Console.WriteLine();

    // affichage des challenges restant pour le joueur
    challengesRestants( ref currentPlayer);

    // initialisation des des à 0, on met 4 lignes car on verifie si un de peut etre relancer en fonction de l'etait de la meme colonne sur la ligne precedeente, exemple : des[2,3] est relançable seulement si des[1,3] == 0
    int[,] dices = new int[4,5];
    int line = 1;
    bool relance = false;

    // appel fonction principale de tour qui change les 0 en int aleatoire entre 1 et 6 pour la ligne du tour puis demande au joueur quels dés ils souhaitent garder et indique lesquels peuvent être relancé
    lancerDes(ref dices, line, ref relance);

    // on monte d'un niveau dans le tableau des dés

    // on relance les des jusqu'a 2 fois si le joueur decide de relancer certain dés
    for (int i = 0 ; i < 2 ; i++ ) {
      if ( relance ) {
        line++;
        lancerDes(ref dices, line, ref relance);
      }
    }

    // on enregistre les des finaux dans la structure du joueur
    for (int i = 0 ; i < 5 ; i++ ) {
      currentPlayer.dices[numTour,i] = dices[line,i];
    }

    challengesRestants( ref currentPlayer);


    int choix = -1;
    bool validiteChoix = false;

    // on verifie si le challenge est encore jouable
    while ( validiteChoix == false ) {
      Console.Write("Quel challenge souhaitez-vous jouer ? (entrez 0 pour voir la liste des challenges, -1 pour le score actuel) : ");

      if ( !int.TryParse(Console.ReadLine(), out choix) ) 
      {
        validiteChoix = false;
        choix = -10;
      } 
      choix--;

      Console.WriteLine();

      if ( choix == -1 ) 
      {
        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("| CHALLENGE       | OBJECTIF                                            | POINTS                         |");
        for ( int i = 0 ; i < 13 ; i++ ) {
          if ( currentPlayer.challRestants[i] ) {
            Console.WriteLine("|-----------------|-----------------------------------------------------|--------------------------------|");
            Console.WriteLine(challenges[i].ToString());
          }
        }
        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.Write($"(Rappel de vos dés : ");
        for (int i = 0 ; i < 5 ; i++ ) {
          Console.Write($"{dices[line,i]}. ");
        }
        Console.WriteLine(")\n");
      } 
      else if ( choix == -2 ) 
      {
        scoresActuels(ref currentPlayer, ref adversaire);
      }
      else if ( choix >= -1 && choix < 13 && currentPlayer.challRestants[choix] ) 
      {
        validiteChoix = true;
        currentPlayer.challRestants[choix] = false;
        currentPlayer.challTour[numTour] = choix;
      } 
      else 
      {
        Console.WriteLine("Vous devez choisir un nombre entre 0 et 13 (inclus).");
      }
    }

    // on calcule le score
    calcScore(choix, numTour, ref currentPlayer);
    Console.WriteLine($"Vous avez choisis le challenge {challenges[choix].challenge}, cela vous rapporte {currentPlayer.scoreTour[numTour]} points, pour un score total de {currentPlayer.scoreTotal} points. ");

    Console.WriteLine($"Le tour est finis, appuyez sur une entrée pour continuer.");
    Console.ReadLine();
    Console.WriteLine();
  }


  // on verifie les challenges pas encore utilisés par le jouer pour les lui afficher
  public static void challengesRestants(ref Player currentPlayer){
    Console.WriteLine("Voici les challenges qui n'ont pas encore été joués : ");
    for (int i = 0; i < 13; i++) {
      if (currentPlayer.challRestants[i] ) {
        /*Console.Write("{0, 2}", i+1);*/
        Console.Write("{0:00}", i+1);
        Console.WriteLine($" - { challenges[i].challenge}");
      }
    }
    Console.WriteLine();
  }


  // on jette les des qui doivent l'etre
  public static void lancerDes (ref int[,] dices, int line, ref bool relance) {

    relance = false;

    for (int i = 0 ; i <  5 ; i++) {
      if ( dices[line,i] == 0 ) {
        dices[line,i] = rnd.Next(1,7);
      }
    }

    Console.Write($"Voici vos dés : ");
    for (int i = 0 ; i < 5 ; i++ ) {
      Console.Write($"{dices[line,i]}. ");
    }
    Console.WriteLine();
    afficheDes(dices, line);


    if ( line < 3 ) {
      // choix du joueur
      for ( int i = 0 ; i < 5 ; i++ ) {
        Console.Write($"Souhaitez-vous garder le dé numéro {i+1} qui vaut {dices[line,i]} ? y/*. ");
        afficheUnDes(dices,line,i);
        if ( 'y' == Console.ReadKey().KeyChar ) {
          dices[line+1,i] = dices[line,i];
        }
        else {
          dices[line,i] = 0;
          relance = true;
        }
        Console.WriteLine();
      }
    }
    Console.WriteLine();
  }

  public static void scoresActuels(ref Player currentPlayer, ref Player adversaire)
  {
    Console.WriteLine($"{currentPlayer.pseudo} a actuellement {currentPlayer.scoreTotal} points et {adversaire.pseudo} {adversaire.scoreTotal}\n");
  }

  public static void calcScore( int choix, int numTour, ref Player currentPlayer) {

    int score = 0;

    // debug, affiche les dés
    /*for (int i = 0 ; i < 5 ; i++) {*/
    /*  Console.Write(currentPlayer.dices[numTour,i]);*/
    /*}*/

    if ( choix < 6 ) {
      for ( int i = 0 ; i < 5 ; i++ ) {
        if ( currentPlayer.dices[numTour,i] == choix+1 ) {
          score += choix+1;
        }
      }
    } else {
      switch (choix)
      {
        // brelan
        case 6:
          for (int i = 1 ; i <= 6 ; i++) {   // pour chaque valeur possible du dé
            int compteur = 0;
            for (int j = 0 ; j < 5 ; j++) {       // Compter le nombre de fois la valeur apparait
              if (currentPlayer.dices[numTour,j] == i) {
                compteur++;
              }
            }
            if (compteur >= 3) {
              score = 3*i;
            }
          }
          break;

          // carre
        case 7:
          for (int i = 1 ; i <= 6 ; i++) {   // pour chaque valeur possible du dé
            int compteur = 0;
            for (int j = 0; j < 5; j++) {       // Compter le nombre de fois la valeur apparait
              if (currentPlayer.dices[numTour,j] == i) {
                compteur++;
              }
            }
            if (compteur >= 4) {
              score = 4*i;
            }
          }
          break;

          // full
        case 8:
          bool trois = false;  // 3 dés de mm valeurs
          bool deux = false;   // 2 dés de mm valeurs

          for (int i = 1; i <= 6; i++) {
            int compteur = 0;
            for (int j = 0; j < 5; j++) {
              if (currentPlayer.dices[numTour,j] == i) {
                compteur++;
              }
            }
            if (compteur == 3) trois = true;
            if (compteur == 2) deux = true;
          }
          if (trois && deux) {   
            score = 25;
          }
          break;

          // petite Suite
        case 9:
          bool un = false, quatre = false, cinq = false, six = false;
          deux = false;
          trois = false;

          for (int i = 0; i < 5; i++) {
            if (currentPlayer.dices[numTour,i] == 1) {
              un = true;
            }
            if (currentPlayer.dices[numTour,i] == 2) {
              deux = true;
            }
            if (currentPlayer.dices[numTour,i] == 3) {
              trois = true;
            }
            if (currentPlayer.dices[numTour,i] == 4) {
              quatre = true;
            }
            if (currentPlayer.dices[numTour,i] == 5) {
              cinq = true;
            }
            if (currentPlayer.dices[numTour,i] == 6) {
              six = true;
            }
          }
          if ((un && deux && trois && quatre) || (deux && trois && quatre && cinq) || (trois && quatre && cinq && six)) {
            score = 30;
          }
          break;

          // grande suite
        case 10:
          un = false;
          deux = false;
          trois = false;
          quatre = false;
          cinq = false;
          six = false;

          for (int i = 0; i < 5; i++) {
            if (currentPlayer.dices[numTour,i] == 1) {
              un = true;
            }
            if (currentPlayer.dices[numTour,i] == 2) {
              deux = true;
            }
            if (currentPlayer.dices[numTour,i] == 3) {
              trois = true;
            }
            if (currentPlayer.dices[numTour,i] == 4) {
              quatre = true;
            }
            if (currentPlayer.dices[numTour,i] == 5) {
              cinq = true;
            }
            if (currentPlayer.dices[numTour,i] == 6) {
              six = true;
            }
          }
          if ((un && deux && trois && quatre && cinq) || (deux && trois && quatre && cinq && six)) {
            score = 40;
          }
          break;

          // yams
        case 11:
          int tmp = 50;

          int d = currentPlayer.dices[numTour,0];
          for (int i = 1 ; i < 5 ; i++) {
            if ( d != currentPlayer.dices[numTour,i] ) {
              tmp = 0;
            }
          }
          score = tmp;
          break;

          // chance
        case 12:
          tmp = 0;
          for ( int i = 0 ; i < 5 ; i++ ) {
            tmp += currentPlayer.dices[numTour,i];
          }
          score = tmp;
          break;

        default:
          break;
      } 
    }
    currentPlayer.scoreTour[numTour] = score;
    currentPlayer.scoreTotal += score;
  }


  public static void calcBonus(ref Player currentPlayer) {
    int somme = 0;  // somme des scores
    currentPlayer.bonus = 0;
    // on additionne les scores des 6 premiers challenges (mineurs)
    for ( int i = 0 ; i < 13 ; i++ ) {
      if ( currentPlayer.challTour[i] < 6 ) {
        somme += currentPlayer.scoreTour[i];
      }
    }
    if (somme >= 63) {
      currentPlayer.bonus = 35;
    } 
    currentPlayer.scoreTotal += currentPlayer.bonus;
  }

  public static void jason(Player player1, Player player2) {
    // Génération du JSON
    string json = "{\n" +
      "  \"parameters\": {\n" +
      "    \"code\": \"groupe1-001\",\n" +
      "    \"date\": \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\"\n" +
      "  },\n" +
      "  \"players\": [\n" +
      "    {\n" +
      "      \"id\": " + player1.id + ",\n" +
      "      \"pseudo\": \"" + player1.pseudo + "\"\n" +
      "    },\n" +
      "    {\n" +
      "      \"id\": " + player2.id + ",\n" +
      "      \"pseudo\": \"" + player2.pseudo + "\"\n" +
      "    }\n" +
      "  ],\n" +
      "  \"rounds\": [\n" +
      Rounds(player1, player2) + "\n" +
      "  ],\n" +
      "  \"final_result\": [\n" +
      FinalResult(player1, player2) + "\n" +
      "  ]\n" +
      "}";

    // Sauvegarder dans un fichier
    using (StreamWriter writer = new StreamWriter("res.json")) {
      writer.WriteLine(json);
    }
  }

  public static string Rounds(Player player1, Player player2) {
    string rounds = "";
    for (int i = 0; i < 13; i++) { // Afficher 13 rounds
      rounds += "    {\n" +
        "      \"id\": " + (i + 1) + ",\n" + // ID des rounds commence à 1
        "      \"results\": [\n" +
        "        {\n" +
        "          \"id_player\": " + player1.id + ",\n" +
        "          \"dice\": [" + Des(player1.dices, i) + "],\n" +
        "          \"challenge\": \"" + ChallengeName(player1.challTour[i]) + "\",\n" +
        "          \"score\": " + player1.scoreTour[i] + "\n" +
        "        },\n" +
        "        {\n" +
        "          \"id_player\": " + player2.id + ",\n" +
        "          \"dice\": [" + Des(player2.dices, i) + "],\n" +
        "          \"challenge\": \"" + ChallengeName(player2.challTour[i]) + "\",\n" +
        "          \"score\": " + player2.scoreTour[i] + "\n" +
        "        }\n" +
        "      ]\n" +
        "    }";

      if (i < 12) { // Ajouter une virgule sauf pour le dernier round
        rounds += ",";
      }
      rounds += "\n";
    }
    return rounds;
  }

  public static string Des(int[,] dices, int round) {
    string res = "";
    for (int i = 0; i < dices.GetLength(1); i++) {
      res += dices[round, i];
      if (i < dices.GetLength(1) - 1) {
        res += ", ";
      }
    }
    return res;
  }

  public static string ChallengeName(int challengeId) {
    string[] challenges = { "nombreDe1","nombreDe2","nombreDe3","nombreDe4","nombreDe5","nombreDe6","brelan","carre","full","petiteSuite","grandeSuite","yams","chance" };
    return challenges[challengeId];
  }

  public static string FinalResult(Player player1, Player player2) {
    return "    {\n" +
      "      \"id_player\": " + player1.id + ",\n" +
      "      \"bonus\": " + player1.bonus + ",\n" +
      "      \"score\": " + player1.scoreTotal + "\n" +
      "    },\n" +
      "    {\n" +
      "      \"id_player\": " + player2.id + ",\n" +
      "      \"bonus\": " + player2.bonus + ",\n" +
      "      \"score\": " + player2.scoreTotal + "\n" +
      "    }";
  }




  // les trucs useless mais stylés
  public static void afficheDes (int[,] dices, int line) {

    for (int i = 0 ; i < 5 ; i++) {
      Console.Write("  -------  ");
    }
    Console.WriteLine();

    for (int i = 0 ; i < 5 ; i++) {
      switch (dices[line,i]) {
        case 1: 
          Console.Write(" |       | ");
          break;
        case 2: 
          Console.Write(" | 2     | ");
          break;
        case 3: 
          Console.Write(" | 3     | ");
          break;
        case 4: 
          Console.Write(" | 4   4 | ");
          break;
        case 5: 
          Console.Write(" | 5   5 | ");
          break;
        case 6: 
          Console.Write(" | 6   6 | ");
          break;
      }
    }
    Console.WriteLine();
    for (int i = 0 ; i < 5 ; i++) {
      switch (dices[line,i]) {
        case 1: 
          Console.Write(" |   1   | ");
          break;
        case 2: 
          Console.Write(" |       | ");
          break;
        case 3: 
          Console.Write(" |   3   | ");
          break;
        case 4: 
          Console.Write(" |       | ");
          break;
        case 5: 
          Console.Write(" |   5   | ");
          break;
        case 6: 
          Console.Write(" | 6   6 | ");
          break;
      }
    }
    Console.WriteLine();
    for (int i = 0 ; i < 5 ; i++) {
      switch (dices[line,i]) {
        case 1: 
          Console.Write(" |       | ");
          break;
        case 2: 
          Console.Write(" |     2 | ");
          break;
        case 3: 
          Console.Write(" |     3 | ");
          break;
        case 4: 
          Console.Write(" | 4   4 | ");
          break;
        case 5: 
          Console.Write(" | 5   5 | ");
          break;
        case 6: 
          Console.Write(" | 6   6 | ");
          break;
      }
    }
    Console.WriteLine();
    for (int i = 0 ; i < 5 ; i++) {
      Console.Write("  -------  ");
    }
    Console.WriteLine();
    Console.WriteLine();
  }

  public static void afficheUnDes (int[,] dices, int line, int i) {
    switch (dices[line,i])
    {
      case 1:
        Console.WriteLine(@"
             -------
            |       |
            |   1   |
            |       |
             -------");
            break;

      case 2:
        Console.WriteLine(@"
           -------
          | 2     |
          |       |
          |     2 |
           -------");
           break;

      case 3:
        Console.WriteLine(@"
           -------
          | 3     |
          |   3   |
          |     3 |
           -------");
           break;

      case 4:
        Console.WriteLine(@"
           -------
          | 4   4 |
          |       |
          | 4   4 |
           -------");
           break;

      case 5:
        Console.WriteLine(@"
           -------
          | 5   5 |
          |   5   |
          | 5   5 |
           -------");
           break;

      case 6:
        Console.WriteLine(@"
           -------
          | 6   6 |
          | 6   6 |
          | 6   6 |
           -------");
        break;
    }
  }
}
