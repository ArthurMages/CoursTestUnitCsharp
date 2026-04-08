using System.Collections.Generic;
using System.Linq;

namespace AtelierStock
{
    /// <summary>
    /// Représente un panier d'achat pour un site marchand.
    /// </summary>
    public class Cart
    {
        private readonly List<Produit> _produits = new();

        /// <summary>
        /// Ajoute un produit au panier.
        /// </summary>
        public void Ajouter(Produit produit)
        {
            _produits.Add(produit);
        }

        /// <summary>
        /// Retire un produit du panier (première occurrence).
        /// </summary>
        public bool Retirer(Produit produit)
        {
            return _produits.Remove(produit);
        }

        /// <summary>
        /// Vide le panier.
        /// </summary>
        public void Vider()
        {
            _produits.Clear();
        }

        /// <summary>
        /// Nombre total d'articles dans le panier.
        /// </summary>
        public int Compter() => _produits.Count;

        /// <summary>
        /// Calcule le total du panier (somme des prix de vente).
        /// </summary>
        public decimal Total() => _produits.Sum(p => p.PrixVente);

        /// <summary>
        /// Liste des produits du panier (lecture seule).
        /// </summary>
        public IReadOnlyList<Produit> Produits => _produits.AsReadOnly();
    }
}
