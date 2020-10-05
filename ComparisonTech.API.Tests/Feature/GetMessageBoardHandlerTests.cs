using ComparisonTech.API.Feature.MessageBoard;
using ComparisonTech.Persistence.Storage;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonTech.API.Tests.Feature
{
    public class GetMessageBoardHandlerTests
    {
        private Mock<IFakeDbContext<MessageBoard>> _fakeDb;
        private GetMessageBoardHandler _getMessageBoardHandler;

        [SetUp]
        public void SetUp()
        {
            _fakeDb = new Mock<IFakeDbContext<MessageBoard>>();
            _getMessageBoardHandler = new GetMessageBoardHandler(_fakeDb.Object);
        }

        [TestCase]
        public async Task Should_ExecuteAsync_Return_Messages()
        {
            //ARRANGE
            var anonymousTrackingId = Guid.NewGuid().ToString();
            var messages = new List<MessageBoard>() 
            { 
                new MessageBoard() { Message = "Message A" },
                new MessageBoard() { Message = "Message B" }
            };
            
            _fakeDb.Setup(x => x.Get(It.IsAny<string>())).Returns(messages);

            //ACT
             var response = await _getMessageBoardHandler.ExecuteAsync(anonymousTrackingId);
            var expectedMessages = response.Value.Messages;
            
            //ASSERT
            Assert.That(response.IsSuccessful);
            Assert.That(messages.Count == 2);
        }
    }
}
