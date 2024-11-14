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

    public CreateChallenge(string challenge, string objectif, string nombreDePoints, int tour) {  // fonction createchallege pour simplifier l'attribution des attributs
      Challenge = challenge;
      Objectif = objectif;
      NombreDePoints = nombreDePoints;
      Tour = tour;
    }
  }

  public static CreateChallenge nombreDe1 = new CreateChallenge("Nombre de 1","Obtenir le plus grand nombre de 1","Somme des dés ayant obtenu 1",0);
  public static CreateChallenge nombreDe2 = new CreateChallenge("Nombre de 2","Obtenir le plus grand nombre de 2","Somme des dés ayant obtenu 2",0);
  public static CreateChallenge nombreDe3 = new CreateChallenge("Nombre de 3","Obtenir le plus grand nombre de 3","Somme des dés ayant obtenu 3",0);
  public static CreateChallenge nombreDe4 = new CreateChallenge("Nombre de 4","Obtenir le plus grand nombre de 4","Somme des dés ayant obtenu 4",0);
  public static CreateChallenge nombreDe5 = new CreateChallenge("Nombre de 5","Obtenir le plus grand nombre de 5","Somme des dés ayant obtenu 5",0);
  public static CreateChallenge nombreDe6 = new CreateChallenge("Nombre de 6","Obtenir le plus grand nombre de 6","Somme des dés ayant obtenu 6",0);
  public static CreateChallenge brelan = new CreateChallenge("Brelan","Obtenir 3 dés de même valeur","Somme des 3 dés identiques",0);
  public static CreateChallenge carre = new CreateChallenge("Carré","Obtenir 4 dés de même valeur","Somme des 4 dés identiques",0);
  public static CreateChallenge full = new CreateChallenge("Full","Obtenir 3 dés de même valeur + 2 dés de même valeur","25 points",0);
  public static CreateChallenge petiteSuite = new CreateChallenge("Petite Suite","Obtenir 1-2-3-4 ou 2-3-4-5 ou 3-4-5-6","30 points",0);
  public static CreateChallenge grandeSuite = new CreateChallenge("Grande Suite","Obtenir 1-2-3-4-5 ou 2-3-4-5-6","40 points",0);
  public static CreateChallenge yams = new CreateChallenge("yams","Obtenir 5 dés de même valeur","50 points",0);
  public static CreateChallenge chance = new CreateChallenge("Chance","Obtenir le maximum de points","Somme des dés obtenus",0);

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
    Console.WriteLine($"Tour {n} : {currentPlayer.pseudo}");

    // affichage des challenges restant pour le joueur



    // lancement des dés
    // choix du joueur
    // relance eventuelle
    // choix du joueur
    // relance eventuelle
    //
    //
    // selection du challenge par le joueur
    // verification de la disponibilité du challenge
    //
    // calcul du score
  }

  public static void challengesRestants(ref CreatePlayer player, CreateChallenge[] challenges){
    for(int i=0; i<5; i++){
      if(player.challenges[i] != 0){
        Console.WriteLine(challenges[player.challenges -1]);
      }
    }
  }

}

