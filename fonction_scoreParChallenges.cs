public static int scoreParChallenges(int choix, ref CreatePlayer player){
    int score = 0;

    //Challenge nombre1
    if(choix == 1){
        int compteur = 0;
        for(int i=0; i<5; i++){
            if(player.dices[i] == 1){
                compteur ++;            //Nombre apparition 1
            }
        }
        score = compteur;
    }
    
    //Challenge nombre2
    if(choix == 2){
        int compteur = 0;
        for(int i=0; i<5; i++){
            if(player.dices[i] == 2){
                compteur ++;            //Nombre apparition 2
            }
        }
        score = 2 * compteur;
    }
    
    //Challenge nombre3
    if(choix == 3){
        int compteur = 0;
        for(int i=0; i<5; i++){
            if(player.dices[i] == 3){
                compteur ++;            //Nombre apparition 3
            }
        }
        score = 3 * compteur;
    }
    
    //Challenge nombre4
    if(choix == 4){
        int compteur = 0;
        for(int i=0; i<5; i++){
            if(player.dices[i] == 4){
                compteur ++;            //Nombre apparition 4
            }
        }
        score = 4 * compteur;
    }

    //Challenge nombre5
    if(choix == 5){
        int compteur = 0;
        for(int i=0; i<5; i++){
            if(player.dices[i] == 5){
                compteur ++;            //Nombre apparition 5
            }
        }
        score = 5 * compteur;
    }
    
    //Challenge nombre6
    if(choix == 6){
        int compteur = 0;
        for(int i=0; i<5; i++){
            if(player.dices[i] == 6){
                compteur ++;            //Nombre apparition 6
            }
        }
        score = 6 * compteur;
    }
    
    //Challenge Brelan
    if (choix == 7) {
        for (int i=1 ; i<=6 ; i++) {   //Chaque valeur du dé
            int compteur = 0;
            for (int j = 0; j < 5; j++) {       //Nombre apparition valeur 
                if (player.dices[j] == i) {
                    compteur++;
                }
            }
            if (compteur >= 3) {
                score = i*3;           //Somme des dés de la valeur i
            }
        }
    }
    
    //Challenge Carré
    if (choix == 8) {
        for (int i=1 ; i<=6 ; i++) {   //Chaque valeur du dé
            int compteur = 0;
            for (int j = 0; j < 5; j++) {       //Nombre apparition valeur 
                if (player.dices[j] == i) {
                    compteur++;
                }
            }
            if (compteur >= 4) {
                score = i*4;           //Somme des dés de la valeur i
            }
        }
    }
    
    //Challenge Full
    if(choix == 9){
        bool trois = false;  // 3 dés de mm valeurs
        bool deux = false;   // 2 dés de mm valeurs

        for (int i = 1; i <= 6; i++) {
            int compteur = 0;
            for (int j = 0; j < 5; j++) {
                if (player.dices[j] == i) {
                    compteur++;
                }
            }
            if (compteur == 3) trois = true;
            if (compteur == 2) deux = true;
        }
        if (trois && deux) {   
            score = 25;
        }
    }
    
    //Challenge Petite Suite
    if (choix == 10) {
        bool un = false, deux = false, trois = false, quatre = false, cinq = false, six = false;
    
        for (int i = 0; i < 5; i++) {
            if (player.dices[i] == 1) {     //Si il y a un dé 1 
                un = true;
            }
            if (player.dices[i] == 2) {     //Si il y a un dé 2 
                deux = true;
            }
            if (player.dices[i] == 3) {     //Si il y a un dé 3 
                trois = true;
            }
            if (player.dices[i] == 4) {     //Si il y a un dé 4 
                quatre = true;
            }
            if (player.dices[i] == 5) {     //Si il y a un dé 5 
                cinq = true;
            }
            if (player.dices[i] == 6) {     //Si il y a un dé 6 
                six = true;
            }
        }

        if ((un && deux && trois && quatre) || (deux && trois && quatre && cinq) || (trois && quatre && cinq && six)) {         //Si il y a une petite suite
            score = 30;
        }
    }
    
    
    //Challenge Grande Suite
    if (choix == 11) {
        bool un = false, deux = false, trois = false, quatre = false, cinq = false, six = false;
    
        for (int i = 0; i < 5; i++) {
            if (player.dices[i] == 1) {     //Si il y a un dé 1 
             un = true;
            }
            if (player.dices[i] == 2) {     //Si il y a un dé 2 
             deux = true;
            }
            if (player.dices[i] == 3) {     //Si il y a un dé 3 
             trois = true;
            }
            if (player.dices[i] == 4) {     //Si il y a un dé 4 
             quatre = true;
            }
            if (player.dices[i] == 5) {     //Si il y a un dé 5 
             cinq = true;
            }
            if (player.dices[i] == 6) {     //Si il y a un dé 6 
             six = true;
            }
        }

        if ((un && deux && trois && quatre && cinq) || (deux && trois && quatre && cinq && six)) {          //Si il y a une grande suite
            score = 40;
        }
    }
    
    //Challenge Yam's
    if (choix == 12) {
        for (int i=1 ; i<=6 ; i++) {
            int compteur = 0;
            for (int j = 0; j < 5; j++) {
                if (player.dices[j] == i) {
                    compteur++;
                }
            }
            if (compteur == 5) {
                score = 50; 
            }
        }
    }
    
    if(choix == 13){
        for(int i=0; i<5; i++){
            score += player.dices[i]; 
        }
    }
    
    return score;
  
}
