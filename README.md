# Trapped Under Ice

Voir aussi : https://bitbucket.org/went2shitcame2soon/project/commits/all

## Partie 1 - Synthèse du sujet posé et analyse

Par sa structure même, le projet Transverse permet à chaque groupe d’étudiants de réaliser un projet dans une liberté quasi-totale, qu’il soit uniquement comme partiellement numérique ou mécanique.
Etant donné que nous n’avons aucune limite vis-à-vis du projet, si ce n’est qu’il doit être validé par un responsable, nous avions une multitude d’opportunités et d’idées à proposer, dans tous les domaines possibles. Plutôt que de s’éparpiller sur une dizaine d’idées diverses et variées, nous avons préférés prolonger le travail effectué durant le semestre précédent.
Fort de l’expérience accumulée lors du projet du semestre 3, nous avons formé un groupe de 5 en ayant pour objectif de perfectionner ce que nous avons appris : maîtriser l’utilisation d’un nouvel outil informatique (la bibliothèque SDL), afin de créer de nouveau un jeu, cette fois en étant plus ambitieux.


## Partie 2 - Conception du projet

Notre choix s’est vite porté sur un jeu vidéo car nous aimons tous ça dans le groupe. Nous trouvons intéressante et excitante l’idée d’en développer un nous-même, en se basant sur nos idées, nos concepts et notre originalité.<br/>
Nous nous sommes donc renseignés sur les moteurs de jeu et avons pensé que Unity était bien pour commencer, étant relativement user friendly mais tout de même assez complet pour notre usage. Il nous a d’abord fallu se familiariser avec ce logiciel via des tutoriels, mais également avec d’autres tels que Piskel ou Photoshop, notamment pour la création de décors ou de personnages. Aussi, nous codons sous C#, ce qui est une première pour nous tous.<br/>
Ce langage ressemble par bien des aspects au C ou au C++, restant néanmoins bien plus "acceuillant", mais il faut apprendre à utiliser les fonctions et comprendre comment interagissent les scripts codés, ou comment créer notre interface de jeu dans Unity.
Il n’était pas facile de séparer les tâches pour faire une répartition équitable où chacun apprécie ce qu’il doit faire. Etant donné que c’est notre "premier" projet en conditions <b>réelles</b>, il était nécessaire de séparer les différentes parties qui constituent notre jeu (graphique, design, code, animations, …), nous avons pu chacun choisir sur quoi travailler. Concernant le jeu en lui-même, nous avons commencé à travailler sur le menu principal et en parallèle sur les premiers niveaux, et nous réfléchissons maintenant à l’intégration d’un mode co-op, ainsi qu’à l’incorporation de «Boss » de fin de niveaux. 

## Partie 3 – Feuille de route du projet 

Notre équipe est composée de 5 personnes come sus-mentionné dans l'introduction :
- Mathis BICHEYRE : chef de projet
- Warren DJEDIR : responsable pôle technique
- Hugues BEGEOT : responsable pôle design
- Clément LAMBLING : second technique 
- Nicolas BENCHIMOL : second design

Nous avons dans l'optique d'organiser notre jeu en une multitude de <i>mini-projets</i> que chaque responsable devra conduire. Bien sûr étant une petite équipe nous souhaitons pouvoir impliquer le plus de personnages dans chaque partie, mais l'organisation du travail entre nous dans ce domaine relèvera du responsable concerné.
Afin de bien conduire notre jeu, ne nous pouvons pas <i>foncer</i> tête baissée dans la programmation, car un jeu vidéo demande beaucoup de travail préliminaire.<br/>
Ainsi nous avons consacré (et continuerons de consacrer) nos premières semaines à la conception de maquettes de niveaux et à réfléchir aux règles et mécaniques de notre jeu, car un système mal conçu nous entrainerait sur une pente glissante. De même, nous avons commencé dès le début à confectionner nos éléments graphiques, car cela prend <b>beaucoup</b> de temps.<br/><br/>
Les semaines suivantes seront consacrées à la finalisation du prototype initial que nous décrivons en détail ce dessous.

## Partie 4 – Objectif du prototype initial

Afin de réaliser le projet, nous le diviserons schématiquement en 3 grandes parties, qui devront avancer chacune à un rythme similaire afin de ne pas bloquer le travail des autres départements. 
Tout d’abord, le département artistique, sera en charge de la création des éléments graphiques du jeu, allant du décor jusqu’aux personnages. Il réalisera également les animations des différents personnages du jeu. Les tests d’animations seront réalisés via le logiciel Unity, proposant une section animation.
Le département artistique devra donc :
-	Créer les textures des personnages ;
-	Créer les textures de fond ;
-	Créer les animations des éléments interactifs ;

Ensuite, le département technique sera en charge de la partie de programmation liée au jeu, comme par exemple la création de menus textuels, de scripts de déplacement des personnages, de la gestion d’IAs. Afin de réaliser les tests techniques liés aux interactions en jeu, le design des éléments sera nécessaire. Pour le reste, le développement du menu et d’autres fonctionnalités sera principalement testable sans apport des autres départements.
Le département technique sera chargé de :
-	Coder les scripts de mouvements des personnages ;
-	Créer les menus interactifs (menu de pause, menu de début de jeu) ;
-	Coder le fonctionnement des éléments non-joueurs ;

Pour finir, le département création sera en charge du level-design et game-design. Il devra donc utiliser les éléments des départements technique et artistique afin de donner une forme au jeu. Les tests relatifs à ce département s’effectueront directement via un essai du jeu et des différents niveaux au cours de leur création.
Le département création devra donc :
-	Créer les niveaux ;
-	Créer le son ;
-	Créer les dialogues et interactions ;
-	Faire en sorte que le jeu réponde aux critères d’accessibilité ;

