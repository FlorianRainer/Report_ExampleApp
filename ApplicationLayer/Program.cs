using System.Runtime.Loader;

namespace ApplicationLayer
{
	using System;

    class Program
    {
        static void Main(string[] args)
        {
	        //this line is need because PrivateAssets from subprojects are not in deps.json
	        //it is needed to add <CopyLocalLockFileAssemblies> in project to get all dlls and load it via FrameworkExtensions
	        AssemblyLoadContext.Default.Resolving += Helper.OnAssemblyResolve;
	      
	        Console.WriteLine("Hello World!");
	        Console.WriteLine("Result: " + BusinessLayer.BusinessClass.GetSomething()); //this line is OK
	        //Console.WriteLine("Result: " + DatabaseLayer.DatabaseClass.GetSomethingFromDatabase()); //this line should not compile
	        Console.WriteLine("Press any key to close");
	        Console.ReadKey();
        }
    }
}
