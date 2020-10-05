using ComparisonTech.API.Result;
using ComparisonTech.Persistence.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace ComparisonTech.API.Feature.MessageBoard
{
    public class GetMessageBoardHandler
    {
        private IFakeDbContext<MessageBoard> _dbContext;
        public GetMessageBoardHandler(IFakeDbContext<MessageBoard> dbContext) => _dbContext = dbContext;

        public async Task<Result<MessageBoardResponse>> ExecuteAsync(string anonymousTrackingId)
        {
            var messages = _dbContext.Get(anonymousTrackingId).ToList();
            return new SuccessResult<MessageBoardResponse>(new MessageBoardResponse() { Messages = messages });
        }
    }
}
