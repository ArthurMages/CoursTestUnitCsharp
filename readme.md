## Atelier 3 : Heure en texte (TDD)

Concevez en TDD une méthode de classe (static) qui, à partir d'un DateTime, renvoie une chaîne de caractères contenant le texte de l'heure.

Les étapes recommandées sont :
- Traduire une heure "pile" du matin : ex 7:00 => "sept heures du matin", 1:00 => "une heure du matin"
- Traduire une heure "pile" de l'après-midi : ex 14:00 => "deux heures de l'après-midi"
- Traduire une heure "pile" spéciale : ex 12:00 => "midi", 00:00 => "minuit"
- Gérer les tranches normales de 5 minutes de la première demi-heure : ex 12:10 => "midi dix", 15:25 => "trois heures vingt-cinq de l'après-midi", 00:15 => "minuit et quart"
- Gérer les tranches spéciales de 5 minutes après la première demi-heure : ex 8:45 => "neuf heures moins le quart", 12:35 => "une heure moins vingt-cinq de l'après-midi"
- Gérer les minutes précises : ex 8:48 => "neuf heures moins dix du matin à deux minutes près", 12:04 => "Midi cinq à une minute près"
# Atelier 1 - Test d'une classe Produit

## Sujet
Créer un projet de test et écrire une classe de test pour la [classe Produit](AtelierStock.zip) qui vérifie les cas usuels et extrêmes (pas les cas d'erreur) :

- l'initialisation des prix d'achats et ventes
- la gestion des stocks
- la bonne prise en compte de la rupture de stock 

Attention, les membres PrixVente, EstEnRupture et Sortir peuvent être erronés ou incomplets. Profitez des tests pour les compléter, les corriger et/ou les vérifier.

## Livrable
Un lien github du projet ou les .cs (seulement) du projet par mail pour la fin de semaine.


# ATELIER 2 – MODULE SHOPPING CART
## Sujet
Tester la [classe Cart](AtelierStock.zip) et, optionnellement, la [classe Article](AtelierStock.zip), qui représentent respectivement un panier de site marchand et
une entrée de ce panier. Appuyez-vous sur la documentation
intégrée pour n’oublier aucun cas usuel, extrême et erreur.
Factoriser les tests, si nécessaire.

## Livrable
.cs du test (ou archive des deux .cs si Article est testé)
