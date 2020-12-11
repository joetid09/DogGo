using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using DogGo.Models;

namespace DogGo.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IConfiguration _config;

        public OwnerRepository(IConfiguration config) 
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

        public List<Owner> GetAllOwners()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Email, [Name], Address, NeighborhoodId, Phone FROM Owner";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Owner> owners = new List<Owner>();
                    while (reader.Read())
                    {
                        Owner owner = new Owner
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            NeighborhoodId = reader.GetInt32(reader.GetOrdinal("NeighborhoodId")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone"))
                        };

                        owners.Add(owner);

                    }
                    reader.Close();
                    return owners;
                }
            }
        }
        public Owner GetOwnerById(int id)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Dog.Name as Pet, OwnerId, Owner.Name as Name, Owner.Id as Id, Breed, Email, Address, Phone FROM Owner
                                        RIGHT JOIN Dog
                                        ON Owner.Id = Dog.OwnerId
                                        WHERE Owner.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                            List<Dog> dogs = new List<Dog>();
                            while(reader.Read())
                        {
                            Dog dog = new Dog
                            {
                                Name = reader.GetString(reader.GetOrdinal("Dog.Name")),
                                Breed = reader.GetString(reader.GetOrdinal("Breed"))
                            };
                            dogs.Add(dog);
      
                        }

                        
                        
                        Owner owner = new Owner
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Owner.Id")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Pets = dogs
                        };
                        reader.Close();
                        return owner;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }

                }
            }
        }
    }
}
