using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cursedsach;

namespace Cursedsach.Tests
{
    [TestClass]
    public class CursedsachTests
    {
        [TestMethod]
        public void Decoder_1()
        {
            string str = "����������, �� ������� �������� �����!!!";
            string expected = "����������, �� ������� �������� �����!!!";

            string actual = FileWorker.Decoder(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decoder_2()
        {
            string str = "���� � ���� ����� �������";
            string expected = "���� � ����� ����� �������";

            string actual = FileWorker.Decoder(str);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void �oder_1()
        {
            string str = "����������, �� ������� �������� �����!!!";
            string key = "��������";
            string expected = "����������, �� ������� �������� �����!!!";

            string actual = FileWorker.Coder(str, key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void �oder_2()
        {
            string str = "���� � ����� ����� �������";
            string key = "�������";
            string expected = "���� � ����� ����� �������";

            string actual = FileWorker.Coder(str, key);

            Assert.AreEqual(expected, actual);
        }
    }
}