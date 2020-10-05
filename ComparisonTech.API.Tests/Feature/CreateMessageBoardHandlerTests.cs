using ComparisonTech.API.Feature.AnonymousTracking;
using ComparisonTech.API.Feature.MessageBoard;
using ComparisonTech.API.Result;
using ComparisonTech.Persistence.Storage;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ComparisonTech.API.Tests.Feature
{
    [TestFixture]
    public class CreateMessageBoardHandlerTests
    {
        private Mock<IFakeDbContext<MessageBoard>> _fakeDb;
        private CreateMessageBoardHandler _createMessageBoardHandler;

        [SetUp]
        public void SetUp()
        {
            _fakeDb = new Mock<IFakeDbContext<MessageBoard>>();
            _createMessageBoardHandler = new CreateMessageBoardHandler(_fakeDb.Object);
         }

        [TestCase]
        public async Task Should_ExecuteAsync_Return_201()
        {
            //ARRANGE
            _fakeDb.Setup(x => x.Insert(It.IsAny<string>(), It.IsAny<Func<List<MessageBoard>>>()));

            //ACT
            var request = new MessageBoardRequest()
            {
                Message = "Test A"
            };

            var response = await _createMessageBoardHandler.ExecuteAsync(request);
            
            //ASSERT
            Assert.That(response.IsSuccessful);
            Assert.That(response.Value == (int)HttpStatusCode.Created);
        }
    }
}
