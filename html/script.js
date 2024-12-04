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
const contenantBouton = document.getElementById('boutonTour');


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
                <h2>Partie ${nomFichier}</h2>
                
                <h3>Paramètres de la partie</h3>
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
                <h3>Les joueurs</h3>
                <p>ID_Joueur : ${data[0].id}</p>
                <p>Pseudo_Joueur : ${data[0].pseudo}</p>
                <br>
                
                <p>ID_Joueur : ${data[1].id}</p>
                <p>Pseudo_Joueur : ${data[1].pseudo}</p>
                <br>
            `;
            contenantJoueurs.innerHTML += codeHTML;
        })
        .catch(error => console.error('Erreur de chargement du fichier', error));
}

function afficherResultatsFinaux(){
    fetch("http://yams.iutrs.unistra.fr:3000/api/games/" + nomFichier + "/final-result")
        .then(response => response.json())
        .then(data =>{
            codeHTML = `
                <h3>Scores finaux</h3>
                <p>ID_Joueur : ${data[0].id_player}</p>
                <p>Bonus_Joueur : ${data[0].bonus}</p>
                <p>Score_Joueur : ${data[0].score}</p>
                <br>
                
                <p>ID_Joueur : ${data[1].id_player}</p>
                <p>Bonus_Joueur : ${data[1].bonus}</p>
                <p>Score_Joueur : ${data[1].score}</p>
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
    
    //Les tours
    
    
    // Fonction asynchrone pour gérer l'asynchronicité des fetch()
    async function fetchRounds() {
        for(let i=1; i<14; i++){
            try{
                const response = await fetch("http://yams.iutrs.unistra.fr:3000/api/games/" + nomFichier + "/rounds/" + i)
                const data = await response.json();
                
                let codeHTML = `
                    <h4> Tour ${data.id} </h4>
                    <h5> Joueur 1 </h5>
                    <h6> Dés </h6>
                `;
                
                for(let j=0; j<5; j++){
                    codeHTML += `<p>${data.results[0].dice[j]}</p>`;
                }

                codeHTML += `
                    <p>Challenge choisi : ${data.results[0].challenge}</p>
                    <p>Score du tour : ${data.results[0].score}</p>
                `;

                
                // Joueur 2
                codeHTML += `
                    <h5> Joueur 2 </h5>
                    <h6> Dés </h6>
                `;
                
                for(let j=0; j<5; j++){
                    codeHTML += `<p>${data.results[1].dice[j]}</p>`;
                }

                codeHTML += `
                    <p>Challenge choisi : ${data.results[1].challenge}</p>
                    <p>Score du tour : ${data.results[1].score}</p>
                `;

                contenantTours.innerHTML += codeHTML;
                
            } 
            catch (error) {
                console.error('Erreur de chargement du fichier', error);
            }
        }
    }
    
    // Appel de la fonction asynchrone
    codeHTML = `
        <h3>Les tours</h3>
    `;
    contenantTours.innerHTML += codeHTML;
    fetchRounds();
    
    //Résultats finaux
    afficherResultatsFinaux();
}   


function afficheTour(tour){
    fetch("http://yams.iutrs.unistra.fr:3000/api/games/" + nomFichier + "/tour/" + tour)
        .then(response => response.json())
        .then(data => {
            let codeHTML = `
                <h4> Tour ${data.id} </h4>
                <h5> Joueur 1 </h5>
                <h6> Dés </h6>
            `;
            
            for(let j=0; j<5; j++){
                codeHTML += `<p>${data.results[0].dice[j]}</p>`;
            }

            codeHTML += `
                <p>Challenge choisi : ${data.results[0].challenge}</p>
                <p>Score du tour : ${data.results[0].score}</p>
            `;

            
            // Joueur 2
            codeHTML += `
                <h5> Joueur 2 </h5>
                <h6> Dés </h6>
            `;
            
            for(let j=0; j<5; j++){
                codeHTML += `<p>${data.results[1].dice[j]}</p>`;
            }

            codeHTML += `
                <p>Challenge choisi : ${data.results[1].challenge}</p>
                <p>Score du tour : ${data.results[1].score}</p>
            `;

            contenantTours.innerHTML = codeHTML;
        })
        .catch(error => console.error('Erreur de chargement du fichier', error));
}


function affichageTourParTour(){
    //Rajouter les boutons (changer de tour)
    codeHTML = `
        <input type='submit' value='TourPrecedent'>
        <input type='submit' value='TourSuivant'>
    `;
    contenantBouton.innerHTML = codeHTML;
    
    
    //Afficher les tours
    let i = 1;
    afficheTour(i);

    
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
