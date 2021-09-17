namespace ExpressionParser
{
    internal class Expression
    {
        public Expression(string expression)
        {
            _expression = expression ?? string.Empty;

            _operatorsHead = null;
            _operandsHead = null;
        }

        private readonly string _expression;
        private Component _operatorsHead;
        private Component _operandsHead;

        public double Calculate()
        {
            var operation = new Operation();

            for (var i = 0; i < _expression.Length; i++)
            {
                var currentChar = _expression[i];

                if (char.IsWhiteSpace(currentChar) || currentChar.Equals('('))
                    continue;

                if (currentChar.Equals(')'))
                {
                    var rightOperand = double.Parse(_operandsHead.Value);
                    this.PopOperand();

                    var leftOperand = double.Parse(_operandsHead.Value);
                    this.PopOperand();

                    var @operator = _operatorsHead.Value;
                    this.PopOperator();

                    this.PushOperand(operation.Operate(leftOperand, rightOperand, @operator).ToString());

                    continue;
                }

                if (char.IsDigit(currentChar))
                    this.PushOperand(currentChar.ToString());
                else
                    this.PushOperator(currentChar.ToString());
            }

            return !string.IsNullOrWhiteSpace(_operandsHead?.Value) 
                ? double.Parse(_operandsHead.Value)
                : double.NaN;
        }

        private void PushOperand(string number)
        {
            var operandsList = _operandsHead;
            _operandsHead = new Component(number) { NextComponent = operandsList };
        }

        private void PushOperator(string mathOperator)
        {
            var operatorList = _operatorsHead;
            _operatorsHead = new Component(mathOperator) { NextComponent = operatorList };
        }

        private void PopOperand() =>
            _operandsHead = _operandsHead.NextComponent;

        private void PopOperator() =>
            _operatorsHead = _operatorsHead.NextComponent;
    }
}
