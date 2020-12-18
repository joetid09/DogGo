﻿using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly IConfiguration _config;

        public WalksRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public void AddWalk(Walks walk)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Walks (Date, WalkerId, DogId, WalkStatusId, WalkerId) 
                                        OUTPUT INSERTED.ID
                                        Values (@date, @dogid, @ownerid, @walkstatusid, @walkerid );
                                        ";

                    cmd.Parameters.AddWithValue("date", walk.Date);
                    cmd.Parameters.AddWithValue("@dogid", walk.DogId);
                    cmd.Parameters.AddWithValue("@ownerid", walk.OwnerId);
                    cmd.Parameters.AddWithValue("walkerid", walk.WalkerId);
                    cmd.Parameters.AddWithValue("@walkstatusid", 1);

                    int id = (int)cmd.ExecuteScalar();

                    walk.Id = id;

                }
            }
        }

        public List<Walks> GetWalksByWalker(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Walks.Id, Date, Duration, WalkerId, DogId, Owner.Id as OwnerId From Walks
                                        LEFT JOIN Dog
                                        ON Dog.Id = Walks.DogId
                                        LEFT JOIN Owner
                                        ON Owner.Id = Dog.OwnerId
                                        WHERE WalkerId = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walks> walks = new List<Walks>();

                    while (reader.Read())
                    {
                        Walks walk = new Walks()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                            OwnerId = reader.GetString(reader.GetOrdinal("OwnerId")) 
                        };
                        walks.Add(walk);
                    }
                    reader.Close();
                    return walks;
                }


            }
        }
    }
}
