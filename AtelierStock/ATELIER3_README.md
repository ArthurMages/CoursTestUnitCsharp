# Atelier 3 : Heure en texte (TDD)

## Implémentation complète

L'atelier a été réalisé en suivant l'approche TDD (Test-Driven Development) avec les 6 étapes recommandées.

## Fichiers créés/modifiés

- **HeureEnTexte.cs** : Classe statique avec la méthode `Convertir(DateTime)` qui convertit une heure en texte français
- **HeureEnTexteTest.cs** : 14 tests unitaires couvrant tous les cas d'usage

## Tests implémentés (41 tests passent au total)

### Étape 1 : Heures pile du matin
- 7:00 => "sept heures du matin"
- 1:00 => "une heure du matin"

### Étape 2 : Heures pile de l'après-midi
- 14:00 => "deux heures de l'après-midi"
- 13:00 => "une heure de l'après-midi"

### Étape 3 : Heures pile spéciales
- 12:00 => "midi"
- 00:00 => "minuit"

### Étape 4 : Tranches de 5 minutes première demi-heure
- 12:10 => "midi dix"
- 15:25 => "trois heures vingt-cinq de l'après-midi"
- 00:15 => "minuit et quart"
- 07:30 => "sept heures et demie du matin"

### Étape 5 : Tranches de 5 minutes après la demi-heure
- 8:45 => "neuf heures moins le quart"
- 12:35 => "une heure moins vingt-cinq de l'après-midi"
- 0:55 => "une heure moins cinq du matin"

### Étape 6 : Minutes précises (non multiples de 5)
- 8:48 => "neuf heures moins dix du matin à deux minutes près"
- 12:04 => "midi cinq à une minute près"
- 15:23 => "trois heures vingt-cinq de l'après-midi à deux minutes près"

## Résultat des tests

```
Réussi! - échec : 0, réussite : 41, ignorée(s) : 0, total : 41
```

## Utilisation

```csharp
using AtelierStock;
using System;

var dt = new DateTime(2022, 1, 1, 8, 45, 0);
string heure = HeureEnTexte.Convertir(dt);
Console.WriteLine(heure); // "neuf heures moins le quart"
```
