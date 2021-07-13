using System.Collections.Generic;
using smoking_meat_api.Models;

namespace smoking_meat_api.Data
{
    public interface ISmokingRepo
    {
        bool SaveChanges();

        IEnumerable<Instruction> GetAllInstructions();

        Instruction GetInstructionById(int id);

        void CreateInstruction(Instruction inst);

        void UpdateInstruction(Instruction inst);

        void DeleteInstruction(Instruction inst);
    }
}