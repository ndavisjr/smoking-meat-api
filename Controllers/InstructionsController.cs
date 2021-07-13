using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using smoking_meat_api.Data;
using AutoMapper;
using smoking_meat_api.DTOs;
using smoking_meat_api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace smoking_meat_api.Controllers
{

    // no view specifically with the API so inherit from ControllerBase rather than Controller
    // Route: api/instructions
    [ApiController]
    [Route("api/instructions")]
    public class InstructionsController : ControllerBase
    {
        private readonly ISmokingRepo _repository;
        private readonly IMapper _mapper;

        public InstructionsController(ISmokingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/instructions
        [HttpGet]
        public ActionResult<IEnumerable<InstructionReadDto>> GetAllInstructions()
        {
            var instructionList = _repository.GetAllInstructions();
            return Ok(_mapper.Map<IEnumerable<InstructionReadDto>>(instructionList));
        }

        //GET api/instructions/{id}
        [HttpGet("{id}", Name = "GetInstructionById")]
        public ActionResult<InstructionReadDto> GetInstructionById(int id)
        {
            var instruction = _repository.GetInstructionById(id);
            if (instruction != null)
            {
                return Ok(_mapper.Map<InstructionReadDto>(instruction));
            }
            return NotFound();

        }

        //POST api/instructions
        [HttpPost]
        public ActionResult<InstructionReadDto> CreateInstruction(InstructionCreateDto instructionCreateDto)
        {
            // Use automapper (see Profiles) turn a InstructionCreateDto -> Instruction
            var instructionModel = _mapper.Map<Instruction>(instructionCreateDto);

            _repository.CreateInstruction(instructionModel);
            _repository.SaveChanges();

            // setup a InstructionReadDto to return
            var instructionReadDto = _mapper.Map<InstructionReadDto>(instructionModel);

            return CreatedAtRoute(nameof(GetInstructionById), new { Id = instructionReadDto.Id }, instructionReadDto);
        }

        //PUT api/instructions/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateInstruction(int id, InstructionUpdateDto instructionUpdateDto)
        {
            // verify resource exists
            var instructionModelFromRepo = _repository.GetInstructionById(id);
            if (instructionModelFromRepo == null)
            {
                return NotFound();
            }

            // map, call the update, save changes 
            _mapper.Map(instructionUpdateDto, instructionModelFromRepo);

            _repository.UpdateInstruction(instructionModelFromRepo);
            _repository.SaveChanges();

            // return 204 no content
            return NoContent();
        }

        //PATCH api/instructions/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchInstruction(int id, JsonPatchDocument<InstructionUpdateDto> patchDoc)
        {
            // verify resource exists
            var instructionModelFromRepo = _repository.GetInstructionById(id);
            if (instructionModelFromRepo == null)
            {
                return NotFound();
            }

            // grab existing contents from repository 
            var instructionToPatch = _mapper.Map<InstructionUpdateDto>(instructionModelFromRepo);

            // apply patch and verify it didn't fail validation
            patchDoc.ApplyTo(instructionToPatch, ModelState);
            if (!TryValidateModel(instructionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            // map, call the update, save changes 
            _mapper.Map(instructionToPatch, instructionModelFromRepo);

            _repository.UpdateInstruction(instructionModelFromRepo);
            _repository.SaveChanges();

            // return 204 no content
            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteInstruction(int id)
        {
            // verify resource exists
            var instructionModelFromRepo = _repository.GetInstructionById(id);
            if (instructionModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteInstruction(instructionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}