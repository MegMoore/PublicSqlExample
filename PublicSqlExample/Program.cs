// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using PublicSqlExample;

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

var cust10 = GetByPk(10);
conn.Close();

Customer? GetByPk(int id)
{
    var sql = "SELECT * from Customers where id = @Id;";
    var cmd = new SqlCommand(sql, conn); //This is what causes the statement to be executed.
    cmd.Parameters.AddWithValue("@Id", id);
    var reader = cmd.ExecuteReader();// only for a "select" command.
    if (!reader.HasRows)
    {
        return null;
    }

    reader.Read():
    var cust = new Customer();
    var Id = Convert.ToInt32(reader["Id"]);
    var Name = Convert.ToString(reader["Name"]);
    var City = Convert.ToString(reader["City"]);
    var State = Convert.ToString(reader["State"]);
    var Sales = Convert.ToDecimal(reader["Sales"]);
    var Active = Convert.ToBoolean(reader["Active"]);
        
    reader.Close();
    return cust;   
    
}


// var totalSales = cmd.ExecuteScalar(); -- can only use when returning 1 row in 1 column. Agragate
/*
  while (reader.Read())

{
    var id = Convert.ToInt32(reader["Id"]);
    var name = Convert.ToString(reader["Name"]);
    Console.WriteLine($"Id={id}, Name={name}"); //Everything gets returned as an object.
}
reader.Close(); // must close one data reader to open another



//close the connection when finished so someone else can use it
conn.Close();
{
    return;
}
reader.Read();
var id = Convert.ToInt32(reader["Id"]);
var name = Convert.ToString(reader["Name"]);
decimal? sales = reader["Sales"].Equals(DBNull.Value) ? null : Convert.ToDecimal(reader["Sales"]); //DbNull.Value - must use to return nulls
Console.WriteLine($"Id={id}, Name={name}"); //Everything gets returned as an object
*/