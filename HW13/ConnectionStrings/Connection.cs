
namespace HW13.ConnectionStrings;

public static class Connection
{
    public static string ConnectionString { get; set; }

     static Connection()
    {
        ConnectionString = @"Data Source=DESKTOP-URA992G\SQLEXPRESS; Initial Catalog=LibraryManager; Integrated Security=true ;TrustServerCertificate=True;";
    }
}
