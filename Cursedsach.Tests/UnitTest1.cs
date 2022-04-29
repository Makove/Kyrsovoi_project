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
            string str = "бщцфаирщри, бл €чъбиуъ щбюэс€Єш гфуаа!!!";
            string expected = "поздравл€ю, ты получил исходный текст!!!";

            string actual = FileWorker.Decoder(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Decoder_2()
        {
            string str = "ьк€ь г уънвЄ выаиъ шаыоьыд";
            string expected = "карл у клары украл кораллы";

            string actual = FileWorker.Decoder(str);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void —oder_1()
        {
            string str = "поздравл€ю, ты получил исходный текст!!!";
            string key = "скорпион";
            string expected = "бщцфаирщри, бл €чъбиуъ щбюэс€Єш гфуаа!!!";

            string actual = FileWorker.Coder(str, key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void —oder_2()
        {
            string str = "карл у клары украл кораллы";
            string key = "носорог";
            string expected = "шовъ д щон€м вы€гщ ща€ръои";

            string actual = FileWorker.Coder(str, key);

            Assert.AreEqual(expected, actual);
        }
    }
}