namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> subExpressionsIndexes= new Stack<int>();
            List<string> subExpressions= new List<string>();
            string inputText=Console.ReadLine();
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i]=='(')
                {
                    subExpressionsIndexes.Push(i);
                }
                else if (inputText[i]==')')
                {
                    int endIndexOfSubExpression = i;
                    int startIndexOfSubExpression=subExpressionsIndexes.Pop();
                    int count = endIndexOfSubExpression - startIndexOfSubExpression + 1;
                    subExpressions.Add(inputText.Substring(startIndexOfSubExpression, count));
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, subExpressions));
        }
    }
}