using System.Data.Common;
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
            cmd.CommandText = "SELECT * FROM algorithm";
            var reader = cmd.ExecuteReader();
            Dictionary<string, string> fields = new Dictionary<string, string>();
            while (reader.Read())
            {
                var x = reader.FieldCount;
                for (int index = 0; index < x; index++)
                {
                    fields[reader.GetName(index)] = reader.GetString(index);
                }
            }

            Console.WriteLine("done");
            foreach (KeyValuePair<string, string> kvp in fields)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            reader.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
