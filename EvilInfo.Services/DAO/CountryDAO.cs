using EvilInfo.Services.Models;
using System;
using System.Linq;

namespace EvilInfo.Services.DAO
{
	public class CountryDAO
    {
        //public int AddCountry(Country country)
        //{
        //    SqlConnection dbConnection = new SqlConnection(this.connectionString);
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //        "INSERT INTO countries(name)" +
        //        "VALUES" +
        //        "(@name)", dbConnection);
        //        command.Parameters.AddWithValue("@name", country.Name);

        //        int num = command.ExecuteNonQuery();

        //        return num;
        //    }
        //}

        //public int DeleteCoutnryById(int id)
        //{
        //    SqlConnection dbConnection = new SqlConnection(this.connectionString);
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //        "DELETE " +
        //        "FROM " +
        //        "countries WHERE id = @id", dbConnection);
        //        command.Parameters.AddWithValue("@id", id);

        //        int num = command.ExecuteNonQuery();
        //        return num;
        //    }
        //}

        public Countries GetCoutry(string name)
        {
            return this.context.Countries.Where(c => c.Name.Equals(name)).FirstOrDefault();
        }

        //public int UpdateCountryById(Country country, int id)
        //{
        //    SqlConnection dbConnection = new SqlConnection(this.connectionString);
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //        "UPDATE " +
        //        "countries " +
        //        "SET name = @name " +
        //        "WHERE id = @id", dbConnection);
        //        command.Parameters.AddWithValue("@id", id);
        //        command.Parameters.AddWithValue("@name", country.Name);

        //        int num = command.ExecuteNonQuery();
        //        return num;
        //    }
        //}

        private EvilInfoDBContext context;
        public CountryDAO(EvilInfoDBContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }
    }
}
