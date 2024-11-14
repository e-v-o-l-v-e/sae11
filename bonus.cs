static int CalculerBonus(ref CreatePlayer player) {
  int somme = 0;  // somme des scores

  // on additionne les scores des 6 premiers challenges (mineurs)
  for (int i = 0 ; i < 6 ; i++) {
    somme += player.scoreRounds[i];
  }

  // tout les 63 points, on attribue le bonus
  if (somme >= 63) {
    player.bonus = 35;
  } 
  else {
    player.bonus = 0;
  }

  return player.bonus;
}
