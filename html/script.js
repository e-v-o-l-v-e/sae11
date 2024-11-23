const form = document.querySelector('form');

form.addEventListener("submit", (event) => {
    // On récupère le nom de la partie
    let nomFichier = document.getElementById("nom_partie").value;
    
    // Vérifier quel bouton radio est sélectionné
    let affichage = document.querySelector('input[name="partie"]');
    let choix = affichage.value;
    
    /*    Si on veut dire qu'on a oublié de sélectionner un choix
    if (affichage) {
        let choix = affichage.value;
    } else {
        alert("Aucun choix de partie n'a été sélectionné.");
    }
    */
});



fetch('yams.iutrs.unistra.fr:3000/api/games/$(nomFichier)')
    .then(response => response.json())
    .then(data => {
        
        
    })
    .catch(error => console.error('Erreur de chargement du fichier', error));
    
