# Rapport du projet transverse

## Comment naviguer dans notre projet

**Pour tester l'executable du jeu:** 
Projet Transverse > Trapped Under Ice.exe

**Pour accéder aux scripts:**
Projet Transverse > Assets > Scripts
et
Projet Transverse > Assets > Levels > Script

**Pour accéder à la liste des commits:**
https://bitbucket.org/went2shitcame2soon/project/commits/all


## Description du projet

Après 4 mois de travail plus ou moins régulier, le projet touche à sa fin et se boucle sans trop d'encombres. Nous avions comme projet de réaliser un jeu pour ordinateur de plate-formes et d'action en 2 dimensions à l'aide du moteur de jeu Unity. 
Les scripts que nous utilisons ont été réalisés en C# et nous avons réalisé nous-même tous les éléments graphiques que nous utilisons (sauf les polices). 
Notre jeu s'appelle **Trapped Under Ice** et nous met à la place d'un naufragé dans une station sous-marine, qui ne semble pas avoir de sortie. Le joueur devra affronter les 3 boss de cette station afin de pouvoir sortir et finir le jeu.
Les mécaniques de jeu sont relativement simple, le joueur peut donner des coups de poings, tirer avec son arme (dans certains niveaux) et utiliser son grappin pour amener un élément de déplacement plus nerveux et nécessitant un peu plus de maîtrise. Cette maîtrise est nécessaire pour pouvoir venir à bout des ennemis.

Notre équipe était divisée en plusieurs parties :

 - Pôle Technique : Chargé d'implémenter les designs sur lesquels nous nous mettons d'accord lors de réunions.
 - Pôle Design : Chargé de mettre sur papier les différentes idées du jeu, que ce soit les mécaniques ou l'aspect visuel du jeu (textures etc).

Chaque membre était assigné à un pôle mais cela n'était pas restrictifs dans les tâches de chacun. Nous essayons de décider des tâches à réaliser par la semaine puis nous les attribuions par personne en fonction des affinités de chacun. 

>  Réunion du 03/03/18
>  Tâches Opsilonn : Travailler sur storyboards, scénario plus complet, backgrounds (Avec Nico)  
>  Tâches Nico : Travailler sur design player/monstre et textures (Avec Opsilonn)  
>  Tâches WildRat : Travailler sur déplacement smooooth + mini IA  
>  Tâches Démo : Créer le projet, scripts caméra et stats joueurs, se renseigner sur minimap et faire un début de menu de jeu
>  etc..

## Succès et échecs

Pour rappel, nos objectifs étaient les suivants *(ce dont nous nous rappelons que nous avons rempli sur pepperlabs du moins)*:

 1. Principaux : Avoir un niveau jouable, des textures basiques, un personnage jouable ;
 2. Secondaires: Avoir plusieurs niveaux jouables et un boss, des textures un peu plus affinées, des sons basiques, un deuxième personnage personnage jouable ;
 3. Optionnels: Des sons avancés, des graphiques complets et propres, mode coopératif, des easters eggs, des succès ;

Cependant, nous ne pouvons pas réellement dire que notre projet avait une trajectoire définitive depuis le début. Nous avons réalisé beaucoup, mais comme la structure a légèrement changé il est difficile de tout faire rentrer des les objectifs initiaux.

Ce que nous avons réalisé:

 - Niveaux de jeu: un niveau de tutoriel ainsi que 3 boss uniques ;
 - Mécaniques de jeu: une arme corps à corps, une arme à distance, grappin, contrôles basiques (déplacements, saut...) ;
 - Graphiques: tout ce que nous avons implémenté est correctement dessiné ;
 - Son: *peu* ;
 - Easter eggs: une version Unity et propre du projet du semestre dernier afin de prendre l'outil en main ;
 - *Finesse* globale: moyenne ;

En ce qui concerne nos échecs, nous les expliquerons de la manière suivante:

 1. Les sons sont difficilement réalisables par nous même, et nous voulions utiliser le moins d'éléments extérieurs, même s'ils sont libres de droits.
 2. Par niveau de finesse, nous entendons la cohérence globale du projet, le perfectionnement. Nous n'avons pas réussi à poser un cadre nous permettant d'avoir la base pour chaque niveau. La classe du joueur a été modifiée tout au long du projet et toutes les petites variables d'ajustement devenaient trop dures à gérer pour avoir le même rendu dans chaque niveau.
 3. Le mode coopératif n'a pas été implémenté car cela demandait un level design bien plus poussé pour donner une réelle justification à l'implémentation du mode coopératif, donc il n'a pas été réalisé (de plus n'étant qu'un objectif optionnel nous avons décidé de ne pas l'explorer).

