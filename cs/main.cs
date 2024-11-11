using System;

class Yams {

  public struct CreatePlayer
  {
    public int id;               // id du joueur, 1 ou 2 etant donnée que le nombre max de jouer est 2
    public string pseudo;        // pseudo du joueur
    public int[,] dices;         // on va stocker tous les des finaux de chaque rounds
    public int[] challenges;     // les challenges encore utilisable par le joueur
    public int[] scoreRounds;   // les scores de chaque round
    public int scoreTotal;       // le score final

    public CreatePlayer(int id) {
      this.id = id;
      this.pseudo = "Unknown";
      this.dices = new int [13,5];
      this.challenges = new int [13];
      this.scoreRounds = new int [13];
      this.scoreTotal = 0;
    }
  }

  public struct CreateChallenge {     // structure de création des challenges
    public string Challenge;
    public string Objectif;
    public string NombreDePoints;

    public CreateChallenge(string challenge, string objectif, string nombreDePoints) {
      Challenge = challenge;
      Objectif = objectif;
      NombreDePoints = nombreDePoints;
    }
  }

  public static CreateChallenge nombreDe1 = new CreateChallenge("Nombre de 1","Obtenir le plus grand nombre de 1","Somme des dés ayant obtenu 1");
  public static CreateChallenge nombreDe2 = new CreateChallenge("Nombre de 2","Obtenir le plus grand nombre de 2","Somme des dés ayant obtenu 2");
  public static CreateChallenge nombreDe3 = new CreateChallenge("Nombre de 3","Obtenir le plus grand nombre de 3","Somme des dés ayant obtenu 3");
  public static CreateChallenge nombreDe4 = new CreateChallenge("Nombre de 4","Obtenir le plus grand nombre de 4","Somme des dés ayant obtenu 4");
  public static CreateChallenge nombreDe5 = new CreateChallenge("Nombre de 5","Obtenir le plus grand nombre de 5","Somme des dés ayant obtenu 5");
  public static CreateChallenge nombreDe6 = new CreateChallenge("Nombre de 6","Obtenir le plus grand nombre de 6","Somme des dés ayant obtenu 6");
  public static CreateChallenge brelan = new CreateChallenge("Brelan","Obtenir 3 dés de même valeur","Somme des 3 dés identiques");
  public static CreateChallenge carre = new CreateChallenge("Carré","Obtenir 4 dés de même valeur","Somme des 4 dés identiques");
  public static CreateChallenge full = new CreateChallenge("Full","Obtenir 3 dés de même valeur + 2 dés de même valeur","25 points");
  public static CreateChallenge petiteSuite = new CreateChallenge("Petite Suite","Obtenir 1-2-3-4 ou 2-3-4-5 ou 3-4-5-6","30 points");
  public static CreateChallenge grandeSuite = new CreateChallenge("Grande Suite","Obtenir 1-2-3-4-5 ou 2-3-4-5-6","40 points");
  public static CreateChallenge yams = new CreateChallenge("yams","Obtenir 5 dés de même valeur","50 points");
  public static CreateChallenge chance = new CreateChallenge("Chance","Obtenir le maximum de points","Somme des dés obtenus");

  // on met les challenges dans un tableau challenges, les [0-5] sont pour les challenges mineurs, les [6-12] pour les majeurs.
  public static CreateChallenge[] challenges = new CreateChallenge[13] {nombreDe1,nombreDe2,nombreDe3,nombreDe4,nombreDe5,nombreDe6,brelan,carre,full,petiteSuite,grandeSuite,yams,chance};

  /*static string[] challenges = {*/
  /*  "Nombre de 1","Nombre de 2","Nombre de 3","Nombre de 4","Nombre de 5","Nombre de 6",*/
  /*  "Brelan","Carré","Full","Petite suite","Grande suite","Yam's","Chance" */
  /*}*/

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
  }
}

