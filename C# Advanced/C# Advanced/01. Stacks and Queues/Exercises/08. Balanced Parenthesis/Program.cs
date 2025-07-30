namespace _8._Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> balancedParentheses = new Stack<char>();
            string parentheses = Console.ReadLine();
            bool isBalanced = true;
            int countOfOpenBrackets = 0;
            int countOfClosedBrackets = 0;

            for (int i = 0; i < parentheses.Length; i++)
            {
                char @char = parentheses[i];
                if (@char == '(' || @char == '{' || @char == '[')
                {
                    balancedParentheses.Push(@char);
                    countOfOpenBrackets++;
                }
                else if (@char == ')' || @char == '}' || @char == ']')
                {
                    countOfClosedBrackets++;
                    if (balancedParentheses.Count > 0)
                    {
                        if ((@char == ')' && balancedParentheses.Pop() != '(') ||
                            (@char == '}' && balancedParentheses.Pop() != '{') ||
                            (@char == ']' && balancedParentheses.Pop() != '['))
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced && countOfOpenBrackets == countOfClosedBrackets)
            {
                Console.WriteLine("YES");
            }                    
            else 
            {
                Console.WriteLine("NO");       
            }              
        }
    }
}