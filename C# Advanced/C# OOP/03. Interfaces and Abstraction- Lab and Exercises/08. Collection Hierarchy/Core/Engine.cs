using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models;

namespace CollectionHierarchy.Core
{
    internal class Engine : IEngine
    {
        public void Run()
        {
            AddCollection<string> addCollection = new AddCollection<string>();
            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            string[] inputElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[] addCollectionIndexes, addRemoveCollectionIndexes, myListIndexes;
            AddInAnyCollection(addCollection, addRemoveCollection, myList, inputElements, out addCollectionIndexes, out addRemoveCollectionIndexes, out myListIndexes);

            int removeOperationsCount = int.Parse(Console.ReadLine());

            string[] removedElementsOfAddRemoveCollection, removedElementsOfMyList;
            RemoveElementsFromCollections(addRemoveCollection, myList, removeOperationsCount, out removedElementsOfAddRemoveCollection, out removedElementsOfMyList);

            PrintResults(addCollectionIndexes, addRemoveCollectionIndexes, myListIndexes, removedElementsOfAddRemoveCollection, removedElementsOfMyList);
        }

        private static void AddInAnyCollection(AddCollection<string> addCollection, AddRemoveCollection<string> addRemoveCollection, MyList<string> myList, string[] inputElements, out int[] addCollectionIndexes, out int[] addRemoveCollectionIndexes, out int[] myListIndexes)
        {
            addCollectionIndexes = new int[inputElements.Length];
            addRemoveCollectionIndexes = new int[inputElements.Length];
            myListIndexes = new int[inputElements.Length];
            int index = 0;

            foreach (string inputElement in inputElements)
            {
                addCollectionIndexes[index] = addCollection.Add(inputElement);
                addRemoveCollectionIndexes[index] = addRemoveCollection.Add(inputElement);
                myListIndexes[index] = myList.Add(inputElement);
                index++;
            }
        }

        private static void RemoveElementsFromCollections(AddRemoveCollection<string> addRemoveCollection, MyList<string> myList, int removeOperationsCount, out string[] removedElementsOfAddRemoveCollection, out string[] removedElementsOfMyList)
        {
            removedElementsOfAddRemoveCollection = new string[removeOperationsCount];
            removedElementsOfMyList = new string[removeOperationsCount];
            for (int i = 0; i < removeOperationsCount; i++)
            {
                removedElementsOfAddRemoveCollection[i] = addRemoveCollection.Remove();
                removedElementsOfMyList[i] = myList.Remove();
            }
        }

        private static void PrintResults(int[] addCollectionIndexes, int[] addRemoveCollectionIndexes, int[] myListIndexes, string[] removedElementsOfAddRemoveCollection, string[] removedElementsOfMyList)
        {
            Console.WriteLine(string.Join(" ", addCollectionIndexes));
            Console.WriteLine(string.Join(" ", addRemoveCollectionIndexes));
            Console.WriteLine(string.Join(" ", myListIndexes));
            Console.WriteLine(string.Join(" ", removedElementsOfAddRemoveCollection));
            Console.WriteLine(string.Join(" ", removedElementsOfMyList));
        }
    }
}
