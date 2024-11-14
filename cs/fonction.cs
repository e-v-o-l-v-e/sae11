 public static bool verifChallenges(ref CreatePlayer player, string choix) {

    bool ok = false;
    int somme = 0 ;


    // challenge nombre de 1
    if (choix == "nombre de 1") {
        for ( int i=0; i<5 ; i++) {
            if (player.dices[i]==1) {
                somme++;
            }
        }
        if (somme == 5){
            ok = true;
        }
    }

    // challenge nombre de 2
    if (choix == "nombre de 2") {
        for ( int i=0; i<5 ; i++) {
            if (player.dices[i]==2) {
                somme++;
            }
        }
        if (somme == 5){
            ok = true;
        }
    }

    // challenge nombre de 3
    if (choix == "nombre de 3") {
        for ( int i=0; i<5 ; i++) {
            if (player.dices[i]==3) {
                somme++;
            }
        }
        if (somme == 5){
            ok = true;
        }
    }

    // challenge nombre de 4
    if (choix == "nombre de 4") {
        for ( int i=0; i<5 ; i++) {
            if (player.dices[i]==4) {
                somme++;
            }
        }
        if (somme == 5){
            ok = true;
        }
    }

    // challenge nombre de 5
    if (choix == "nombre de 5") {
        for ( int i=0; i<5 ; i++) {
            if (player.dices[i]==6) {
                somme++;
            }
        }
        if (somme == 5){
            ok = true;
        }
    }

    // challenge nombre de 6
    if (choix == "nombre de 6") {
        for ( int i=0; i<5 ; i++) {
            if (player.dices[i]==6) {
                somme++;
            }
        }
        if (somme == 5){
            ok = true;
        }
    }

    // challenge brelan
    if (choix == "brelan") {
        for (int i=1 ; i<=6 ; i++) {   // pour chaque valeur possible du dé
            int compteur = 0;
            for (int j = 0; j < 5; j++) {       // Compter le nombre de fois la valeur apparait
                if (player.dices[j] == i) {
                    compteur++;
                }
            }
            if (compteur >= 3) {
                ok = true;
            }
        }
    }

    // challenge carré
    if (choix == "carré") {
        for (int i = 1; i <= 6; i++) {
            int compteur = 0;
            for (int j = 0; j < 5; j++) {
                if (player.dices[j] == i) {
                 compteur++;
                }
            }
            if (compteur >= 4) {
                ok = true;
            }
        }
    }

    // challenge full
    if (choix == "full") {
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
            ok = true;
        }
    }

    // challenge petite suite
    if (choix == "petite suite") {
        bool un = false, deux = false, trois = false, quatre = false, cinq = false, six = false;
    
        for (int i = 0; i < 5; i++) {
            if (player.dices[i] == 1) {
                un = true;
            }
            if (player.dices[i] == 2) {
                deux = true;
            }
            if (player.dices[i] == 3) {
                trois = true;
            }
            if (player.dices[i] == 4) {
                quatre = true;
            }
            if (player.dices[i] == 5) {
                cinq = true;
            }
            if (player.dices[i] == 6) {
                six = true;
            }
        }

        if ((un && deux && trois && quatre) || (deux && trois && quatre && cinq) || (trois && quatre && cinq && six)) {
            ok = true;
        }
    }

    // challenge grande suite
    if (choix == "grande suite") {
        bool un = false, deux = false, trois = false, quatre = false, cinq = false, six = false;
    
        for (int i = 0; i < 5; i++) {
            if (player.dices[i] == 1) un = true;
            if (player.dices[i] == 2) deux = true;
            if (player.dices[i] == 3) trois = true;
            if (player.dices[i] == 4) quatre = true;
            if (player.dices[i] == 5) cinq = true;
            if (player.dices[i] == 6) six = true;
        }

        if ((un && deux && trois && quatre && cinq) || (deux && trois && quatre && cinq && six)) {
            ok = true;
        }
    }

    // challenge yam's
    if (choix == "yam's") {
        for (int i=1 ; i<=6 ; i++) {
            int compteur = 0;
            for (int j = 0; j < 5; j++) {
                if (player.dices[j] == i) {
                    compteur++;
                }
            }
            if (compteur == 5) {
                ok = true; 
            }
        }
    }

    // challenge chance
    if (choix == "chance") {
        ok = true; // challenge toujours ok
    }

}
