J'ai choisi une architecture orientée composants car cela s'adapte bien avec la façon dont Unity
traite les GameObjects. Un objet est en effet une accumulation de composants qui ont tous un effet
bien spécifique.
Chacun des scripts suivants est un composant. Certains d'entre eux sont assez génériques pour être
réutilisés ultérieurement (le controller, QuantityUnit, les matrices de données, les coordonnées).

[GameElement] : quasiment tous les composants héritent de GameElement qui leur permet un accès
simplifié aux matrices de données.

[Coordonnees] : très utilisé également afin d'accéder aux indices de l'objet auquel le composant
est attaché (indices des matrices de données).

<abstract> [GameMatrix]
	-> [GroundMatrix] : matrice contenant les objets de terrain; initialise le niveau avec les terrains
	-> [ResourceMatrix] : même que précédemment avec les ressources plutôt que les terrains

<interface> [Production] : permet a l'objet de modifier le terrain ou les ressources qui lui sont proches
	-> [ProductionIn] : modifie le terrain ou la ressource sur la meme case que l'objet
	-> [ProductionAround] : modifie le terrain ou la ressource sur les cases adjacentes (haut, bas, gauche, droite)

<interface> [AlternativeProduction] : permet aux composants de production d'alterner entre plusieurs objets à générer
	-> [AlternativeProductionIn]
	-> [AlternativeProductionAround]

[AffectAround] et [InfectionGround] : effets spécifiques de certaines ressources (en l'occurence les déchets)
Réutilisation des composants de production.
Intéractions entre ressources.

[QuantityUnit] : Composant permettant de stack plusieurs unités d'une même ressource.

[NonMoveable] et [Radioactive] : ces composants portent une information en eux même; rien qu'en sachant
qu'un objet a le composant NonMoveable on sait qu'on ne peut pas le swapper par exemple.

[SwapObjects] : CONTROLLER c'est le composant qui permet de lire et interpréter les inputs du joueur.

[GameClock] : composant qui gère la synchronisation temporelle des éléments du jeu; broadcast l'évènement OnClock
qui lance la production de ressources, active les effets d'intéraction etc. via les différents handler des composants.