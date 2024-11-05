using System;

class Yams {

  struct joueur
  {
    int id;               // id du joueur, 1 ou 2 etant donnée que le nombre max de jouer est 2
    string pseudo;        // pseudo du joueur
    int[,] dices;         // on va stocker tous les des finaux de chaque rounds
    int[] challenges;     // les challenges encore utilisable par le joueur
    int[,] scoreRounds;   // les scores de chaque score
    int scoreTotal;       // le score final
  }

  static void Main() {
  
  }
}
