using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine;

namespace PaniniTesting
{
    [TestClass]
    public class GetFiguritasFaltantesTests
    {
        [TestMethod]
        public void GetFiguritasFaltantes()
        {
            ICollection<Figurita> figuritas = new List<Figurita>();
            for (int i = 10; i <= 100; i += 10)
            {
                figuritas.Add(new Figurita() { Id = i });
            }

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
            List<int> resultado = paniniManager.GetFiguritasFaltantes(niño1, figuritas);

            CollectionAssert.AreEqual(new List<int>() { 50, 60, 70, 80, 90, 100 }, resultado);
        }
    }
}
