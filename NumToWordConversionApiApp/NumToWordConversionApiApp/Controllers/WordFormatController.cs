using Microsoft.Web.Http;
using NumberToWordConversionEntities;
using NumberToWordConversionRepository;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace NumToWordConversionApiApp.Controllers
{
    [ApiVersion("1")]
    [RoutePrefix("api/v{version:apiVersion}/wordformat")]
    public class WordFormatController : ApiController
    {
        private readonly IConvertor _convertor;
        private readonly ILogger _logger;
        public WordFormatController(IConvertor convertor, ILogger logger)
        {
            _convertor = convertor;
            _logger = logger;
        }

        /// <summary>
        /// API returns the word representation of number
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(string))]
        [HttpPost]
        [Route("wordrepresentation")]
        public IHttpActionResult GetWordRepresentationOfNumber([FromBody]NumToWordConvertRequest request)
        {
            try
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(request?.Input))
                {
                    string output = _convertor.ConvertNumberToWordFormat(Convert.ToDouble(request.Input));
                    return Ok(output);
                }
                else
                {
                    var errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    _logger.Error("Bad Request: ", new Exception(errorMessage));
                    return BadRequest(errorMessage);
                }
            }
            catch(Exception exc)
            {
                _logger.Error("Exception occured: ", exc);
                return InternalServerError();
            }
        }                 
    }
}
