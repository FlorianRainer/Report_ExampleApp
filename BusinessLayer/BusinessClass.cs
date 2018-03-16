namespace BusinessLayer
{
	using DatabaseLayer;

    public class BusinessClass
    {
	    public static string GetSomething()
	    {
		    return DatabaseClass.GetSomethingFromDatabase();
	    }
    }
}
