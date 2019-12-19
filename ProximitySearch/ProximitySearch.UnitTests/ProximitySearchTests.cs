using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProximitySearch;


namespace ProximitySearch.UnitTests
{
    [TestClass]
    public class ProximitySearchTests
    {
        [TestMethod]
        public void FindProximityCount_RangeLessThan2_Return_0()
        {
            
            ProximitySearch prox = new ProximitySearch();
            string keyword1 = "dummy1";
            string keyword2 = "dummy2";
            int range = 1;
            string fileName = $@"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Files\sample1.txt";

            int result = prox.FindProximityCount(keyword1, keyword2, range, fileName);

            
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void FindProximityCount_RunNormalSample1_Return_3()
        {
            ProximitySearch prox = new ProximitySearch();
            string keyword1 = "the";
            string keyword2 = "canal";
            int range = 6;
            string fileName = $@"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Files\sample1.txt";

            int result = prox.FindProximityCount(keyword1, keyword2, range, fileName);

            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void FindProximityCount_RunNormalSample1_Return_1()
        {
            ProximitySearch prox = new ProximitySearch();
            string keyword1 = "the";
            string keyword2 = "canal";
            int range = 3;
            string fileName = $@"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Files\sample1.txt";

            int result = prox.FindProximityCount(keyword1, keyword2, range, fileName);
            
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void FindProximityCount_RunNormalSample2_Return_11()
        {
            ProximitySearch prox = new ProximitySearch();
            string keyword1 = "the";
            string keyword2 = "canal";
            int range = 6;
            string fileName = $@"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Files\sample2.txt";

            int result = prox.FindProximityCount(keyword1, keyword2, range, fileName);

            Assert.AreEqual(result, 11);
        }

        [TestMethod]
        public void FindProximityCount_RunNormalLargerSample3_Return_8()
        {
            ProximitySearch prox = new ProximitySearch();
            string keyword1 = "shadow";
            string keyword2 = "knows";
            int range = 6;
            string fileName = $@"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Files\sample3.txt";

            int result = prox.FindProximityCount(keyword1, keyword2, range, fileName);

            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FindProximityCount_FileNotFound_Exception_Thrown()
        {
            ProximitySearch prox = new ProximitySearch();
            string keyword1 = "the";
            string keyword2 = "canal";
            int range = 3;
            string fileName = $@"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Files\nobodyshome.zyx";

            int result = prox.FindProximityCount(keyword1, keyword2, range, fileName);

            Assert.AreEqual(result, 1);
        }


    }
}
