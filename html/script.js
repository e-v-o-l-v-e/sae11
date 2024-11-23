let nomFichier;
const form = document.querySelector('form');

form.addEventListener("submit", (event) => {
    /*
    // On empêche le comportement par défaut
    event.preventDefault();
    */

    // On récupère le nom de la partie et on affiche sa valeur
    nomFichier = document.getElementById("nom_partie").value;
    alert(nomFichier);
});

/*
fetch('yams.iutrs.unistra.fr:3000/api/games/$(nomFichier)')
    .then(response => response.json())
    .then(data => {
        
        
    }
    .catch(error => console.error('Erreur de chargement du fichier', error));
    
*/
