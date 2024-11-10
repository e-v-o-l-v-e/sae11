using System;

class Yams {

  static struct createPlayer
  {
    int id;               // id du joueur, 1 ou 2 etant donnée que le nombre max de jouer est 2
    string pseudo;        // pseudo du joueur
    int[,] dices;         // on va stocker tous les des finaux de chaque rounds
    int[,] challenges;     // les challenges encore utilisable par le joueur, premiere ligne pour les mineurs, seconde pour les majeurs
    int[,] scoreRounds;   // les scores de chaque score
    int scoreTotal;       // le score final
  }

  /*static struct createChallenge {*/
  /*  string Challenge;*/
  /*  string Objectif;*/
  /*  string NombreDePoints;*/
  /*}*/

  // declaration des differents challenges, ligne une [0,] pour les challenges mineurs, seconde [1,] pour les majeurs
  static string[,] challenges = {
    {"Nombre de 1","Nombre de 2","Nombre de 3","Nombre de 4","Nombre de 5","Nombre de 6"},
    {"Brelan","Carré","Full","Petite suite","Grande suite","Yam's","Chance"}
  }

  static void Main() {
  
    createPlayer player1; // creation du premier joueur
    player1.id=1;         // initialisation de son id a 1

    createPlayer player2; // creation du premier joueur
    player2.id=2;         // initialisation de son id a 1

    Console.Write("Entrez le pseudo du premier joueur : ");
    player1.pseudo = string.Parse(Console.Read ());
    
    Console.Write("Entrez le pseudo du second joueur : ");
    player2.pseudo = string.Parse(Console.Read ());
    
    // tours de jeu
    for ( int i = 1 ; i <= 13 ) {
      tour(player1)
    }
  }

  static void tour (ref createPlayer currentPlayer) {

  }
}

