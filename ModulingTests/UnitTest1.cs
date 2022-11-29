using Lab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ModulingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 f = new Form1();
            var text = "";

            var res = f.info.getInfo(text);

            Assert.AreEqual(res, -1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Form1 f = new Form1();
            var text = "aaa";

            var res = f.info.getInfo(text);

            Assert.AreEqual(res, -1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Form1 f = new Form1();
            var text = "1 a";

            var res = f.info.getInfo(text);

            Assert.AreEqual(res, -1);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Form1 f = new Form1();
            var text = "1 1";

            var res = f.info.getInfo(text);

            Assert.AreEqual(res, 11);
        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 f = new Form1();
            var text = "";

            f.setSize(text);

            Assert.AreEqual(f.size, 1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Form1 f = new Form1();
            var text = "0";

            f.setSize(text);

            Assert.AreEqual(f.size, 1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Form1 f = new Form1();
            var text = "11";

            f.setSize(text);

            Assert.AreEqual(f.size, 1);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Form1 f = new Form1();
            var text = "2";

            f.setSize(text);

            Assert.AreEqual(f.size, 2);
        }
    }

    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "";

            f.add(text);
            bool res = string.Join("", array) == string.Join("", f.ResultArray);

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "6 2";

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

            f.add(text);
            bool res = array[1, 2] == f.ResultArray[1, 2] - 1 /*&& array[2, 1] == f.ResultArray[2, 1] - 1*/;

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "2 2";

            f.add(text);
            bool res = array[1, 1] == f.ResultArray[1, 1] - 1;

            Assert.AreEqual(res, true);
        }
    }
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "";

            f.delete(text);
            bool res = string.Join("", array) == string.Join("", f.ResultArray);

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Form1 f = new Form1();
            f.size = 5;
            int[,] array = (int[,])f.ResultArray.Clone();
            var text = "6 2";

            f.delete(text);
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

            f.delete(text);
            bool res = string.Join("", array) == string.Join("", f.ResultArray);

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Form1 f = new Form1();
            f.size = 5;
            var text = "2 3";
            f.add(text);
            int[,] array = (int[,])f.ResultArray.Clone();

            f.delete(text);
            bool res = array[1, 2] == f.ResultArray[1, 2] + 1/* && array[2, 1] == f.ResultArray[2, 1] + 1*/;

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Form1 f = new Form1();
            f.size = 5;
            var text = "2 2";
            f.add(text);
            int[,] array = (int[,])f.ResultArray.Clone();

            f.delete(text);
            bool res = array[1, 1] == f.ResultArray[1, 1] + 1;

            Assert.AreEqual(res, true);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Form1 f = new Form1();
            f.size = 5;
            f.textBox4.Text = "";
            var text = "2 3";
            f.add(text);

            f.delete(text);

            Assert.AreEqual(f.textBox4.Text, "");
        }
        [TestMethod]
        public void TestMethod7()
        {
            Form1 f = new Form1();
            f.size = 5;
            f.textBox4.Text = "";
            var text = "2 3";
            f.add("3 2");

            f.delete(text);

            Assert.AreEqual(f.textBox4.Text.Substring(0, 3), "3 2");
        }
    }
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 f = new Form1();
            f.size = 2;

            f.show();

            Assert.AreEqual(f.headerCount, 2);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Form1 f = new Form1();
            f.size = 5;

            f.show();

            Assert.AreEqual(f.headerCount, 5);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Form1 f = new Form1();
            f.size = 2;

            f.show();

            Assert.AreEqual(f.rawsCount, 2);
            Assert.AreEqual(f.numbersCount, 2 * 2);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Form1 f = new Form1();
            f.size = 5;

            f.show();

            Assert.AreEqual(f.rawsCount, 5);
            Assert.AreEqual(f.numbersCount, 5 * 5);
        }
    }
}