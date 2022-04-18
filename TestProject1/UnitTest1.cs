using Books_WebAPI.Controllers;
using Books_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly BooksController _booksController;
        private readonly BooksService _booksService;

        public UnitTest1()
        {
            //var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            //HttpResponseMessage result = new HttpResponseMessage();

            //handlerMock
            //    .Protected()
            //    .Setup<Task<HttpResponseMessage>>(
            //        "SendAsync",
            //        ItExpr.IsAny<HttpRequestMessage>(),
            //        ItExpr.IsAny<CancellationToken>()
            //    )
            //    .ReturnsAsync(result)
            //    .Verifiable();

            //var httpClient = new HttpClient(handlerMock.Object)
            //{
            //    BaseAddress = new Uri("https://fakerestapi.azurewebsites.net/api/v1/Books")
            //};

            //var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            //mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            ////service = new MyExternalService(mockHttpClientFactory.Object);
            //_booksService = new BooksService(mockHttpClientFactory.Object);
            //_booksController = new BooksController(_booksService);
        }

        [Fact]
        public async void GetAll()
        {
            //var result = await _booksController.Get();
            //Assert.IsType<OkObjectResult>(result);
        }
    }
}
