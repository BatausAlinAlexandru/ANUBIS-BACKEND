﻿using Application.Commands.FilterGroup;
using Application.Queies.FilterGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilterGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilterGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFilterGroup([FromBody] AddFilterGroupCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFilterGroup([FromBody] UpdateFilterGroupCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFilterGroup([FromQuery] DeleteFilterGroupCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllFilterGroups()
        {
            var result = await _mediator.Send(new GetAllFilterGroupQuery());
            return result.Count > 0 ? Ok(result) : BadRequest(result);
        }
    }
}