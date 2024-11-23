const form = document.querySelector('form');
let nomFichier;
let affichage;
let choix;

form.addEventListener("submit", (event) => {
    // On récupère le nom de la partie et on affiche sa valeur
    nomFichier = document.getElementById("nom_partie").value;

    
    // Vérifier quel bouton radio est sélectionné
    affichage = document.querySelector('input[name="partie"]:checked');
    choix = affichage.value;
    
    /*    Si on veut dire qu'on a oublié de sélectionner un choix
    if (affichage) {
        let choix = affichage.value;
    } else {
        alert("Aucun choix de partie n'a été sélectionné.");
    }
    */
    
    fetch(`yams.iutrs.unistra.fr:3000/api/games/$(nomFichier)`)
        .then(response => response.json())
        .then(data => {
            if(choix === 'tout'){
                const partieEntiere = document.getElementById('partieComplete');
                codeHTML = `
                `;
                partieEntiere.innerHTML = codeHTML;
            }
            else{
                const tour = document.getElementById('partieReduite');
                codeHTML = `
                `;
                tour.innerHTML = codeHTML;
            }
        })
        .catch(error => console.error('Erreur de chargement du fichier', error));
});
    

    
//Je m'amuse avec le JS (cliquez sur l'image !)
    
let image = document.querySelector("img");

image.addEventListener("click", (event) => {
  let src = image.getAttribute("src");
  if (src === "images/des.png") {
    image.setAttribute("src", "images/yeux.jpg");
  } else {
    image.setAttribute("src", "images/des.png");
  }
});
