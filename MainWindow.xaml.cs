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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Evin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global variables
        string[] words;
        Random r = new Random();
        string wordToGuess;

        public MainWindow()
        {
            InitializeComponent();
            words = new string[10];//instantiate
            System.IO.StreamReader streamReader =
                new System.IO.StreamReader("words.txt");
            int counter = 0;
            while (!streamReader.EndOfStream)
            {
                words[counter] = streamReader.ReadLine();
                words[counter] = words[counter].ToUpper();
                Console.WriteLine(words[counter]);
                counter++;
                
            }//end while
            wordToGuess = words[r.Next(10)];
            MessageBox.Show(wordToGuess);
            //MessageBox.Show(getDashes(wordToGuess));
            txtGuess.Text = getDashes(wordToGuess);
            char A = 'A';
            MessageBox.Show("char A: " + A.ToString() + " is integer: "
                + ((int)A).ToString());
            Button[] buttonsToGuess = new Button[26];
            for (int i = 0; i < 26; i++)
            {
                buttonsToGuess[i] = new Button();
                buttonsToGuess[i].Content = ((char)(i + (int)A)).ToString();
                buttonsToGuess[i].Width = 30;
                buttonsToGuess[i].Click += buttonGuess_Click;
                sp.Children.Add(buttonsToGuess[i]);
            }
        }

        private void buttonGuess_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            /*
             * get letterGuessed
                create string buildWord set to ""
                loop through letters in wordToGuess
                    if letterGuessed == wordToGuess[i]
                        buildWord += wordToGuess[i] + " " 
                    else
                        buildWord += txtGuess.Text[i*2] + " ";
            */
            MessageBox.Show(b.Content.ToString());//change this to guess the letter
            b.Visibility = Visibility.Hidden;
        }

        public string getDashes(string w)
        {
            string buildWord = "";
            for (int i = 0; i < w.Length; i++)
            {
                buildWord += "_ ";
            }
            return buildWord;
        }
    }
}
