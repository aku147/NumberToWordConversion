using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NumberToWordConversionEntities;
using NumberToWordConversionRepository;
using NumToWordConversionApiApp.Controllers;
using System;
using System.Web.Http;
using System.Web.Http.Results;

namespace NumToWordConversionApiAppTests
{
    [TestClass]
    public class WordFormatControllerTests
    {
        [TestMethod]
        public void MethodReturnsOkResultIfInputIsProvided()
        {
            // Arrange
            NumToWordConvertRequest request = new NumToWordConvertRequest() { Input = "776677" };
            var mockConversionRepository = new Mock<IConvertor>();
            var mockLoggerRepository = new Mock<ILogger>();
            double number = 776677;
            mockConversionRepository.Setup(x => x.ConvertNumberToWordFormat(number)).Returns(It.IsAny<string>());
            var controller = new WordFormatController(mockConversionRepository.Object, mockLoggerRepository.Object);

            //Act
            IHttpActionResult actionResult = controller.GetWordRepresentationOfNumber(request);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(contentResult);
            mockConversionRepository.Verify(x => x.ConvertNumberToWordFormat(number), Times.Once);
        }

        [TestMethod]
        public void MethodReturnsBadRequestResultIfInputIsNotProvided()
        {
            // Arrange
            NumToWordConvertRequest request = new NumToWordConvertRequest() { Input = null };
            var mockConversionRepository = new Mock<IConvertor>();
            var mockLoggerRepository = new Mock<ILogger>();
            double number = 776677;
            mockConversionRepository.Setup(x => x.ConvertNumberToWordFormat(number)).Returns(It.IsAny<string>());
            var controller = new WordFormatController(mockConversionRepository.Object, mockLoggerRepository.Object);

            //Act
            IHttpActionResult actionResult = controller.GetWordRepresentationOfNumber(request);
            var contentResult = actionResult as BadRequestErrorMessageResult;

            // Assert
            Assert.IsNotNull(contentResult);
            mockConversionRepository.Verify(x => x.ConvertNumberToWordFormat(number), Times.Never);
        }

        [TestMethod]
        public void MethodReturnsInternalServerErrorIfExceptionOccurs()
        {
            // Arrange
            NumToWordConvertRequest request = new NumToWordConvertRequest() { Input = "776677" };
            var mockConversionRepository = new Mock<IConvertor>();
            var mockLoggerRepository = new Mock<ILogger>();
            double number = 776677;
            mockConversionRepository.Setup(x => x.ConvertNumberToWordFormat(number)).Throws(new Exception("Error occured"));
            var controller = new WordFormatController(mockConversionRepository.Object, mockLoggerRepository.Object);

            //Act
            IHttpActionResult actionResult = controller.GetWordRepresentationOfNumber(request);
            var contentResult = actionResult as InternalServerErrorResult;

            // Assert
            Assert.IsNotNull(contentResult);
            mockConversionRepository.Verify(x => x.ConvertNumberToWordFormat(number), Times.Once);
        }
    }
}
