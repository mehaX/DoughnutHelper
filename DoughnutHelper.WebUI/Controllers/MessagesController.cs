using System.Collections.Generic;
using System.Threading.Tasks;
using DoughnutHelper.Application.Messages.Commands;
using DoughnutHelper.Application.Messages.Models;
using DoughnutHelper.Application.Messages.Queries;
using DoughnutHelper.Domain.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoughnutHelper.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<MessageModel>> GetInitialMessage([FromQuery]int? questionMessageId, [FromQuery]Answers? answer)
        {
            var query = new GetNextMessageQuery()
            {
                QuestionMessageId = questionMessageId,
                Answer = answer
            };
            
            return Ok(await _mediator.Send(query));
        }
    }
}