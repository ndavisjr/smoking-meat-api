using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using smoking_meat_api.Models;

namespace smoking_meat_api.Data
{
    public class SqlSmokingRepo : ISmokingRepo
    {
        private readonly SmokingContext _context;

        public SqlSmokingRepo(SmokingContext context)
        {
            _context = context;
        }

        public void CreateInstruction(Instruction inst)
        {
            if (inst == null)
            {
                throw new ArgumentNullException(nameof(inst));
            }

            _context.Instructions.Add(inst);
        }

        public void DeleteInstruction(Instruction inst)
        {
            if (inst == null)
            {
                throw new ArgumentNullException(nameof(inst));
            }

            _context.Instructions.Remove(inst);
        }

        public IEnumerable<Instruction> GetAllInstructions()
        {
            return _context.Instructions.ToList();
        }

        public Instruction GetInstructionById(int id)
        {
            return _context.Instructions.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateInstruction(Instruction instruction)
        {
            // nothing
        }
    }
}