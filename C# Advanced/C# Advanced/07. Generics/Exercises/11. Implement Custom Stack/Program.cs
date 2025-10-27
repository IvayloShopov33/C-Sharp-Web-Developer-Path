namespace _11._Implement_Custom_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            stack.Pop();
            stack.Push(6);

            stack.Pop();
            stack.ForEach(Console.WriteLine);

            CustomStack<string> customStack = new CustomStack<string>();

            customStack.Push("Hello");
            customStack.Push("world!");

            customStack.ForEach(Console.WriteLine);

            foreach (string item in customStack)
            {
                Console.Write(item + " ");
            }
        }
    }
}