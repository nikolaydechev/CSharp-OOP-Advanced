using System;
using System.Linq;

namespace _08.PetClinics
{
    public class Clinic
    {
        private int roomsCount;

        public string Name { get; }

        public Pet[] RoomsOfPets { get; set; }

        public Clinic(string name, int roomsCount)
        {
            this.Name = name;
            this.RoomsCount = roomsCount;
            this.RoomsOfPets = new Pet[roomsCount];
        }

        public int RoomsCount
        {
            get
            {
                return this.roomsCount;
            }
            set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                this.roomsCount = value;
            }
        }

        public bool Add(Pet pet)
        {
            int centerRoom = (this.RoomsOfPets.Length - 1) / 2;
            int leftRoom = centerRoom - 1;
            int rightRoom = centerRoom + 1;
            bool foundARoom = false;

            if (this.RoomsOfPets[centerRoom] == null)
            {
                this.RoomsOfPets[centerRoom] = pet;
                return true;
            }
            else if (this.RoomsOfPets[centerRoom] != null && this.RoomsOfPets.Length >= 3)
            {
                while (leftRoom > -1)
                {
                    if (this.RoomsOfPets[leftRoom] == null)
                    {
                        this.RoomsOfPets[leftRoom] = pet;
                        foundARoom = true;
                        break;
                    }
                    if (this.RoomsOfPets[rightRoom] == null)
                    {
                        this.RoomsOfPets[rightRoom] = pet;
                        foundARoom = true;
                        break;
                    }
                    leftRoom--;
                    rightRoom++;
                }
            }

            return foundARoom;
        }

        public bool Release()
        {
            int centerRoom = (this.RoomsOfPets.Length - 1) / 2;
            bool isReleased = false;

            for (int i = centerRoom; i < this.RoomsOfPets.Length; i++)
            {
                if (this.RoomsOfPets[i] != null)
                {
                    this.RoomsOfPets[i] = null;
                    isReleased = true;
                    break;
                }
            }
            if (!isReleased)
            {
                for (int i = 0; i < centerRoom; i++)
                {
                    if (this.RoomsOfPets[i] != null)
                    {
                        this.RoomsOfPets[i] = null;
                        isReleased = true;
                        break;
                    }
                }
            }
            
            return isReleased;
        }

        public bool HasEmptyRooms()
        {
            return this.RoomsOfPets.Any(x => x == null);
        }

        public void Print()
        {
            foreach (var roomOfPet in this.RoomsOfPets)
            {
                Console.WriteLine(roomOfPet == null 
                    ? $"Room empty" 
                    : $"{roomOfPet}");
            }
        }

        public void PrintSpecificRoom(int room)
        {
            Console.WriteLine(this.RoomsOfPets[room - 1] != null 
                ? $"{this.RoomsOfPets[room - 1]}" 
                : "Room empty");
        }
    }
}
