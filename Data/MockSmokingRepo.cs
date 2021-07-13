// fake repository used for testing functionality before connecting to a database
using System.Collections.Generic;
using smoking_meat_api.Models;

namespace smoking_meat_api.Data
{
    public class MockSmokingRepo : ISmokingRepo
    {
        public void CreateInstruction(Instruction inst)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteInstruction(Instruction inst)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Instruction> GetAllInstructions()
        {
            var instructs = new List<Instruction>
            {
                new Instruction
                {
                    Id = 0,
                    Meat = "Brisket",
                    SmokingTemp = 225,
                    CookTime = "12-20 hrs",
                    CookedTemperature = 195,
                    Category = "beef"
                },
                new Instruction
                {
                    Id = 1,
                    Meat = "Roast",
                    SmokingTemp = 225,
                    CookTime = "8-10hrs",
                    CookedTemperature = 200,
                    Category = "beef"
                },
                new Instruction
                {
                    Id = 2,
                    Meat = "Baby Back Ribs",
                    SmokingTemp = 225,
                    CookTime = "5 hrs",
                    CookedTemperature = 195,
                    Category = "pork"
                },
            };

            return instructs;
        }

        public Instruction GetInstructionById(int id)
        {
            return new Instruction
            {
                Id = 0,
                Meat = "Brisket",
                SmokingTemp = 225,
                CookTime = "12-20 hrs",
                CookedTemperature = 195,
                Category = "beef"
            };

        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateInstruction(Instruction inst)
        {
            throw new System.NotImplementedException();
        }
    }
}