namespace ExpressionParser
{
    internal class Operation
    {
        internal double Operate(double firstOperand, double secondOperand, string @operator) =>
            @operator switch
            {
                "+" => firstOperand + secondOperand,
                "-" => firstOperand - secondOperand,
                "*" => firstOperand * secondOperand,
                _ => double.NaN
            };
    }
}
