let nomFichier;
const form = document.querySelector('form');

form.addEventListener("submit", (event) => {
    // On récupère le nom de la partie
    nomFichier = document.getElementById("nom_partie").value;
});

/*
fetch('yams.iutrs.unistra.fr:3000/api/games/$(nomFichier)')
    .then(response => response.json())
    .then(data => {
        
        
    }
    .catch(error => console.error('Erreur de chargement du fichier', error));
    
*/
