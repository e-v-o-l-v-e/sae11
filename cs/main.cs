using System;

public static partial class Yams {

  public struct CreatePlayer
  {
    public int id;               // id du joueur, 1 ou 2 etant donnée que le nombre max de jouer est 2
    public string pseudo;        // pseudo du joueur
    public int[,] dices;         // on va stocker tous les des finaux de chaque rounds
    public int[] challenges;     // les challenges encore utilisable par le joueur
    public int[] scoreRounds;   // les scores de chaque round
    public int bonus;
    public int scoreTotal;       // le score final

    public CreatePlayer(int id) {
      this.id = id;
      this.pseudo = "Unknown";
      this.dices = new int [13,5];
      this.challenges = new int [13] {1,2,3,4,5,6,7,8,9,10,11,12,13};
      this.scoreRounds = new int [13];
      this.bonus = 0;
      this.scoreTotal = 0;
    }
  }

  public struct CreateChallenge {     // structure de création des challenges
    public string Challenge;
    public string Objectif;
    public string NombreDePoints;
    public int Tour;
    public int Score;

    public CreateChallenge(string challenge, string objectif, string nombreDePoints, int tour, int score) {  // on cree la fonction createchallege pour simplifier l'attribution des differentes valeurs
      Challenge = challenge;
      Objectif = objectif;
      NombreDePoints = nombreDePoints;
      Tour = tour;
      Score = score;
    }
  }

  public static Random rnd = new Random();


  // on initialise tous les challenges
  public static CreateChallenge nombreDe1 = new CreateChallenge("Nombre de 1","Obtenir le plus grand nombre de 1","Somme des dés ayant obtenu 1",0,0);
  public static CreateChallenge nombreDe2 = new CreateChallenge("Nombre de 2","Obtenir le plus grand nombre de 2","Somme des dés ayant obtenu 2",0,0);
  public static CreateChallenge nombreDe3 = new CreateChallenge("Nombre de 3","Obtenir le plus grand nombre de 3","Somme des dés ayant obtenu 3",0,0);
  public static CreateChallenge nombreDe4 = new CreateChallenge("Nombre de 4","Obtenir le plus grand nombre de 4","Somme des dés ayant obtenu 4",0,0);
  public static CreateChallenge nombreDe5 = new CreateChallenge("Nombre de 5","Obtenir le plus grand nombre de 5","Somme des dés ayant obtenu 5",0,0);
  public static CreateChallenge nombreDe6 = new CreateChallenge("Nombre de 6","Obtenir le plus grand nombre de 6","Somme des dés ayant obtenu 6",0,0);
  public static CreateChallenge brelan = new CreateChallenge("Brelan","Obtenir 3 dés de même valeur","Somme des 3 dés identiques",0,0);
  public static CreateChallenge carre = new CreateChallenge("Carré","Obtenir 4 dés de même valeur","Somme des 4 dés identiques",0,0);
  public static CreateChallenge full = new CreateChallenge("Full","Obtenir 3 dés de même valeur + 2 dés de même valeur","25 points",0,0);
  public static CreateChallenge petiteSuite = new CreateChallenge("Petite Suite","Obtenir 1-2-3-4 ou 2-3-4-5 ou 3-4-5-6","30 points",0,0);
  public static CreateChallenge grandeSuite = new CreateChallenge("Grande Suite","Obtenir 1-2-3-4-5 ou 2-3-4-5-6","40 points",0,0);
  public static CreateChallenge yams = new CreateChallenge("yams","Obtenir 5 dés de même valeur","50 points",0,0);
  public static CreateChallenge chance = new CreateChallenge("Chance","Obtenir le maximum de points","Somme des dés obtenus",0,0);

  // on met les challenges dans un tableau challenges, les [0-5] sont pour les challenges mineurs, les [6-12] pour les majeurs.
  public static CreateChallenge[] challenges = new CreateChallenge[13] {nombreDe1,nombreDe2,nombreDe3,nombreDe4,nombreDe5,nombreDe6,brelan,carre,full,petiteSuite,grandeSuite,yams,chance};

  static void Main() {
  
    CreatePlayer player1 = new CreatePlayer(1); // creation du premier joueur dont l'id vaut 1
    CreatePlayer player2 = new CreatePlayer(2); // creation du premier joueur dont l'id vaut 2

    Console.Write("Entrez le pseudo du premier joueur : ");
    player1.pseudo = Console.ReadLine();
    
    Console.Write("Entrez le pseudo du second joueur : ");
    player2.pseudo = Console.ReadLine();
    
    // tours de jeu
    for ( int i = 1 ; i <= 13 ; i++ ) {
      tour(i, ref player1);
      tour(i, ref player2);
    }
  }

  static void tour (int n, ref CreatePlayer currentPlayer) {
    /*Console.WriteLine($"Tour {n} : {currentPlayer.pseudo}");*/
    Console.WriteLine();
    Console.WriteLine($"Debut du tour {n} de {currentPlayer.pseudo}.");

    // affichage des challenges restant pour le joueur
    challengesRestants( ref currentPlayer);

    // lancement des dés
    // initialisation des des à 0
    int[,] des = new int[3,6];
    int line = 0;
    int compte = 0;
    // appel fonction des qui change les 0 en int aleatoire entre 1 et 6
    lancerDes(ref des, line);
    
    Console.WriteLine($"Voici vos dés ceux qui sont modifiables sont précédés d'une ~ :");
    for (int i = 0 ; i < 6 ; i++ ) {
      Console.Write($"~{des[line,i]}. ");
    }
    Console.WriteLine();

    // choix du joueur
    for ( int i = 0 ; i < 6 ; i++ ) {
      Console.WriteLine($"Souhaitez-vous garder le dé n{i+1} : {des[line,i]} ? y/*");
      if ( 'y' == Console.ReadKey().KeyChar ) {
        des[line+1,i] = des[line,i];
        compte++;
      } else {
        des[line,i] = 0;
      }
    }
    
    line++;

    
    Console.Write($"Vous avez gardé {compte} dés. ");
    for ( int i = 0 ; i < 6 ; i++ ) {
      if ( des[line,i] != 0 ) {
        Console.Write(des[line,i]);
      }
    }
    Console.WriteLine();

    /*if */
    // relance eventuelle
    // choix du joueur
    // relance eventuelle
    //
    //
    // selection du challenge par le joueur
    // verification de la disponibilité du challenge
    //
    // calcul du score


    Console.WriteLine($"Fin du tour, appuyer sur une entrée pour continuer.");
    Console.ReadLine();
    Console.WriteLine();
  }

  // on verifie les challenges pas encore utilisés par le jouer pour les lui afficher
  public static void challengesRestants(ref CreatePlayer player){
    for (int i = 0; i < 13; i++) {
      if (player.challenges[i] != 0) {
        Console.WriteLine($"{i+1} - { challenges[i].Challenge}");
      }
    }
  }

  // on jette les des qui doivent l'etre
  public static void lancerDes (ref int[,] des, int line) {
    for (int i = 0 ; i <  6 ; i++) {
      if ( des[line,i] == 0 ) {
        des[line,i] = rnd.Next(1,6);
      }
    }
  }

}

