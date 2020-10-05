using ComparisonTech.API.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComparisonTech.API.Feature.MessageBoard
{
    public class MessageBoardRequest : Request
    {
        public MessageBoardRequest()
        {
            DateCreated = DateTime.UtcNow;
        }

        [Required]
        public string Message { get; set; }

        public DateTime DateCreated { get; private set; }
    }
}
