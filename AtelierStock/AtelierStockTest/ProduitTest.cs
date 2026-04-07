namespace AtelierStock
{
    [TestClass]
    public class ProduitTest
    {
        #region Initialisation - Prix d'achat et de Vente
        [TestMethod]
        public void Initialiser_ProduitQuelconque()
        {
            // Arrange
            var prixAchat = 100.0m;
            var marge = 0.18m;

            // Act
            var p = new Produit("REF", "UnNom", prixAchat, marge);

            // Assert
            Assert.AreEqual("REF"  , p.Reference);
            Assert.AreEqual("UnNom", p.Libelle);
            Assert.AreEqual(100.0m , p.PrixAchat);
            Assert.AreEqual(118.0m , p.PrixVente);
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Initialiser_ProduitMarge0()
        {
            // Arrange & Act
            var p = new Produit("REF", "UnNom", 100, 0);

            // Assert
            Assert.AreEqual("REF", p.Reference);
            Assert.AreEqual("UnNom", p.Libelle);
            Assert.AreEqual(100.0m, p.PrixAchat);
            Assert.AreEqual(100.0m, p.PrixVente); // Pas de marge: prix vente = prix achat
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Initialiser_ProduitMargeNegative()
        {
            // Arrange & Act
            var p = new Produit("REF", "UnNom", 100, -0.1m);

            // Assert
            Assert.AreEqual(90.0m, p.PrixVente); // Prix réduit de 10%: 100 * (1 - 0.1) = 90
        }

        [TestMethod]
        public void Initialiser_ProduitMargeDouble()
        {
            // Arrange & Act
            var p = new Produit("REF", "UnNom", 100, 1m);

            // Assert
            Assert.AreEqual(200.0m, p.PrixVente); // Marge de 100%: 100 * (1 + 1) = 200
        }
        #endregion

        #region Gestion des Stocks
        [TestMethod]
        public void Rentrer_AjouterUnSeulArticle()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);

            // Act
            p.Rentrer(1);

            // Assert
            Assert.AreEqual(1, p.Stocks);
            Assert.IsFalse(p.EstEnRupture);
        }

        [TestMethod]
        public void Rentrer_AjouterPlusieursArticles()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);

            // Act
            p.Rentrer(10);

            // Assert
            Assert.AreEqual(10, p.Stocks);
            Assert.IsFalse(p.EstEnRupture);
        }

        [TestMethod]
        public void Rentrer_AjouterPlusieursLots()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);

            // Act
            p.Rentrer(10);
            p.Rentrer(5);
            p.Rentrer(15);

            // Assert
            Assert.AreEqual(30, p.Stocks);
        }

        [TestMethod]
        public void Sortir_SortirQuantiteDisponible()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);
            p.Rentrer(10);

            // Act
            var quantiteRetireee = p.Sortir(5);

            // Assert
            Assert.AreEqual(5, quantiteRetireee);
            Assert.AreEqual(5, p.Stocks);
            Assert.IsFalse(p.EstEnRupture);
        }

        [TestMethod]
        public void Sortir_SortirToutLeStock()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);
            p.Rentrer(10);

            // Act
            var quantiteRetireee = p.Sortir(10);

            // Assert
            Assert.AreEqual(10, quantiteRetireee);
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Sortir_MultipleSortieSuccessives()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);
            p.Rentrer(20);

            // Act & Assert
            Assert.AreEqual(5, p.Sortir(5));
            Assert.AreEqual(15, p.Stocks);
            
            Assert.AreEqual(8, p.Sortir(8));
            Assert.AreEqual(7, p.Stocks);
            
            Assert.AreEqual(3, p.Sortir(3));
            Assert.AreEqual(4, p.Stocks);
        }
        #endregion

        #region Rupture de Stock
        [TestMethod]
        public void EstEnRupture_InitialisationStockVide()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);

            // Act & Assert
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void EstEnRupture_ApresSortirTout()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);
            p.Rentrer(5);

            // Act
            p.Sortir(5);

            // Assert
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Sortir_AvecRupture_DemandeSuperieurDisponible()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);
            p.Rentrer(5);

            // Act
            var quantiteRetireee = p.Sortir(10);

            // Assert - Doit retourner ce qui est disponible, pas ce qui a été demandé
            Assert.AreEqual(5, quantiteRetireee); // Retourne 5 (disponible), pas 10 (demandé)
            Assert.AreEqual(0, p.Stocks);        // Stock vide
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Sortir_AvecRupture_StockNeDevientPasNegatif()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);
            p.Rentrer(3);

            // Act
            p.Sortir(10); // Demande 10, seuls 3 disponibles

            // Assert - Le stock ne doit JAMAIS être négatif
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Sortir_AvecRupture_SortieSurStockVide()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);

            // Act
            var quantiteRetireee = p.Sortir(5);

            // Assert
            Assert.AreEqual(0, quantiteRetireee);
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }
        #endregion

        #region Cas Extrêmes
        [TestMethod]
        public void Sortir_QuantiteZero()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);
            p.Rentrer(10);

            // Act
            var quantiteRetireee = p.Sortir(0);

            // Assert
            Assert.AreEqual(0, quantiteRetireee);
            Assert.AreEqual(10, p.Stocks);
        }

        [TestMethod]
        public void RentrerEtSortir_LargesQuantites()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 100, 0.1m);

            // Act
            p.Rentrer(1000000);
            var sortie = p.Sortir(500000);

            // Assert
            Assert.AreEqual(500000, sortie);
            Assert.AreEqual(500000, p.Stocks);
        }

        [TestMethod]
        public void PrixVente_DecimalesPrecises()
        {
            // Arrange
            var p = new Produit("REF", "Produit", 10.50m, 0.15m);

            // Act
            var prixVente = p.PrixVente;

            // Assert
            Assert.AreEqual(12.075m, prixVente); // 10.50 * 1.15 = 12.075
        }
        #endregion
    }
}