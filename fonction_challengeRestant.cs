public static void challengeRestant(struct Joueur, string[] noms_challenge){
  for(int i=0; i<5; i++){
    if(Joueur.challenge[i] != 0){
      Console.WriteLine(noms_challenge[Joueur.challenge -1]);
    }
  }
}
