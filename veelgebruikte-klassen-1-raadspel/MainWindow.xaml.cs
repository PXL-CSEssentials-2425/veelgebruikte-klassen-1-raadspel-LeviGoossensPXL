using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace veelgebruikte_klassen_1_raadspel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numberToGuess;
        int numberOfGuesses;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(numberTextBox.Text))
            {
                MessageBox.Show("Please, type in een geldig getal tussen 1 en 100.");
                return;
            }

            int number;
            bool isValidNumber = int.TryParse(numberTextBox.Text, out number);
            if (!isValidNumber)
            {
                MessageBox.Show("Please, type in een geldig getal tussen 1 en 100.");
                return;
            }
            if (number < 1 || number > 100)
            {
                MessageBox.Show("Please, type in een geldig getal tussen 1 en 100.");
                return;
            }

            switch (numberToGuess)
            {
                case int numberToGuess when number > numberToGuess:
                    output1TextBox.Text = "Raad lager!";
                    break;
                case int numberToGuess when number < numberToGuess:
                    output1TextBox.Text = "Raad hoger!";
                    break;
                case int numberToGuess when number == numberToGuess:
                    output1TextBox.Text = "Proficiat! U hebt het getal geraden!";
                    break;
            }

            numberOfGuesses++;
            output2TextBox.Text = $"Aantal keren geraden: {numberOfGuesses}";
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            numberToGuess = random.Next(1, 101);
            numberOfGuesses = 0;

            numberTextBox.Clear();
            output1TextBox.Clear();
            output2TextBox.Text = $"Aantal keren geraden: {numberOfGuesses}";
        }
    }
}