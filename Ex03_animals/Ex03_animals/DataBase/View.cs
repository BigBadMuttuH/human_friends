using MySql.Data.MySqlClient;

namespace Ex03_animals.DataBase;

public class View
{
    public static void DataView()
    {
        var query = "SELECT * FROM animals";
        var db = new DbConnect();
        MySqlDataReader r = db.Select(query);
    
        while (r.Read())
            Console.WriteLine(
                $"{r.GetString(0)}\t | \t{r.GetString(1)}\t | \t{r.GetDateTime(2)}\t | \t{r.GetByte(3)}\t | \t{r.GetString(4)}");

        r.Close();
    }
}