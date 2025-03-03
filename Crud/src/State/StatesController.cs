﻿using Crud.src.State.dto;
using Microsoft.AspNetCore.Mvc;

namespace Crud.src.State
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly StateService _stateService;

        public StatesController(StateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            try
            {
                List<StateEntity> result = await _stateService.GetStates();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetState(Guid id)
        {
            try
            {
                StateEntity? result = await _stateService.GetState(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostState([FromBody] CreateStateDto stateDto)
        {
            try
            {
                StateEntity state = await _stateService.PostState(stateDto);
                return Ok(state);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(Guid id, [FromBody] CreateStateDto stateDto)
        {
            try
            {
                StateEntity state = await _stateService.PutState(id, stateDto);
                return Ok(state);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(Guid id)
        {
            try
            {
                await _stateService.DeleteState(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
