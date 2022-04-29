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

    public partial class TextEnter : Window
    {
        private static string text;
        private static List<string> rusAlf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToList().Select(x => x.ToString()).ToList();


        public TextEnter()
        {
            InitializeComponent();
        }


        private void Button_Click_Continue(object sender, RoutedEventArgs e)
        {
            List<int> key = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]) && !rusAlf.Contains(text[i].ToString()) || Char.IsUpper(text[i]) && rusAlf.Contains(text[i].ToString().ToLower()))
                {
                    MessageBox.Show("В тексте могут использоваться буквы только русского алфавита в нижнем регистре");
                    return;
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                key.Add(rusAlf.IndexOf(text[i].ToString()) + 1);
            }
            this.Close();
            KeyEnter keyEnterWindow = new KeyEnter(text);
            keyEnterWindow.Show();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            text = textBox.Text;
        }
    }
}
