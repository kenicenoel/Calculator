using System.Windows;
using System.Windows.Controls;
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
                    _activeOperand = ActiveOperand.None;
                    ResultTextBlock.Text = "0";
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
                    if ( double.TryParse(ResultTextBlock.Text, out _lastNumber) )
                    {
                        ResultTextBlock.Text = $"{_lastNumber}.";
                    }

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
                    
                    
                    if ( double.TryParse(ResultTextBlock.Text, out double newNumber) )
                    {
                        switch(_activeOperand)
                        {
                            case ActiveOperand.Add:
                                _result = Add(_lastNumber, newNumber);
                                break;

                            case ActiveOperand.Divide:
                                _result = Divide(_lastNumber, newNumber);
                                break;

                            case ActiveOperand.Multiply:
                                _result = Multiply(_lastNumber, newNumber);
                                break;

                            case ActiveOperand.Subtract:
                                _result = Subtract(_lastNumber, newNumber);
                                break;
                        }
                    }
                    ResultTextBlock.Text = _result.ToString();
                    _lastNumber = _result;
                    //_activeOperand = ActiveOperand.None;
                    break;
                   
                
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
            if(sender == ZeroButton)
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
    }
}
