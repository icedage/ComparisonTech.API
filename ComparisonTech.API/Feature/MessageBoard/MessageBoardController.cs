using ComparisonTech.API.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComparisonTech.API.Feature.MessageBoard
{
    public class MessageBoardController : ResultController
    {
        private readonly CreateMessageBoardHandler _createMessageBoardHandler;
        private readonly GetMessageBoardHandler _getMessageBoardHandler;

        public MessageBoardController(CreateMessageBoardHandler createMessageBoardHandler, GetMessageBoardHandler getMessageBoardHandler)
        {
            _createMessageBoardHandler = createMessageBoardHandler;
            _getMessageBoardHandler = getMessageBoardHandler;
        }

        [HttpPost("messageBoard")]
        [ProducesResponseType(typeof(StatusCodeResult), 201)]
        [ProducesResponseType(typeof(StatusCodeResult), 404)]
        [ProducesResponseType(typeof(StatusCodeResult), 440)]
        public async Task<ActionResult<int>> Post([FromHeader(Name = "X-Anonymous-UserTracking")][Required] string headerValue, MessageBoardRequest request)
        {
            request.AnonymousTrackingId = headerValue;
            var response = await _createMessageBoardHandler.ExecuteAsync(request);
            return GetResult(response);
        }


        [ProducesResponseType(typeof(MessageBoardResponse), 200)]
        [ProducesResponseType(typeof(StatusCodeResult), 440)]
        [ProducesResponseType(typeof(StatusCodeResult), 404)]
        [HttpGet("quotes")]
        public async Task<ActionResult<MessageBoardResponse>> Get([FromHeader(Name = "X-Anonymous-UserTracking")][Required] string headerValue)
        {
            var response = await _getMessageBoardHandler.ExecuteAsync(headerValue);
            return GetResult(response);
        }
    }
}
