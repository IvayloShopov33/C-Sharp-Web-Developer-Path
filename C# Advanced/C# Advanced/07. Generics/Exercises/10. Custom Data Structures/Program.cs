namespace _10._Custom_Data_Structures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            
            list.Add(10);
            list.Add(30);
            
            list[0] = 100;
            list.Print();
            
            list.Add(10);
            list.RemoveAt(0);
            
            list.Swap(0, 1);
            list.Print();
            
            list.RemoveAt(0);
            list.Print();
            
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Contains(30));
        }
    }
}
