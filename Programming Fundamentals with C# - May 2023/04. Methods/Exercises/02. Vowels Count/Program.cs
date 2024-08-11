using System;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(VowelsInString(str)); 
        }
        static int VowelsInString(string str)
        {
            char[] ch = str.ToCharArray();
            int vowelsCount = 0;
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i]=='a' || ch[i]=='e' || ch[i]=='i' || ch[i]=='o' || ch[i]=='u'
                    || ch[i] == 'A' || ch[i] == 'E' || ch[i] == 'I' || ch[i] == 'O' || ch[i] == 'U')
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }
    }
}
