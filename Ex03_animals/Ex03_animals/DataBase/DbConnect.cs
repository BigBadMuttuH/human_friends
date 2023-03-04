using MySql.Data.MySqlClient;

namespace Ex03_animals.DataBase;

internal class DbConnect
{
    private MySqlConnection _connection;

    //Constructor
    public DbConnect()
    {
        Initialize();
    }

    //Initialize values
    private void Initialize()
    {
        var server = "localhost";
        var database = "human_friend";
        var uid = "admin";
        var password = "admin";
        var connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password}";

        _connection = new MySqlConnection(connectionString);
    }

    //open connection to database
    private bool OpenConnection()
    {
        try
        {
            _connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            switch (ex.Code)
            {
                case 0:
                    Console.WriteLine("Cannot connect to server.  Contact administrator\n");
                    break;

                case 1045:
                    Console.WriteLine("Invalid username/password, please try again\n");
                    break;
            }

            Console.WriteLine($"Error:{ex.Code}, {ex.Message}\n");

            return false;
        }
    }

    //Close connection
    private bool CloseConnection()
    {
        try
        {
            _connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    //Insert statement
    public void Insert(string query)
    {
        //open connection
        if (OpenConnection())
        {
            //create command and assign the query and connection from the constructor
            var cmd = new MySqlCommand(query, _connection);

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            CloseConnection();
        }
    }

    //Update statement
    public void Update(string query)
    {
        //Open connection
        if (OpenConnection())
        {
            //create mysql command
            var cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = query;
            //Assign the connection using Connection
            cmd.Connection = _connection;

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            CloseConnection();
        }
    }

    //Delete statement
    public void Delete(string query)
    {
        if (OpenConnection())
        {
            var cmd = new MySqlCommand(query, _connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
    }

    //Insert statement
    public void Insert()
    {
    }

    //Update statement
    public void Update()
    {
    }


    //Delete statement
    public void Delete()
    {
    }

    //Select statement
    public MySqlDataReader? Select(string query)
    {
        //Open connection
        if (OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            //Create a data reader and Execute the command
            MySqlDataReader? dataReader = cmd.ExecuteReader();

            return dataReader;
        }
        else
        {
            return null;
        }
    }

    //Count statement
    public int Count()
    {
        return 0;
    }

    //Backup
    public void Backup()
    {
    }

    //Restore
    public void Restore()
    {
    }
}