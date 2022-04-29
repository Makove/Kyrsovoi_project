using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursedsach
{
    public class FileWorker
    {
        public static string pathRead = "";
        public static string pathSave = "";
        public static string decodingText;
        public static string codingText;
        private static bool cod;
        private static List<int> defaultKey = new List<int> { 19, 12, 16, 18, 17, 10, 16, 15 };
        //public static List<int> key = new List<int>();



        public static bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы .txt| *.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                pathRead = openFileDialog.FileName;
                return true;
            }
            return false;
        }


        public static string Parser()
        {
            using (StreamReader reader = new StreamReader(pathRead))
            {
                string codText = reader.ReadToEnd();
                return Decoder(codText);
            }
        }


        public static string Decoder(string codText)
        {
            decodingText = "";
            codingText = codText;
            cod = true;
            List<string> rusAlf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToList().Select(x => x.ToString()).ToList();
            int j = 0;

            for (int i = 0; i < codingText.Length; i++)
            {
                if (!rusAlf.Contains(codingText[i].ToString()))
                {
                    decodingText += codingText[i];
                    continue;
                }

                if (rusAlf.IndexOf(codingText[i].ToString()) - defaultKey[j] - 1 < 0)
                {
                    int ind = (rusAlf.IndexOf(codingText[i].ToString()) + rusAlf.Count - defaultKey[j] + 1) % 33;
                    decodingText += rusAlf[ind];
                    j = j == defaultKey.Count - 1 ? 0 : ++j;
                }
                else
                {
                    int ind = rusAlf.IndexOf(codingText[i].ToString()) - defaultKey[j] + 1;
                    decodingText += rusAlf[ind];
                    j = j == defaultKey.Count - 1 ? 0 : ++j;
                }
            }
            return decodingText;
        }


        public static string Coder(string decText, string keyStr)
        {
            codingText = "";
            decodingText = decText;
            cod = false;
            List<int> keyList = new List<int>();
            List<string> rusAlf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToList().Select(x => x.ToString()).ToList();
            int j = 0;

            for (int i = 0; i < keyStr.Length; i++)
            {
                keyList.Add(rusAlf.IndexOf(keyStr[i].ToString()) + 1);
            }

            for (int i = 0; i < decodingText.Length; i++)
            {
                if (!rusAlf.Contains(decodingText[i].ToString()))
                {
                    codingText += decodingText[i];
                    continue;
                }

                if (rusAlf.IndexOf(decodingText[i].ToString()) + keyList[j] + 1 > 33)
                {
                    if (rusAlf.IndexOf(decodingText[i].ToString()) - rusAlf.Count + keyList[j] % 33 == 0)
                    {
                        codingText += rusAlf[rusAlf.Count - 1];
                        j = j == keyList.Count - 1 ? 0 : ++j;
                        continue;
                    }
                    int ind = (rusAlf.IndexOf(decodingText[i].ToString()) + keyList[j]) % 33 - 1;
                    codingText += rusAlf[ind];
                    j = j == keyList.Count - 1 ? 0 : ++j;
                }
                else
                {
                    int ind = rusAlf.IndexOf(decodingText[i].ToString()) + keyList[j] - 1;
                    codingText += rusAlf[ind];
                    j = j == keyList.Count - 1 ? 0 : ++j;
                }
            }
            return codingText;
        }


        public static bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы .txt| *.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                pathSave = saveFileDialog.FileName;

                if (cod)
                {
                    using (StreamWriter writer = new StreamWriter(pathSave, false))
                    {
                        writer.WriteLine(decodingText);
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(pathSave, false))
                    {
                        writer.WriteLine(codingText);
                    }
                }
                return true;
            }
            return false;
        }
    }
}
