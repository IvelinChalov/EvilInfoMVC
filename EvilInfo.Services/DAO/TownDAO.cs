using EvilInfo.Services.Models;
using System;
using System.Linq;

namespace EvilInfo.Services.DAO
{
	public class TownDAO
	{

		//public int AddTown(Town town)
		//{
		//    SqlConnection dbConnection = new SqlConnection(this.connectionString);
		//    dbConnection.Open();

		//    using (dbConnection)
		//    {
		//        SqlCommand command = new SqlCommand(
		//        "INSERT INTO towns(name, country_code)" +
		//        "VALUES" +
		//        "(@name, @countryCode)", dbConnection);
		//        command.Parameters.AddWithValue("@name", town.Name);
		//        command.Parameters.AddWithValue("@countryCode", town.Country.Id);

		//        int num = command.ExecuteNonQuery();
		//        return num;
		//    }
		//}

		//public int DeleteTownById(int id)
		//{
		//    SqlConnection dbConnection = new SqlConnection(this.connectionString);
		//    dbConnection.Open();

		//    using (dbConnection)
		//    {
		//        SqlCommand command = new SqlCommand(
		//        "DELETE " +
		//        "FROM " +
		//        "towns WHERE id = @id", dbConnection);
		//        command.Parameters.AddWithValue("@id", id);

		//        int num = command.ExecuteNonQuery();
		//        return num;
		//    }
		//}

		//public Town GetTownById(int id)
		//{
		//    Town town = null;
		//    SqlConnection dbConnection = new SqlConnection(this.connectionString);
		//    dbConnection.Open();

		//    using (dbConnection)
		//    {
		//        SqlCommand command = new SqlCommand(
		//        "SELECT towns.id, " +
		//        "towns.name, " +
		//        "countries.id AS countryId, " +
		//        "countries.name AS coutryName " +
		//        "FROM towns INNER JOIN countries ON " +
		//        "countries.id = towns.country_code " +
		//        "WHERE towns.id = @id", dbConnection);
		//        command.Parameters.AddWithValue("@id", id);

		//        SqlDataReader reader = command.ExecuteReader();

		//        using (reader)
		//        {
		//            while (reader.Read())
		//            {
		//                town = new Town(Convert.ToInt32(reader["id"]), reader["name"].ToString(), new Country(Convert.ToInt32(reader["countryId"]), reader["coutryName"].ToString()));
		//            }
		//        }

		//        return town;
		//    }
		//}

		public Towns GetTown(string name)
		{
			return this.context.Towns.Where(t => t.Name.Equals(name)).FirstOrDefault();
		}

		//public int UpdateTownById(Town town, int id)
		//{
		//    SqlConnection dbConnection = new SqlConnection(this.connectionString);
		//    dbConnection.Open();

		//    using (dbConnection)
		//    {
		//        SqlCommand command = new SqlCommand(
		//        "UPDATE " +
		//        "towns " +
		//        "SET name = @name " +
		//        "WHERE id = @id", dbConnection);
		//        command.Parameters.AddWithValue("@id", id);
		//        command.Parameters.AddWithValue("@name", town.Name);

		//        int num = command.ExecuteNonQuery();
		//        return num;
		//    }
		//}

		private EvilInfoDBContext context;
		public TownDAO(EvilInfoDBContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			this.context = context;
		}
	}
}
