using EvilInfo.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvilInfo.Services.DAO
{
    public class VillainDAO
    {
        public EvilnessFactors GetEvilnessFactor(string name)
        {
            return this.context.EvilnessFactors.Where(e => e.Name.Equals(name)).FirstOrDefault();
        }

        public VillainUsers GetVillainById(int id)
        {
            return this.context.VillainUsers
                .Include(v => v.User)
                .ThenInclude(u => u.Town)
                .ThenInclude(u => u.Country)
                .Include(v => v.EvilnessFactor)
                .Where(v => v.UserId.Equals(id))
                .FirstOrDefault();
        }

        //public int UpdateVillainData(Villain villain)
        //{
        //    SqlConnection dbConnection = new SqlConnection(this.connectionString);
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand("UpdateVillainData", dbConnection);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;

        //        command.Parameters.AddWithValue("@userId", villain.Id);
        //        command.Parameters.AddWithValue("@firstName", villain.FirstName);
        //        command.Parameters.AddWithValue("@lastName", villain.LastName);
        //        command.Parameters.AddWithValue("@townName", villain.Town.Name);
        //        command.Parameters.AddWithValue("@countryName", villain.Town.Country.Name);
        //        command.Parameters.AddWithValue("@evilnessFactor", villain.EvlinessFactor);

        //        int num = command.ExecuteNonQuery();
        //        return num;
        //    }
        //}

        private EvilInfoDBContext context;
        public VillainDAO(EvilInfoDBContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }
    }
}
