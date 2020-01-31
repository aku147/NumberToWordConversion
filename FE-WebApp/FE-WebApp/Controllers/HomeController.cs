using FE_WebApp.Interfaces;
using FE_WebApp.Models;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FE_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceAccess _service;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor that initialize the service and logger object using dependency injection
        /// </summary>
        /// <param name="service">This instance gives the methods to call Rest APIs</param>
        /// <param name="logger">This instance gives the methods for logging</param>
        public HomeController(IServiceAccess service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Default Action which handels page load
        /// </summary>
        /// <returns>Form to input user name and number</returns>
        public ActionResult Index()
        {
            PersonDetail model = null;
            return View(model);
        }

        /// <summary>
        /// Handles the form post for the details input by user
        /// </summary>
        /// <param name="model">Person Details</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(PersonDetail model)
        {
            try
            {
                if (model != null && !string.IsNullOrEmpty(model.Number))
                {
                    var request = new NumToWordConvertRequest();
                    request.Input = model.Number;
                    string apiUrl = string.Format("{0}/{1}", Constants.ApiBaseUrl.TrimEnd('/'), Constants.GetWordRepresentationOfNumberApiUrl.TrimStart('/'));
                    var numberToWordConversionTask = Task.Run(async () => await _service.PostAsync<string, NumToWordConvertRequest>(apiUrl, request));
                    if (numberToWordConversionTask != null)
                    {
                        //Get the data from task which calls APIs for word conversion
                        model.Number = numberToWordConversionTask.GetAwaiter().GetResult(); 
                    }
                    else
                    {
                        _logger.Info("Number to Word Conversion failed" + model.Number);
                        ViewBag.Error = "Number to Word Conversion failed";                        
                    }
                }                
            }
            catch(Exception exc)
            {
                _logger.Error(exc.Message, exc);
            }            
            return View(model);
        }
    }
}