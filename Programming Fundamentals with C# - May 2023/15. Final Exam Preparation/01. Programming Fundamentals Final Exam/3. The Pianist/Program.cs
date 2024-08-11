using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Masterpiece> masterpieces = new List<Masterpiece>();
            InitializeMasterpieces(masterpieces);
            Commands(masterpieces);
            PrintMasterpieces(masterpieces);
        }
        static void InitializeMasterpieces(List<Masterpiece> masterpieces)
        {
            int initialPiecesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= initialPiecesCount; i++)
            {
                string[] pieceDetails = Console.ReadLine().Split('|');
                string piece = pieceDetails[0];
                string composer = pieceDetails[1];
                string key = pieceDetails[2];
                Masterpiece masterpiece = new Masterpiece(piece, composer, key);
                masterpieces.Add(masterpiece);
            }
        }

        static void Commands(List<Masterpiece> masterpieces)
        {
            string[] commands = Console.ReadLine().Split('|');
            while (commands[0] != "Stop")
            {
                bool isThere = false;
                string newPiece = commands[1];
                if (commands[0] == "Add")
                {
                    string newComposer = commands[2];
                    string newKey = commands[3];
                    foreach (Masterpiece masterpiece in masterpieces)
                    {
                        if (masterpiece.Piece == newPiece)
                        {
                            Console.WriteLine($"{newPiece} is already in the collection!");
                            isThere = true;
                            break;
                        }
                    }
                    if (!isThere)
                    {
                        Masterpiece newMasterpiece = new Masterpiece(newPiece, newComposer, newKey);
                        masterpieces.Add(newMasterpiece);
                        Console.WriteLine($"{newMasterpiece.Piece} by {newMasterpiece.Composer} in {newMasterpiece.Key} added to the collection!");
                    }
                }
                else if (commands[0] == "Remove")
                {
                    foreach (Masterpiece masterpiece in masterpieces)
                    {
                        if (masterpiece.Piece == newPiece)
                        {
                            Masterpiece masterpieceToRemove = masterpieces.First(g => g.Piece == newPiece);
                            masterpieces.Remove(masterpieceToRemove);
                            Console.WriteLine($"Successfully removed {newPiece}!");
                            isThere = true;
                            break;
                        }
                    }
                    if (!isThere)
                    {
                        Console.WriteLine($"Invalid operation! {newPiece} does not exist in the collection.");
                    }
                }
                else if (commands[0] == "ChangeKey")
                {
                    string newKey = commands[2];
                    foreach (Masterpiece masterpiece in masterpieces)
                    {
                        if (masterpiece.Piece == newPiece)
                        {
                            Masterpiece masterpieceToChangeKey = masterpieces.First(g => g.Piece == newPiece);
                            masterpieceToChangeKey.Key = newKey;
                            isThere = true;
                            Console.WriteLine($"Changed the key of {newPiece} to {newKey}!");
                            break;
                        }
                    }
                    if (!isThere)
                    {
                        Console.WriteLine($"Invalid operation! {newPiece} does not exist in the collection.");
                    }
                }
                commands = Console.ReadLine().Split('|');
            }
        }

        static void PrintMasterpieces(List<Masterpiece> masterpieces)
        {
            foreach (Masterpiece masterpiece in masterpieces)
            {
                Console.WriteLine($"{masterpiece.Piece} -> Composer: {masterpiece.Composer}, Key: {masterpiece.Key}");
            }
        }
    }
    public class Masterpiece
    {
        public Masterpiece(string piece, string composer, string key)
        {
            Piece = piece;
            Composer = composer;
            Key = key;
        }
        public string Piece { get; private set; }
        public string Composer { get; private set; }
        public string Key { get; set; }

    }
}
