using Lab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulingTests
{ 

    [TestClass]
    public class IntegrationTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 f = new Form1();
            f.size = 5;
            var length = f.ResultArray.Length;
            var text = "";
            var mock = new Mock<IGetInfo>();
            mock.Setup(m => m.getInfo(It.IsAny<string>())).Returns(-1);
            f.setGetInfo(mock.Object);

            f.add(text);

            Assert.AreEqual(f.ResultArray.Length, length);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "6 2";
            var mock = new Mock<IGetInfo>();
            mock.Setup(m => m.getInfo(text)).Returns(-1);
            f.setGetInfo(mock.Object);

            f.add(text);
            bool res = string.Join("", array) == string.Join("", f.ResultArray);

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "2 6";
            var mock = new Mock<IGetInfo>();
            mock.Setup(m => m.getInfo(text)).Returns(-1);
            f.setGetInfo(mock.Object);

            f.add(text);
            bool res = string.Join("", array) == string.Join("", f.ResultArray);

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "2 3";
            var mock = new Mock<IGetInfo>();
            mock.Setup(m => m.getInfo(text)).Returns(23);
            f.setGetInfo(mock.Object);

            f.add(text);
            bool res = array[1, 2] == f.ResultArray[1, 2] - 1;

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "2 2";
            var mock = new Mock<IGetInfo>();
            mock.Setup(m => m.getInfo(text)).Returns(22);
            f.setGetInfo(mock.Object);

            f.add(text);
            bool res = array[1, 1] == f.ResultArray[1, 1] - 1;

            Assert.AreEqual(res, true);
        }
    }
}
