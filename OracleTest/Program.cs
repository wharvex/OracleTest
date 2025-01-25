using Oracle.ManagedDataAccess.Client;

namespace OracleTest;

internal class Program
{
    public static string user = "DEMODOTNET";
    public static string pwd = "PASSWORD";
    public static string db = "localhost/XEPDB1";

    static void Main(string[] args)
    {
        string conStringUser = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";

        using OracleConnection con = new OracleConnection(conStringUser);
        using OracleCommand cmd = con.CreateCommand();
        try
        {
            con.Open();
            Console.WriteLine("Successfully connected to Oracle Database as " + user);
            Console.WriteLine();

            //Retrieve sample data
            cmd.CommandText = "SELECT description, done FROM todoitem";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetBoolean(1))
                    Console.WriteLine(reader.GetString(0) + " is done.");
                else
                    Console.WriteLine(reader.GetString(0) + " is NOT done.");
            }

            reader.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
