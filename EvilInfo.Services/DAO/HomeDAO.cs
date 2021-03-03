using EvilInfo.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EvilInfo.Services.DAO
{
	public class HomeDAO
	{
		//public string GetUserRole(string username, string password)
		//{
		//    string userRole = string.Empty;
		//    SqlConnection dbConnection = new SqlConnection(this.connectionString);
		//    dbConnection.Open();

		//    using (dbConnection)
		//    {
		//        SqlCommand command = new SqlCommand(
		//        "SELECT [Roles].[Name]" +
		//        "FROM[EvilInfo].[dbo].[Users]" +
		//        "INNER JOIN[Logins] ON[Logins].[Id] = [Users].[Id]" +
		//        "INNER JOIN [Roles] ON [Roles].[Id] = [Users].[RoleId]" +
		//        "WHERE[Logins].[Username] = @username " +
		//        "AND" +
		//        "[Logins].[Password] = @password", dbConnection);

		//        command.Parameters.AddWithValue("@username", username);
		//        command.Parameters.AddWithValue("@password", password);

		//        SqlDataReader reader = command.ExecuteReader();

		//        using (reader)
		//        {
		//            while (reader.Read())
		//            {
		//                userRole = reader["Name"].ToString();
		//            }
		//        }

		//        return userRole;
		//    }
		//}


		//Да сложа ?.Users; са за да се покаже ползата от тестовете
		public Users LogIn(string username, string password)
		{
			var user = this.context.Logins
				.Include(l => l.Users)
				.ThenInclude(u => u.Role)
				.Where(u => u.Username.Equals(username) && u.Password.Equals(password))
				.FirstOrDefault().Users;

			return user;
		}

		public void RegisterUser(Logins loginInfo)
		{
			this.context.Logins.Add(loginInfo);
			this.context.SaveChanges();

		}

		//Как бих могъл да спестя писането на това като в базата вече преизползвам сторнатата
		public void RegisterVillain(VillainUsers user, Logins loginInfo)
		{
			this.context.Logins.Add(loginInfo);
			this.context.VillainUsers.Add(user);
			this.context.SaveChanges();
		}

		//public int GetUserId(string username, string password)
		//{
		//    SqlConnection dbConnection = new SqlConnection(this.connectionString);
		//    int userId = -1;
		//    dbConnection.Open();

		//    using (dbConnection)
		//    {
		//        SqlCommand command = new SqlCommand(
		//        "SELECT [Logins].[Id]" +
		//        " FROM [Logins]" +
		//        " WHERE [Logins].[Username] = @username" +
		//        " AND" +
		//        " [Logins].[Password] = @password", dbConnection);

		//        command.Parameters.AddWithValue("@username", username);
		//        command.Parameters.AddWithValue("@password", password);

		//        SqlDataReader reader = command.ExecuteReader();

		//        using (reader)
		//        {
		//            while (reader.Read())
		//            {
		//                userId = Convert.ToInt32(reader["Id"]);
		//            }
		//        }

		//        return userId;
		//    }
		//}

		//public bool IsUsernameFree(string username)
		//{
		//    SqlConnection dbConnection = new SqlConnection(this.connectionString);

		//    dbConnection.Open();

		//    using (dbConnection)
		//    {
		//        SqlCommand command = new SqlCommand(
		//        "SELECT [Logins].[Username]" +
		//        " FROM [Logins]" +
		//        " WHERE [Logins].[Username] = @username", dbConnection);

		//        command.Parameters.AddWithValue("@username", username);

		//        SqlDataReader reader = command.ExecuteReader();

		//        return reader.HasRows;
		//    }
		//}

		private EvilInfoDBContext context;
		public HomeDAO(EvilInfoDBContext context)
		{
			if (context == null) throw new ArgumentNullException("context");

			this.context = context;
		}
	}
}
