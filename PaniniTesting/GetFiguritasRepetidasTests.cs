using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine;

namespace PaniniTesting
{
    [TestClass]
    public class GetFiguritasRepetidasTests
    {
        [TestMethod]
        public void GetFiguritasRepetidas()
        {
            Niño niño1 = new Niño()
            {
                Id = 1,
                Copias = new List<Copia>()
                {
                    new Copia() { Figurita = new Figurita() { Id = 10 }, Cantidad = 2 },
                    new Copia() { Figurita = new Figurita() { Id = 20 }, Cantidad = 1 },
                    new Copia() { Figurita = new Figurita() { Id = 30 }, Cantidad = 3 },
                    new Copia() { Figurita = new Figurita() { Id = 40 }, Cantidad = 1 }
                }
            };

            FiguritaManager paniniManager = new FiguritaManager();
            List<int> resultado = paniniManager.GetFiguritasRepetidas(niño1);

            CollectionAssert.AreEqual(new List<int>() { 10, 30 }, resultado);
        }
    }
}
