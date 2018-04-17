using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine;

namespace PaniniTesting
{
    [TestClass]
    public class IntersectarTests
    {
        [TestMethod]
        public void Intersectar()
        {
            ICollection<int> faltantes = new List<int>() { 20, 30, 50, 70 };
            ICollection<int> repetidos = new List<int>() { 30, 50, 90 };

            FiguritaManager figuritaManager = new FiguritaManager();
            List<int> resultado = figuritaManager.Intersectar(faltantes, repetidos);

            CollectionAssert.AreEqual(new List<int>() { 30, 50 }, resultado);
        }

        [TestMethod]
        public void Intersectar_WithDifferentArguments()
        {
            ICollection<int> faltantes = new List<int>() { 60, 70, 80 };
            ICollection<int> repetidos = new List<int>() { 60, 80, 90, 110 };

            FiguritaManager figuritaManager = new FiguritaManager();
            List<int> resultado = figuritaManager.Intersectar(faltantes, repetidos);

            CollectionAssert.AreEqual(new List<int>() { 60, 80 }, resultado);
        }
    }
}
