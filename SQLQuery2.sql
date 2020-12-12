SELECT Dog.Name as Pet, OwnerId, Owner.Name as Name, Owner.Id as Id, Breed, Email, Address, Phone FROM Owner
                                        RIGHT JOIN Dog
                                        ON Owner.Id = Dog.OwnerId
                                        WHERE Owner.Id = 1