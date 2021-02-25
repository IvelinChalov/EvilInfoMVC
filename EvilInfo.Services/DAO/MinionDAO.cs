using EvilInfo.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvilInfo.Services.DAO
{
    public class MinionDAO
    {
        //public int AddMinion(User minion)
        //{
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //        "INSERT INTO minions(name, age, town_id)" +
        //        "VALUES" +
        //        "(@name, @age, @townId)", dbConnection);
        //        command.Parameters.AddWithValue("@name", minion.FirstName);
        //        command.Parameters.AddWithValue("@age", minion.LastName);
        //        command.Parameters.AddWithValue("@townId", minion.Town.Id);

        //        int num = command.ExecuteNonQuery();
        //        return num;
        //    }
        //}

        //public int DeleteMinionById(int id)
        //{
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //        "DELETE " +
        //        "FROM minions_villains " +
        //        "WHERE minion_id = @id", dbConnection);
        //        command.Parameters.AddWithValue("@id", id);

        //        command.ExecuteNonQuery();

        //        command = new SqlCommand(
        //       "DELETE " +
        //       "FROM minions " +
        //       "WHERE id = @id", dbConnection);
        //        command.Parameters.AddWithValue("@id", id);

        //        int num = command.ExecuteNonQuery();
        //        return num;
        //    }
        //}

        //public List<User> GetAllMinions()
        //{
        //    List<User> minions = new List<User>();

        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //        "SELECT " +
        //        "minions.id AS minionId, " +
        //        "minions.name AS minionName, " +
        //        "minions.age AS minionAge, " +
        //        "towns.id AS townId, " +
        //        "towns.name AS townName, " +
        //        "countries.id AS countryId, " +
        //        "countries.name AS coutryName " +
        //        "FROM towns " +
        //        "INNER JOIN countries ON " +
        //        "countries.id = towns.country_code " +
        //        "INNER JOIN minions ON minions.town_id = towns.id", dbConnection);

        //        SqlDataReader reader = command.ExecuteReader();

        //        using (reader)
        //        {
        //            while (reader.Read())
        //            {
        //                Town town = new Town(Convert.ToInt32(reader["townId"]), reader["townName"].ToString(), new Country(Convert.ToInt32(reader["countryId"]), reader["coutryName"].ToString()));
        //                User m = new User(Convert.ToInt32(reader["minionId"]), reader["minionName"].ToString(),"dfd", town, "df");
        //                minions.Add(m);
        //            }
        //        }

        //        return minions;
        //    }
        //}

        //public List<Villain> GetAllVillainsByMinionId(int minionId)
        //{
        //    throw new NotImplementedException();
        //}

        public Users GetMinionById(int id)
        {
            return this.context.Users
                 .Include(u => u.Town)
                 .Include(u => u.Country)
                 .Where(u => u.Id.Equals(id))
                 .FirstOrDefault();
        }

        //public int UpdateMinionPersonalData(User minion)
        //{
        //    SqlConnection dbConnection = new SqlConnection(this.connectionString);
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand("UpdateUserData", dbConnection);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;

        //        command.Parameters.AddWithValue("@userId", minion.Id);
        //        command.Parameters.AddWithValue("@firstName", minion.FirstName);
        //        command.Parameters.AddWithValue("@lastName", minion.LastName);
        //        command.Parameters.AddWithValue("@townName", minion.Town.Name);
        //        command.Parameters.AddWithValue("@countryName", minion.Town.Country.Name);

        //        int num = command.ExecuteNonQuery();
        //        return num;
        //    }
        //}

        private EvilInfoDBContext context;
        public MinionDAO(EvilInfoDBContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }
    }
}
