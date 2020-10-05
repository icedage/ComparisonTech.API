using ComparisonTech.API.Result;
using ComparisonTech.Persistence.Storage;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ComparisonTech.API.Feature.MessageBoard
{
    public class CreateMessageBoardHandler
    {
        private readonly IFakeDbContext<MessageBoard> _dbContext;
        public CreateMessageBoardHandler(IFakeDbContext<MessageBoard> dbContext) => _dbContext = dbContext;

        public async Task<Result<int>> ExecuteAsync(MessageBoardRequest request)
        {
            _dbContext.Insert( request.AnonymousTrackingId, () => new List<MessageBoard>() { new MessageBoard() { Message = request.Message, DatetimeCreated = request.DateCreated } });
            return new SuccessResult<int>((int)HttpStatusCode.Created);
        }
    }
}
