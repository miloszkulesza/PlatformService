using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/platforms/{platformId}/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepository commandRepository,
                                  IMapper mapper)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatform: {platformId}");

            if (!_commandRepository.PlatformExists(platformId))
                return NotFound();

            var commands = _commandRepository.GetCommandsForPlatform(platformId);

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
        {
            Console.Write($"--> Hit GetCommandForPlatform: {platformId} / {commandId}");

            if (!_commandRepository.PlatformExists(platformId))
                return NotFound();

            var command = _commandRepository.GetCommand(platformId, commandId);

            if (command == null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandDto)
        {
            Console.Write($"--> Hit CreateCommandForPlatform: {platformId}");

            if (!_commandRepository.PlatformExists(platformId))
                return NotFound();

            var command = _mapper.Map<Command>(commandDto);
            _commandRepository.CreateCommand(platformId, command);
            _commandRepository.SaveChanges();

            return CreatedAtRoute(nameof(GetCommandForPlatform), _mapper.Map<CommandReadDto>(command));
        }
    }
}
