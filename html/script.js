let nomFichier;

fetch('yams.iutrs.unistra.fr:3000/api/games/$(nomFichier)')
    .then(response => response.json())
    .then(data => {
        
    }
    .catch(error => console.error('Erreur de chargement du fichier', error));
