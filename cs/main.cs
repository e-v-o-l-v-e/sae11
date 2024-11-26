using System;

public static partial class Yams {

  public struct Player
  {
    public int id;               // id du joueur, 1 ou 2 etant donnée que le nombre max de jouer est 2
    public string pseudo;        // pseudo du joueur
    public int[,] dices;         // on va stocker tous les des finaux de chaque rounds
    public int[] challenges;     // les challenges encore utilisable par le joueur
    public int[] scoreRounds;   // les scores de chaque round
    public int bonus;
    public int scoreTotal;       // le score final

    public Player(int id) {
      this.id = id;
      this.pseudo = "Unknown";
      this.dices = new int [13,5];
      this.challenges = new int [13] {1,2,3,4,5,6,7,8,9,10,11,12,13};
      this.scoreRounds = new int [13];
      this.bonus = 0;
      this.scoreTotal = 0;
    }
  }

  public struct Challenge {     // structure de création des challenges
    public string challenge;
    public string objectif;
    public string nombreDePoints;
    public int tour;
    public int score;

    public Challenge(string challenge, string objectif, string nombreDePoints, int tour, int score) {  // on cree la fonction createchallege pour simplifier l'attribution des differentes valeurs
      this.challenge = challenge;
      this.objectif = objectif;
      this.nombreDePoints = nombreDePoints;
      this.tour = tour;
      this.score = score;
    }
  }
  // on initialise tous les challenges
  public static Challenge nombreDe1 = new Challenge("Nombre de 1","Obtenir le plus grand nombre de 1","Somme des dés ayant obtenu 1",0,0);
  public static Challenge nombreDe2 = new Challenge("Nombre de 2","Obtenir le plus grand nombre de 2","Somme des dés ayant obtenu 2",0,0);
  public static Challenge nombreDe3 = new Challenge("Nombre de 3","Obtenir le plus grand nombre de 3","Somme des dés ayant obtenu 3",0,0);
  public static Challenge nombreDe4 = new Challenge("Nombre de 4","Obtenir le plus grand nombre de 4","Somme des dés ayant obtenu 4",0,0);
  public static Challenge nombreDe5 = new Challenge("Nombre de 5","Obtenir le plus grand nombre de 5","Somme des dés ayant obtenu 5",0,0);
  public static Challenge nombreDe6 = new Challenge("Nombre de 6","Obtenir le plus grand nombre de 6","Somme des dés ayant obtenu 6",0,0);
  public static Challenge brelan = new Challenge("Brelan","Obtenir 3 dés de même valeur","Somme des 3 dés identiques",0,0);
  public static Challenge carre = new Challenge("Carré","Obtenir 4 dés de même valeur","Somme des 4 dés identiques",0,0);
  public static Challenge full = new Challenge("Full","Obtenir 3 dés de même valeur + 2 dés de même valeur","25 points",0,0);
  public static Challenge petiteSuite = new Challenge("Petite Suite","Obtenir 1-2-3-4 ou 2-3-4-5 ou 3-4-5-6","30 points",0,0);
  public static Challenge grandeSuite = new Challenge("Grande Suite","Obtenir 1-2-3-4-5 ou 2-3-4-5-6","40 points",0,0);
  public static Challenge yams = new Challenge("yams","Obtenir 5 dés de même valeur","50 points",0,0);
  public static Challenge chance = new Challenge("Chance","Obtenir le maximum de points","Somme des dés obtenus",0,0);

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
    for ( int i = 0 ; i < 13 ; i++ ) {
      tour(i, ref player1);
      tour(i, ref player2);
    }
  }

  static void tour (int n, ref Player currentPlayer) {
    /*Console.WriteLine($"Tour {n} : {currentPlayer.pseudo}");*/
    Console.WriteLine();
    Console.WriteLine($"Debut du tour {n+1} de {currentPlayer.pseudo}.");

    // affichage des challenges restant pour le joueur
    challengesRestants( ref currentPlayer);

    // initialisation des des à 0, on met 4 lignes car on verifie si un de peut etre relancer en fonction de l'etait de la meme colonne sur la ligne precedeente, exemple : des[2,3] est relançable seulement si des[1,3] == 0
    int[,] des = new int[4,6];
    int line = 1;
    bool relance = false;
    // appel fonction des qui change les 0 en int aleatoire entre 1 et 6 pour la ligne du tour
    lancerDes(ref des, line, ref relance);

    for (int i = 0 ; i < 6 ; i++ ) {
      currentPlayer.des[n,i] = des[line,i];
    }

    // on monte d'un niveau dans le tableau des dés
    line++;
    
    // on relance les des jusqu'a 2 fois si le joueur decide de relancer certain dés
    for (int i = 0 ; i < 2 ; i ++ ) {
      if ( relance ) {
        lancerDes(ref des, line+i, ref relance);
      }
    }
    // selection du challenge par le joueur
    // verification de la disponibilité du challenge
    //
    // calcul du score
    
    
    Console.WriteLine($"Fin du tour, appuyer sur une entrée pour continuer.");
    Console.ReadLine();
    Console.WriteLine();
  }

  // on verifie les challenges pas encore utilisés par le jouer pour les lui afficher
  public static void challengesRestants(ref Player currentPlayer){
    for (int i = 0; i < 13; i++) {
      if (player.challenges[i] != 0) {
        Console.WriteLine($"{i+1} - { challenges[i].Challenge}");
      }
    }
  }

  // on jette les des qui doivent l'etre
  public static void lancerDes (ref int[,] des, int line, ref bool relance) {

    for (int i = 0 ; i <  6 ; i++) {
      if ( des[line,i] == 0 ) {
        des[line,i] = rnd.Next(1,6);
      }
    }

    Console.Write($"Voici vos dés.");
    for (int i = 0 ; i < 6 ; i++ ) {
      Console.Write($"{des[line,i]}. ");
    }


    if ( line < 3 ) {
      Console.Write($"Voici vos dés modifiables sont précédés d'une ~ :");
      for (int i = 0 ; i < 6 ; i++ ) {
        if ( des[line-1,i] == 0 ) {
          Console.Write("~");
        }
        Console.Write($"{des[line,i]}. ");
      }
      Console.WriteLine();

      // choix du joueur
      for ( int i = 0 ; i < 6 ; i++ ) {
        Console.WriteLine($"Souhaitez-vous garder le dé n{i+1} : {des[line,i]} ? y/*");
        if ( 'y' == Console.ReadKey().KeyChar ) {
          des[line+1,i] = des[line,i];
        } else {
          des[line,i] = 0;
          relance = true;
        }
      }
      Console.WriteLine();
    }
  }
}

