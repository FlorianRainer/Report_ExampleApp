namespace ApplicationLayer
{
	using System;

    class Program
    {
        static void Main(string[] args)
        {
	        Console.WriteLine("Hello World!");
	        Console.WriteLine("Result: " + BusinessLayer.BusinessClass.GetSomething()); //this line is OK
	        //Console.WriteLine("Result: " + DatabaseLayer.DatabaseClass.GetSomethingFromDatabase()); //this line should not compile
	        Console.WriteLine("Press any key to close");
	        Console.ReadKey();
        }
    }
}
