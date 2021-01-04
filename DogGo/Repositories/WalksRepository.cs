using DogGo.Models;
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
                    cmd.CommandText = @"INSERT INTO Walks (Date, Duration, DogId, WalkerId, WalkStatusId) 
                                        OUTPUT INSERTED.ID
                                        Values (@date, @duration, @dogid, @walkerid, @walkstatusid );
                                        ";

                    cmd.Parameters.AddWithValue("@date", walk.Date);
                    cmd.Parameters.AddWithValue("@duration", walk.Duration * 60);
                    cmd.Parameters.AddWithValue("@dogid", walk.DogId);
                    cmd.Parameters.AddWithValue("@walkerid", walk.WalkerId);
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
                    cmd.CommandText = @"SELECT Walks.Id, Date, Duration, WalkerId, DogId, Owner.Id as OwnerId, WalkStatusId
                                        From Walks
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
                            WalkStatusId = reader.GetInt32(reader.GetOrdinal("WalkStatusId"))
                        };
                        walks.Add(walk);
                    }
                    reader.Close();
                    return walks;
                }


            }
        }
        public Walks GetWalkById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *
                                        From Walks
                                        WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Walks walk = new Walks()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkStatusId = reader.GetInt32(reader.GetOrdinal("WalkStatusId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId"))

                        };
                        reader.Close();
                        return walk;
                    }
                    reader.Close();
                    return null;
                }
            }
        }
        public List<Walks> GetWalkByDogId(int dogId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT *
                                        From Walks
                                        WHERE DogId = @dogId";

                    cmd.Parameters.AddWithValue("@dogId", dogId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Walks walk = new Walks()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkStatusId = reader.GetInt32(reader.GetOrdinal("WalkStatusId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId"))

                        };
                        reader.Close();
                        return walk;
                    }
                    reader.Close();
                    return null;
                }
            }
        }

        public void UpdateWalk(Walks walk)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                       UPDATE Walks
                                        SET
                                        WalkStatusId = @statusId,
                                        Duration = @duration,
                                        WalkerId = @walker,
                                        DogId = @dog
                                        WHERE Id = @id
                                        ";

                    cmd.Parameters.AddWithValue("@statusId", walk.WalkStatusId);
                    cmd.Parameters.AddWithValue("@duration", walk.Duration);
                    cmd.Parameters.AddWithValue("@walker", walk.WalkerId);
                    cmd.Parameters.AddWithValue("@dog", walk.DogId);
                    cmd.Parameters.AddWithValue("@id", walk.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
