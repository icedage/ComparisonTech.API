using System;
using System.Collections.Generic;

namespace ComparisonTech.API.Feature.MessageBoard
{
    public class MessageBoardResponse
    {
        public IEnumerable<MessageBoard> Messages { get; set; }
    }

    public class MessageBoard
    {
        public string Message { get; set; }
        public DateTime DatetimeCreated { get; set; }
    }
}
