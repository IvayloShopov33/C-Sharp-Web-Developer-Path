﻿using System;

namespace Student_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            
            Console.WriteLine($"Name: {studentName}, Age: {age}, Grade: {grade:f2}");
        }
    }
}
