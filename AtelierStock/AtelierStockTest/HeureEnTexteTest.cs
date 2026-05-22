using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AtelierStock;

namespace AtelierStockTest
{
    [TestClass]
    public class HeureEnTexteTest
    {
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

        [TestMethod]
        public void HeurePileMatin_7h00()
        {
            var dt = new DateTime(2022, 1, 1, 7, 0, 0);
            Assert.AreEqual("sept heures du matin", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void HeurePileApresMidi_14h00()
        {
            var dt = new DateTime(2022, 1, 1, 14, 0, 0);
            Assert.AreEqual("deux heures de l'après-midi", HeureEnTexte.Convertir(dt));
        }

        [TestMethod]
        public void HeurePileMatin_1h00()
        {
            var dt = new DateTime(2022, 1, 1, 1, 0, 0);
            Assert.AreEqual("une heure du matin", HeureEnTexte.Convertir(dt));
        }
    }
}