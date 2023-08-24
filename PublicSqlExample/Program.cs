// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

var connStr = "server=localhost\\sqlexpress;" + //connection string
    "database=SalesDb;" +
    "trusted_connection=true;" +
    "trustServerCertificate=true;";

var conn = new SqlConnection(connStr);  //connection Instance

conn.Open();  //Must open immediatly

//testing that the connection is open
if (conn.State != System.Data.ConnectionState.Open)
{
    throw new Exception("Connection didn't open");
}

Console.WriteLine("Success!");

//Put our Sql code here

var sql = "SELECT * from Customers where id between 10 and 19;";
var cmd = new SqlCommand(sql, conn);
var reader = cmd.ExecuteReader();
while (reader.Read())
{
    var id = Convert.ToInt32(reader["Id"]);
    var name = Convert.ToString(reader["Name"]);
    Console.WriteLine($"Id={id}, Name={name}");
}




//close the connection when finished so someone else can use it
conn.Close();
