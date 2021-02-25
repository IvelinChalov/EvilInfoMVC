using EvilInfo.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvilInfo.Services.DAO
{
	public class JobDAO
    {

        public int CreateJobApplication(string description, int userId)
        {
            Joboffers joboffer = new Joboffers();
            joboffer.Name = description;
            joboffer.UserId = userId;
            joboffer.JobOfferStatus = true;

            this.context.Joboffers.Add(joboffer);
            return this.context.SaveChanges();
        }

        public int DeleteJobApplication()
        {
            throw new NotImplementedException();
        }

        //public List<JobApplication> GetAllJobApplications()
        //{
        //    List<JobApplication> jobs = new List<JobApplication>();

        //    SqlConnection dbConnection = new SqlConnection(this.connectionString);
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //        "SELECT " +
        //        "[JobOffers].[Id] AS 'JobId', " +
        //        "CONCAT([Users].[FirstName], ' ', [Users].[LastName]) AS 'Username', " +
        //        "[JobOffers].[Name] AS 'Description', " +
        //        "[Users].[Id] AS 'UserId' " +
        //        "FROM[JobOffers] " +
        //        "INNER JOIN[Users] ON [Users].[Id] = [JobOffers].[UserId] " +
        //        "WHERE [JobOffers].[JobOfferStatus] = 1", dbConnection);

        //        SqlDataReader reader = command.ExecuteReader();

        //        using (reader)
        //        {
        //            while (reader.Read())
        //            {
        //                JobApplication ja = new JobApplication(Convert.ToInt32(reader["JobId"]), reader["Description"].ToString(), Convert.ToInt32(reader["UserId"]), reader["Username"].ToString());
        //                jobs.Add(ja);
        //            }
        //        }

        //        return jobs;
        //    }
        //}

        public List<Joboffers> GetAllJobApplicationsInfoByUserId(int userId)
        {
            var jobapplications = this.context.Joboffers
                        .Include(j => j.User)
                        .Include(j => j.Jobapplications)
                        .ThenInclude(ja => ja.User)
                        .Where(j => j.UserId.Equals(userId))
                        .ToList();
            // .Select(j => new { jobId = j.Id, jobapp = j.Jobapplications });

            return jobapplications;

            //List<JobApplicationInfo> jobs = new List<JobApplicationInfo>();

            //SqlConnection dbConnection = new SqlConnection(this.connectionString);
            //dbConnection.Open();

            //using (dbConnection)
            //{
            //    SqlCommand command = new SqlCommand(
            //    "SELECT " +
            //    "[JobApplications].[UserId] AS 'ApplicantId' " +
            //    ", CONCAT([Users].[FirstName], ' ', [Users].[LastName]) AS 'Username' " +
            //    ",[JobOfferId] " +
            //    ",[JobOffers].[Name] AS 'JobName' " +
            //    ",[JobOffers].[UserId] AS 'ЕmployerId' " +
            //    "FROM[JobApplications] " +
            //    "INNER JOIN[JobOffers] ON[JobOffers].[Id] = [JobApplications].[JobOfferId] " +
            //    "INNER JOIN[Users] ON[Users].[Id] = [JobApplications].UserId " +
            //    "WHERE[JobOffers].[UserId] = @employerId", dbConnection);

            //    command.Parameters.AddWithValue("@employerId", userId);
            //    SqlDataReader reader = command.ExecuteReader();

            //    using (reader)
            //    {
            //        while (reader.Read())
            //        {
            //            JobApplicationInfo jai = new JobApplicationInfo(Convert.ToInt32(reader["ApplicantId"]), reader["Username"].ToString(), Convert.ToInt32(reader["JobOfferId"]), reader["JobName"].ToString(), Convert.ToInt32(reader["ЕmployerId"]));
            //            jobs.Add(jai);
            //        }
            //    }

            //    return jobs;
            //}
        }

        public int HireApplicant(int applicantId, int employerId, int jobId)
        {
            VillainuserUsers villainuserUsers = new VillainuserUsers();
            villainuserUsers.MinionId = applicantId;
            villainuserUsers.VillainId = employerId;

            this.context.VillainuserUsers.Add(villainuserUsers);
            return this.context.SaveChanges();            
        }

        //public int JobApplication(int jobId, int userId)
        //{
        //    SqlConnection dbConnection = new SqlConnection(this.connectionString);
        //    dbConnection.Open();

        //    using (dbConnection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //        "INSERT INTO [JobApplications] " +
        //        "VALUES(@userId, @jobId)", dbConnection);

        //        command.Parameters.AddWithValue("@jobId", jobId);
        //        command.Parameters.AddWithValue("@userId", userId);

        //        int result = command.ExecuteNonQuery();

        //        return result;
        //    }
        //}

        private EvilInfoDBContext context;
        public JobDAO(EvilInfoDBContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }
    }
}
