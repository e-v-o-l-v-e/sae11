public static int scoreParChallenges(int choix, ref CreatePlayer player){
  int score = 0;
  
  if(choix == 1){
    for(int i=0; i<5; i++){
      if(player.dices[i] == 1){
        score ++;
      }
    }
  }

  
}
