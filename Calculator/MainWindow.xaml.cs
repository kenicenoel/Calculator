using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            var clickedButtonContent = ((Button) sender).Content.ToString();
            var currentResultContent = ResultTextBlock.Text;
            ResultTextBlock.Text = currentResultContent.Equals("0") ? clickedButtonContent : $"{currentResultContent}{clickedButtonContent}";
        }
    }
}
