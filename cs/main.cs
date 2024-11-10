using System;

class Yams {

  static struct createPlayer
  {
    int id;               // id du joueur, 1 ou 2 etant donnée que le nombre max de jouer est 2
    string pseudo;        // pseudo du joueur
    int[,] dices;         // on va stocker tous les des finaux de chaque rounds
    int[,] challenges;     // les challenges encore utilisable par le joueur
    int[,] scoreRounds;   // les scores de chaque score
    int scoreTotal;       // le score final
  }

  static challenges 

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

  static void tour (ref createPlayer currentPlayer)
}

