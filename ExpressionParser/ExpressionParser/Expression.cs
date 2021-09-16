namespace ExpressionParser
{
    internal class Expression
    {
        public Expression()
        {
            _operators = null;
            _operands = null;
        }

        private Component _operators;
        private Component _operands;

        public void Build(string mathExpression)
        {
            for (var i = 0; i < mathExpression.Length; i++)
            {
                var currentChar = mathExpression[i];

                if (char.IsWhiteSpace(currentChar))
                    continue;

                if (char.IsDigit(currentChar))
                {
                    var number = this.GetNumber(mathExpression, i);
                    i += number.Length - 1;

                    this.PushOperand(number);
                }
                else
                    this.PushOperator(currentChar.ToString());
            }
        }

        private string GetNumber(string expression, int startPosition)
        {
            var number = string.Empty;

            for (var i = startPosition; i < expression.Length; i++)
            {
                var currentChar = expression[i];

                if (!char.IsDigit(currentChar) || char.IsWhiteSpace(currentChar))
                    break;

                number = string.Concat(number, currentChar);
            }

            return number;
        }

        public double Calculate()
        {
            return 0;
        }

        private void PushOperand(string number)
        {
            var operandsList = _operands;
            _operands = new Component(number) { NextComponent = operandsList };
        }

        private void PushOperator(string mathOperator)
        {
            var operatorList = _operators;
            _operators = new Component(mathOperator) { NextComponent = operatorList };
        }

        private void PopOperand() =>
            _operands = _operands.NextComponent;

        private void PopOperator() =>
            _operators = _operators.NextComponent;
    }
}
