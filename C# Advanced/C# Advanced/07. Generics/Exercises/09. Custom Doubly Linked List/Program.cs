namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var customDoublyLinkedList = new CustomDoublyLinkedList<int>();

            customDoublyLinkedList.AddFirst(3);
            // 3
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));

            customDoublyLinkedList.AddFirst(2);
            // 2-3
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));

            customDoublyLinkedList.AddFirst(1);
            // 1-2-3
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));

            customDoublyLinkedList.AddLast(4);
            // 1-2-3-4
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));

            customDoublyLinkedList.AddFirst(0);
            // 0-1-2-3-4
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));

            customDoublyLinkedList.AddLast(100);
            // 0-1-2-3-4-100
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));

            customDoublyLinkedList.RemoveFirst();
            // 1-2-3-4-100
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));

            customDoublyLinkedList.RemoveLast();
            // 1-2-3-4
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));

            customDoublyLinkedList.AddLast(5);
            // 1-2-3-4-5
            Console.WriteLine(string.Join(", ", customDoublyLinkedList.ToArray()));
            // 1, 2, 3, 4, 5

            Console.WriteLine(customDoublyLinkedList.Count);
            // 5

            customDoublyLinkedList.ForEach(x => Console.Write(x + " "));
            // 1 2 3 4 5
        }
    }
}
