using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Calculator.Globals;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double _lastNumber;
        private double _result;
        private ActiveOperand _activeOperand = ActiveOperand.None;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            var clickedButtonContent = ((Button) sender).Content.ToString();
            switch ( clickedButtonContent )
            {
                case "AC":
                    ResetCalculator();
                    break;

                case "%":
                    if ( double.TryParse(ResultTextBlock.Text, out _lastNumber) )
                    {
                        _lastNumber = _lastNumber / 100;
                        ResultTextBlock.Text = _lastNumber.ToString();
                    }
                    break;

                case "+/-":
                    if ( double.TryParse(ResultTextBlock.Text, out _lastNumber) )
                    {
                        _lastNumber = _lastNumber * -1;
                        ResultTextBlock.Text = _lastNumber.ToString();
                    }
                    break;

                case ".":
                    PlaceDecimalPoint();
                    break;

                case "+":
                    UpdateLastNumber();
                    _activeOperand = ActiveOperand.Add;
                    break;

                case "-":
                    UpdateLastNumber();
                    _activeOperand = ActiveOperand.Subtract;
                    break;

                case "/":
                    UpdateLastNumber();
                    _activeOperand = ActiveOperand.Divide;
                    break;

                case "*":
                    UpdateLastNumber();
                    _activeOperand = ActiveOperand.Multiply;
                    break;

                case "=":
                    PerformCalculation();
                    ResultTextBlock.Text = _result.ToString();
                    _lastNumber = _result;
                    break;


            }



        }

        private void ResetCalculator()
        {
            _activeOperand = ActiveOperand.None;
            ResultTextBlock.Text = "0";
        }

        private void PlaceDecimalPoint()
        {
            if ( !ResultTextBlock.Text.Contains(".") )
            {
                ResultTextBlock.Text = $"{ResultTextBlock.Text}.";
            }
        }

        private void PerformCalculation()
        {
            if ( double.TryParse(ResultTextBlock.Text, out double newNumber) )
            {
                switch ( _activeOperand )
                {
                    case ActiveOperand.Add:
                        _result = Add(_lastNumber, newNumber);
                        break;

                    case ActiveOperand.Divide:
                        if ( newNumber == 0 )
                        {
                            MessageBox.Show("You can't divide by 0.", "Head's up", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        else
                        {
                            _result = Divide(_lastNumber, newNumber);
                        }

                        break;

                    case ActiveOperand.Multiply:
                        _result = Multiply(_lastNumber, newNumber);
                        break;

                    case ActiveOperand.Subtract:
                        _result = Subtract(_lastNumber, newNumber);
                        break;
                }
            }
        }

        private void UpdateLastNumber()
        {
            if ( double.TryParse(ResultTextBlock.Text, out _lastNumber) )
            {
                ResultTextBlock.Text = "0";
            }
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedValue = 0;
            if ( sender == ZeroButton )
            {
                selectedValue = 0;
            }
            if ( sender == OneButton )
            {
                selectedValue = 1;
            }
            if ( sender == TwoButton )
            {
                selectedValue = 2;
            }
            if ( sender == ThreeButton )
            {
                selectedValue = 3;
            }
            if ( sender == FourButton )
            {
                selectedValue = 4;
            }
            if ( sender == FiveButton )
            {
                selectedValue = 5;
            }
            if ( sender == SixButton )
            {
                selectedValue = 6;
            }
            if ( sender == SevenButton )
            {
                selectedValue = 7;
            }
            if ( sender == EightButton )
            {
                selectedValue = 8;
            }
            if ( sender == NineButton )
            {
                selectedValue = 9;
            }
            var displayText = ResultTextBlock.Text;
            ResultTextBlock.Text = displayText == "0" ? $"{selectedValue}" : $"{displayText}{selectedValue}";
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var keyPressed = e.Key;
            switch ( keyPressed )
            {
                case Key.D0:
                    UpdateResultTextBlock(0);
                    break;
                case Key.D1:
                    UpdateResultTextBlock(1);
                    break;
                case Key.D2:
                    UpdateResultTextBlock(2);
                    break;
                case Key.D3:
                    UpdateResultTextBlock(3);
                    break;
                case Key.D4:
                    UpdateResultTextBlock(4);
                    break;
                case Key.D5:
                    UpdateResultTextBlock(5);
                    break;
                case Key.D6:
                    UpdateResultTextBlock(6);
                    break;
                case Key.D7:
                    UpdateResultTextBlock(7);
                    break;
                case Key.D8:
                    UpdateResultTextBlock(8);
                    break;
                case Key.D9:
                    UpdateResultTextBlock(9);
                    break;
                case Key.OemPeriod:
                    PlaceDecimalPoint();
                    break;
                case Key.OemPlus:
                    UpdateLastNumber();
                    _activeOperand = ActiveOperand.Add;
                    break;
                case Key.OemMinus:
                    UpdateLastNumber();
                    _activeOperand = ActiveOperand.Subtract;
                    break;
                case Key.Multiply:
                    UpdateLastNumber();
                    _activeOperand = ActiveOperand.Multiply;
                    break;
                case Key.Divide:
                    UpdateLastNumber();
                    _activeOperand = ActiveOperand.Divide;
                    break;
                case Key.Back:
                    ResultTextBlock.Text = ResultTextBlock.Text.Substring(0, ResultTextBlock.Text.Length - 1);
                    break;
                case Key.Delete:
                    ResetCalculator();
                    break;
                case Key.Escape:
                    Close();
                    break;
                case Key.Enter :
                    PerformCalculation();
                    ResultTextBlock.Text = _result.ToString();
                    _lastNumber = _result;
                    break;
                default:
                    break;
            }
        }
        private void UpdateResultTextBlock(int number)
        {
            ResultTextBlock.Text = ResultTextBlock.Text == "0" ? $"{number}" : $"{ResultTextBlock.Text}{number}";
        }
    }
}
