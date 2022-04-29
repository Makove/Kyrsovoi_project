using System;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace Cursedsach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click_Choose_File(object sender, RoutedEventArgs e)
        {
            if (FileWorker.pathRead == "")
            {
                FileWorker.OpenFileDialog();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("У вас уже загружен файл. Хотите выбрать новый файл для загрузки?", "Загрузка файла", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        FileWorker.OpenFileDialog();
                        break;
                    case MessageBoxResult.No:
                        return;
                }
            }
        }


        private void Button_Click_Decodering(object sender, RoutedEventArgs e)
        {
            if (FileWorker.pathRead == "")
            {
                MessageBox.Show("У вас не загружен файл. Перед расшифровкой загрузите файл");
            }
            else
            {
                FileWorker.Parser();
                MessageBox.Show(FileWorker.Decoder(FileWorker.codingText), "Расшифрованный текст");
            }
        }


        private void Button_Click_Codering(object sender, RoutedEventArgs e)
        {
            if (FileWorker.pathRead != "")
            {
                MessageBoxResult result = MessageBox.Show("У вас уже загружен файл для дешифровки, сохраните его. Если вы продолжите то вы уже не сможете с ними работать, продолжить?", "", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        TextEnter textEnterWindow = new TextEnter();
                        textEnterWindow.Show();
                        textEnterWindow.Owner = this;
                        break;
                    case MessageBoxResult.No:
                        return;
                }
            }
            else
            {
                TextEnter textEnterWindow = new TextEnter();
                try
                {
                    textEnterWindow.Show();
                    textEnterWindow.Owner = this;

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }


        private void Button_Click_Save_File(object sender, RoutedEventArgs e)
        {
            if (FileWorker.decodingText == "" && FileWorker.codingText == "")
            {
                MessageBox.Show("Вы ещё не обработали файл!");
                return;
            }
            FileWorker.SaveFileDialog();
        }
    }
}
