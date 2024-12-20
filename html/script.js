const form = document.querySelector('form');
let nomFichier;
let affichage;
let choix;
let codeHTML;

document.getElementById('formulaire').addEventListener('submit', nomFichier_choixAffichage);
const contenantParametres = document.getElementById('contenuParametres');
const contenantJoueurs = document.getElementById('contenuJoueurs');
const contenantTours = document.getElementById('contenuTours');
const contenantScoreFinal = document.getElementById('contenuScoreFinal');
const contenantBoutonPrecedent = document.getElementById('boutonPrecedent');
const contenantBoutonPre = document.getElementById('boutonPre');
const contenantBoutonSui = document.getElementById('boutonSui');


function nomFichier_choixAffichage(event){
    event.preventDefault();
    nomFichier = document.getElementById("nomPartie").value;
    
    affichage = document.querySelector('input[name="partie"]:checked');
    
    //Vérifie si on a bien séléctionner un choix
    if (affichage) {
        choix = affichage.value;
    } 
    else{
        alert("Aucun choix de partie n'a été sélectionné.");
    }
    
    if(choix == 'tout'){
       affichageGlobal();                //Appel de la fonction qui va afficher toute la partie
    }
    
    if(choix == 'tour'){
        affichageTourParTour();          //Appel de la fonction qui va afficher tour par tour
    }
}

function afficherParametres(){
    fetch("http://yams.iutrs.unistra.fr:3000/api/games/" + nomFichier + "/parameters")
        .then(response => response.json())
        .then(data => {
            codeHTML = `                
                <h2>Paramètres de la partie</h2>
                <p>Code_Partie : ${data.code}</p>
                <p>Date_Partie : ${data.date}</p><br>
            `;
                contenantParametres.innerHTML = codeHTML;
        })
        .catch(error => console.error('Erreur de chargement du fichier', error));
}

function afficherJoueurs(){
    fetch("http://yams.iutrs.unistra.fr:3000/api/games/" + nomFichier + "/players")
        .then(response => response.json())
        .then(data =>{
            codeHTML = `
                <h2>Les joueurs</h2>
                <table>
                    <tr>
                        <th>ID</th>
                        <th>Pseudo</th>
                    </tr>
                    
                    <tr>
                        <td>${data[0].id}</td>
                        <td>${data[0].pseudo}</td>
                    </tr>
                    
                    <tr>
                        <td>${data[1].id}</td>
                        <td>${data[1].pseudo}</td>
                    </tr>
                </table>
                <br>
            `;
            contenantJoueurs.innerHTML = codeHTML;
        })
        .catch(error => console.error('Erreur de chargement du fichier', error));
}

function afficherResultatsFinaux(){
    fetch("http://yams.iutrs.unistra.fr:3000/api/games/" + nomFichier + "/final-result")
        .then(response => response.json())
        .then(data =>{
            codeHTML = `
                <h2>Scores finaux</h2>
                <table>
                    <tr>
                        <th>ID</th>
                        <th>Bonus</th>
                        <th>Score</th>
                    </tr>
                    
                    <tr>
                        <td>${data[0].id_player}</td>
                        <td>${data[0].bonus}</td>
                        <td>${data[0].score}</td>
                    </tr>
                    
                    <tr>
                        <td>${data[1].id_player}</td>
                        <td>${data[1].bonus}</td>
                        <td>${data[1].score}</td>
                    </tr>
                </table>
                <br>
            `;
            contenantScoreFinal.innerHTML = codeHTML;
        })
        .catch(error => console.error('Erreur de chargement du fichier', error));
}

function affichageGlobal(){    
    //Commencer par les paramètres
    afficherParametres();
        
    //Les joueurs
    afficherJoueurs();
    
    //Résultats finaux
    afficherResultatsFinaux();
}   


function afficheTour(tour){
    fetch("http://yams.iutrs.unistra.fr:3000/api/games/" + nomFichier + "/rounds/" + tour)
        .then(response => response.json())
        .then(data => {            
            let codeHTML = `
                <h2> Tour ${data.id} </h2>
                <h3> Joueur 1 </h3>
                <h4> Dés </h4>
                
                <table>
                    <tr>
                        <th>n°1</th>
                        <th>n°2</th>
                        <th>n°3</th>
                        <th>n°4</th>
                        <th>n°5</th>
                    </tr>
                    
                    <tr>
            `;
            
            
            for(let j=0; j<5; j++){
                codeHTML += `<td>${data.results[0].dice[j]}</td>`;
            }

            codeHTML += `
                </tr>
                </table>
                <p>Challenge choisi : ${data.results[0].challenge}</p>
                <p>Score du tour : ${data.results[0].score}</p>
            `;

            
            // Joueur 2
            codeHTML += `
                <h3> Joueur 2 </h5>
                <h4> Dés </h4>
                <table>
                    <tr>
                        <th>n°1</th>
                        <th>n°2</th>
                        <th>n°3</th>
                        <th>n°4</th>
                        <th>n°5</th>
                    </tr>
                    
                    <tr>
            `;
            
            for(let j=0; j<5; j++){
                codeHTML += `<td>${data.results[1].dice[j]}</td>`;
            }

            codeHTML += `
                </tr>
                </table>
                <p>Challenge choisi : ${data.results[1].challenge}</p>
                <p>Score du tour : ${data.results[1].score}</p>
            `;

            contenantTours.innerHTML = codeHTML;
        })
        .catch(error => console.error('Erreur de chargement du fichier', error));
}


function affichageTourParTour(){
    //Rajouter les boutons (changer de tour)
    let boutonPrecedent = document.createElement("button")  
    boutonPrecedent.innerHTML='Tour précédent'
    boutonPrecedent.setAttribute('id', "precedent")
    
    let boutonSuivant = document.createElement('button')
    boutonSuivant.innerHTML = 'Tour suivant'
    boutonSuivant.setAttribute('id', "suivant")

    contenantBoutonPre.appendChild(boutonPrecedent)
    contenantBoutonSui.appendChild(boutonSuivant)
    
    //Afficher les tours
    let i = 1;
    afficheTour(i);
    
    document.getElementById('precedent').addEventListener('click', function(){
        if(i > 1){
            i--;
            afficheTour(i);
        } 
        else{
            i = 13;
            afficheTour(i);
        }
    });
    document.getElementById('suivant').addEventListener('click', function(){
        if(i<13){
            i++;
            afficheTour(i);
        }
        else{
            i = 1;
            afficheTour(i);
        }
    });
    //Afficher les résultats finaux
    afficherResultatsFinaux();
}
    
let image = document.querySelector("img");

image.addEventListener("click", (event) => {
  let src = image.getAttribute("src");
  if (src === "images/des.png") {
    image.setAttribute("src", "images/yeux.jpg");
  } else {
    image.setAttribute("src", "images/des.png");
  }
});


const troll = document.getElementById("troll");

// Fonction pour déplacer le bouton
function deplacerBouton() {
    const hauteurMax = window.innerHeight / 2; // Limite à la moitié de la hauteur de la fenêtre
    const largeurMax = window.innerWidth - 100; // Largeur maximale (moins la taille du bouton)

    // Calcul des nouvelles positions aléatoires
    const nouvellePositionX = Math.random() * largeurMax;
    const nouvellePositionY = Math.random() * hauteurMax;

    // Applique les nouvelles positions
    troll.style.left = `${nouvellePositionX}px`;
    troll.style.top = `${nouvellePositionY}px`;
}

// Écouteur pour déplacer le bouton au survol
troll.addEventListener("mouseover", deplacerBouton);
