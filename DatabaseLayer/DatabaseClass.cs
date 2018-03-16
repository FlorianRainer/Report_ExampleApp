namespace DatabaseLayer
{
	using Npgsql;

    public class DatabaseClass
    {
	    public static string GetSomethingFromDatabase()
	    {
		    using (var connection = new NpgsqlConnection())
		    {
			    connection.ConnectionString = ""; //do something (just fake in this case)
			    return "String From DB"; //return something fake, normaly return from select
		    }
	    }
    }
}
