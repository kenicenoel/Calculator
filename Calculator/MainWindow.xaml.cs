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
                   _lastNumber = 0;
                    _activeOperand = ActiveOperand.None;
                    ResultTextBlock.Text = _lastNumber.ToString();
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

                case "+":
                    ResolveActiveOperand();
                    _activeOperand = ActiveOperand.Add;
                    break;
            }
            
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            var clickedButtonContent = ((Button) sender).Content.ToString();
            _lastNumber = double.Parse(ResultTextBlock.Text);
             ResultTextBlock.Text = _lastNumber == 0 ? clickedButtonContent : $"{_lastNumber}{clickedButtonContent}";
                _lastNumber = double.Parse(ResultTextBlock.Text);
          
            
        }

        private void ResolveActiveOperand()
        {
            if(_activeOperand == ActiveOperand.None)
            {
                return;
            }
            
            switch ( _activeOperand )
            {
                case ActiveOperand.Add:
                    if ( double.TryParse(ResultTextBlock.Text, out double _lastNumber) )
                    {
                        _result+= _lastNumber;
                        ResultTextBlock.Text = _result.ToString();
                    }
                    break;
            }
        }
    }
}
