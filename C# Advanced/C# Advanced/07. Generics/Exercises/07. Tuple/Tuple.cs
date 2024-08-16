namespace _07._Tuple
{
    public class MyTuple<T1, T2>
    {
        public MyTuple(T1 firstItem, T2 secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }

        public T1 FirstItem { get; set; }

        public T2 SecondItem { get; set; }

        public void PrintOutput()
        {
            Console.WriteLine($"{this.FirstItem} -> {this.SecondItem}");
        }
    }
}
