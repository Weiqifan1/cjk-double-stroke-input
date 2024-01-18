// See https://aka.ms/new-console-template for more information

using System;
using double_stroke.projectFolder;

//using double_stroke.projectFolder;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World Chr");
        CreateDeckFileController myClassInstance = new CreateDeckFileController();
        myClassInstance.myFunction();
        Console.WriteLine("end");
    }
}
