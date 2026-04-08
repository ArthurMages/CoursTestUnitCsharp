using Microsoft.VisualStudio.TestTools.UnitTesting;
using AtelierStock;

namespace AtelierStockTest
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Ajouter_Produit_AugmenteCompteur()
        {
            var cart = new Cart();
            var p = new Produit("REF1", "Produit1", 10, 0.2m);
            cart.Ajouter(p);
            Assert.AreEqual(1, cart.Compter());
            Assert.AreEqual(p, cart.Produits[0]);
        }

        [TestMethod]
        public void Retirer_ProduitDiminueCompteur()
        {
            var cart = new Cart();
            var p = new Produit("REF1", "Produit1", 10, 0.2m);
            cart.Ajouter(p);
            var result = cart.Retirer(p);
            Assert.IsTrue(result);
            Assert.AreEqual(0, cart.Compter());
        }

        [TestMethod]
        public void Retirer_ProduitAbsent_RetourneFalse()
        {
            var cart = new Cart();
            var p = new Produit("REF1", "Produit1", 10, 0.2m);
            var result = cart.Retirer(p);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Vider_RendPanierVide()
        {
            var cart = new Cart();
            cart.Ajouter(new Produit("REF1", "Produit1", 10, 0.2m));
            cart.Ajouter(new Produit("REF2", "Produit2", 20, 0.1m));
            cart.Vider();
            Assert.AreEqual(0, cart.Compter());
        }

        [TestMethod]
        public void Total_CalculeSommePrixVente()
        {
            var cart = new Cart();
            cart.Ajouter(new Produit("REF1", "Produit1", 10, 0.2m)); // 12
            cart.Ajouter(new Produit("REF2", "Produit2", 20, 0.1m)); // 22
            Assert.AreEqual(34.0m, cart.Total());
        }

        [TestMethod]
        public void Compter_PanierVide_RetourneZero()
        {
            var cart = new Cart();
            Assert.AreEqual(0, cart.Compter());
        }

        [TestMethod]
        public void Ajouter_MemeProduitPlusieursFois()
        {
            var cart = new Cart();
            var p = new Produit("REF1", "Produit1", 10, 0.2m);
            cart.Ajouter(p);
            cart.Ajouter(p);
            Assert.AreEqual(2, cart.Compter());
        }
    }
}
