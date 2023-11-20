namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public void AddRange(IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                base.Push(item);
            }
        }
    }
}
