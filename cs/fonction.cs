public static bool verifChallenges(struc Joueur, string choix) {

    bool ok = false;
    int somme;

    // challenge nombre de 1
    if (choix == "nombre de 1") {
        for ( int i=0; i<5 ; i++) {
            if (Joueur.des[i]==1) {
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
            if (Joueur.des[i]==2) {
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
            if (Joueur.des[i]==3) {
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
            if (Joueur.des[i]==4) {
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
            if (Joueur.des[i]==6) {
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
            if (Joueur.des[i]==6) {
                somme++;
            }
        }
        if (somme == 5){
            ok = true;
        }
    }

    
}
