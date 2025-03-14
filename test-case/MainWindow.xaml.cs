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

namespace test_case
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

        private string _inputNumber;
        public string InputNumber
        {
            get { return _inputNumber; }
            set { _inputNumber = value;  }
        }
        private bool _isInputValid;
        public bool IsInputValid
        {
            get { return _isInputValid; }
            set { _isInputValid = value; }
        }
        private void InputTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            InputNumber = InputTextBox.Text;
            IsInputValid = IsValidInput(InputNumber);
        }

        private bool IsValidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            if (input.Length != 5) return false;
            return int.TryParse(input, out _); //Проверка на число
        }
        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValidInput(InputNumber))
                {
                    long number = long.Parse(InputNumber);
                    string reversed = ReverseNumber(number);
                    OutputTextBlock.Text = reversed;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное пятизначное число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private string ReverseNumber(long number)
        {
            return new string(number.ToString().ToCharArray().Reverse().ToArray());
        }
        
    }
}