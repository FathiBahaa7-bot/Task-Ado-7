
using System.Data;
using Microsoft.Data.SqlClient;
namespace Task_Ado
{
   internal class Program
   { 
      static void Main(string[] args)
      {
                
       string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ado;Integrated Security=True;TrustServerCertificate=True";

               
         using (SqlConnection connection = new SqlConnection(connString))
         {
                  
                    SqlDataAdapter adapter = new SqlDataAdapter(
                        "SELECT * FROM Employes",
                        connection
                    );

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataTable table = new DataTable();

                    // Load data from database
                    adapter.Fill(table);

                    Console.WriteLine("--- Employees Data ---");

                    foreach (DataRow row in table.Rows)
                    {
                        Console.WriteLine(
                            $"ID = {row["ID"]} | Fname = {row["fname"]} | Lname = {row["lname"]} | Age = {row["age"]}"
                        );
                    }

                    Console.WriteLine("----------------------");

                    // Add new employee
                    DataRow newEmployee = table.NewRow();

                    newEmployee["ID"] = 7;
                    newEmployee["fname"] = "Farhi";
                    newEmployee["lname"] = "Bahaa";
                    newEmployee["age"] = 21;

                    table.Rows.Add(newEmployee);

                    // Display data after adding employee
                    Console.WriteLine("--- Data After Adding Employee ---");

                    foreach (DataRow row in table.Rows)
                    {
                        Console.WriteLine(
                            $"ID = {row["ID"]} | Fname = {row["fname"]} | Lname = {row["lname"]} | Age = {row["age"]}"
                        );
                    }

                    // Save changes to database
                    adapter.Update(table);

                    Console.WriteLine("\nChanges saved successfully!");
         }
      }
   }  
    
}
