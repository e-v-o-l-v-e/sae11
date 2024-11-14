public static void challengeRestant(ref CreatePlayer player, string[] challenges){
  for(int i=0; i<5; i++){
    if(player.challenges[i] != 0){
      Console.WriteLine(challenges[i] + " - " + challenges[player.challenges -1]);
    }
  }
}
