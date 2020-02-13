using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.PetClinics
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfPets = new List<Pet>();
            var listOfClinics = new List<Clinic>();

            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Pet pet;
                Clinic clinic;
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            switch (input[1])
                            {
                                case "Pet":
                                    listOfPets.Add(new Pet(input[2], int.Parse(input[3]), input[4]));
                                    break;
                                case "Clinic":
                                    listOfClinics.Add(new Clinic(input[2], int.Parse(input[3])));
                                    break;
                            }
                            break;

                        case "Add":
                            clinic = listOfClinics.FirstOrDefault(x => x.Name == input[2]);
                            pet = listOfPets.FirstOrDefault(x => x.Name == input[1]);
                            if (pet == null)
                            {
                                throw new ArgumentException("Invalid Operation!");
                            }
                            Console.WriteLine(clinic.Add(pet));
                            break;

                        case "Release":
                            clinic = listOfClinics.FirstOrDefault(x => x.Name == input[1]);
                            Console.WriteLine(clinic.Release());
                            break;

                        case "HasEmptyRooms":
                            clinic = listOfClinics.FirstOrDefault(x => x.Name == input[1]);
                            Console.WriteLine(clinic.HasEmptyRooms());
                            break;

                        case "Print":
                            switch (input.Length)
                            {
                                case 2:
                                    clinic = listOfClinics.FirstOrDefault(x => x.Name == input[1]);
                                    clinic.Print();
                                    break;

                                case 3:
                                    clinic = listOfClinics.FirstOrDefault(x => x.Name == input[1]);
                                    clinic.PrintSpecificRoom(int.Parse(input[2]));
                                    break;
                            }
                            break;

                        default:
                            throw new ArgumentException("Invalid Operation!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
