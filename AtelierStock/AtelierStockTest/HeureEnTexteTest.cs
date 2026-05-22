using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AtelierStock;

namespace AtelierStockTest
{
    [TestClass]
    public class HeureEnTexteTest
    {
        // Étape 1 : Heures pile du matin
        [TestMethod]
        public void HeurePileMatin_7h00()
        {
            var dt = new DateTime(2022, 1, 1, 7, 0, 0);
            Assert.AreEqual("sept heures du matin", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void HeurePileMatin_1h00()
        {
            var dt = new DateTime(2022, 1, 1, 1, 0, 0);
            Assert.AreEqual("une heure du matin", HeureEnTexte.Convertir(dt));
        }

        // Étape 2 : Heures pile de l'après-midi
        [TestMethod]
        public void HeurePileApresMidi_14h00()
        {
            var dt = new DateTime(2022, 1, 1, 14, 0, 0);
            Assert.AreEqual("deux heures de l'après-midi", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void HeurePileApresMidi_13h00()
        {
            var dt = new DateTime(2022, 1, 1, 13, 0, 0);
            Assert.AreEqual("une heure de l'après-midi", HeureEnTexte.Convertir(dt));
        }

        // Étape 3 : Heures pile spéciales
        [TestMethod]
        public void HeurePileSpeciale_Midi()
        {
            var dt = new DateTime(2022, 1, 1, 12, 0, 0);
            Assert.AreEqual("midi", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void HeurePileSpeciale_Minuit()
        {
            var dt = new DateTime(2022, 1, 1, 0, 0, 0);
            Assert.AreEqual("minuit", HeureEnTexte.Convertir(dt));
        }

        // Étape 4 : Tranches de 5 minutes première demi-heure
        [TestMethod]
        public void Tranche5minPremiereDemiHeure_12h10()
        {
            var dt = new DateTime(2022, 1, 1, 12, 10, 0);
            Assert.AreEqual("midi dix", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void Tranche5minPremiereDemiHeure_15h25()
        {
            var dt = new DateTime(2022, 1, 1, 15, 25, 0);
            Assert.AreEqual("trois heures vingt-cinq de l'après-midi", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void Tranche5minPremiereDemiHeure_0h15()
        {
            var dt = new DateTime(2022, 1, 1, 0, 15, 0);
            Assert.AreEqual("minuit et quart", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void Tranche5minPremiereDemiHeure_7h30()
        {
            var dt = new DateTime(2022, 1, 1, 7, 30, 0);
            Assert.AreEqual("sept heures et demie du matin", HeureEnTexte.Convertir(dt));
        }

        // Étape 5 : Tranches de 5 minutes après la demi-heure
        [TestMethod]
        public void Tranche5minApresDemiHeure_8h45()
        {
            var dt = new DateTime(2022, 1, 1, 8, 45, 0);
            Assert.AreEqual("neuf heures moins le quart", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void Tranche5minApresDemiHeure_12h35()
        {
            var dt = new DateTime(2022, 1, 1, 12, 35, 0);
            Assert.AreEqual("une heure moins vingt-cinq de l'après-midi", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void Tranche5minApresDemiHeure_0h55()
        {
            var dt = new DateTime(2022, 1, 1, 0, 55, 0);
            Assert.AreEqual("une heure moins cinq du matin", HeureEnTexte.Convertir(dt));
        }

        // Étape 6 : Minutes précises
        [TestMethod]
        public void MinutesPrecises_8h48()
        {
            var dt = new DateTime(2022, 1, 1, 8, 48, 0);
            Assert.AreEqual("neuf heures moins dix du matin à deux minutes près", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void MinutesPrecises_12h04()
        {
            var dt = new DateTime(2022, 1, 1, 12, 4, 0);
            Assert.AreEqual("midi cinq à une minute près", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void MinutesPrecises_15h23()
        {
            var dt = new DateTime(2022, 1, 1, 15, 23, 0);
            Assert.AreEqual("trois heures vingt-cinq de l'après-midi à deux minutes près", HeureEnTexte.Convertir(dt));
        }
    }
}