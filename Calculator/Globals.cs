namespace Calculator
{
    public static class Globals
   {
        public enum ActiveOperand
        {
            None,
            Modulus,
            Multiply,
            Divide,
            Subtract,
            Add
        }

        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Divide(double a, double b) => a / b;
        public static double Multiply(double a, double b) => a * b;
   }
}
