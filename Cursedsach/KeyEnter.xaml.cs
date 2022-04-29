using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cursedsach
{
    public partial class KeyEnter : Window
    {
        private static string text;
        private static string keyStr;
        private static List<string> rusAlf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToList().Select(x => x.ToString()).ToList();
        public KeyEnter(string texts)
        {
            InitializeComponent();
            text = texts;
    }

        private void Button_Click_Continue(object sender, RoutedEventArgs e)
        { 
            string dt = "";
            for (int i = 0; i < keyStr.Length; i++)
            {
                if (!rusAlf.Contains(keyStr[i].ToString()))
                {
                    MessageBox.Show("В ключе могут использоваться только символы русского алфавита");
                    return;
                }
                dt += keyStr[i].ToString().ToLower();
            }
            keyStr = dt;
            this.Close();
            MessageBox.Show(FileWorker.Coder(text, keyStr), "Зашифрованный текст");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            keyStr = textBox.Text;
        }
    }
}
