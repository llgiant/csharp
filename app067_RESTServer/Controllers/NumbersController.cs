using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using app067_RESTServer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app067_RESTServer.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {

        private readonly INumbersRepository _numbersRepository;
        public NumbersController(INumbersRepository numbersRepository)
        {
            _numbersRepository = numbersRepository;
        }

        // GET: api/<NumbersController>
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return _numbersRepository.GetAllNumbers();
        }

        // GET api/<NumbersController>/5
        [HttpGet("{id}")]
        public HttpResponseMessage Get(int id)
        {
            Number number;
            try
            {
                number = _numbersRepository.GetNumber(id);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(e.Message)),
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            if (number == null) { return new HttpResponseMessage(HttpStatusCode.NotFound); }

            return new HttpResponseMessage()
            {
                Content = new StringContent(number.ToString()),
                StatusCode = HttpStatusCode.OK,
            };
        }

        // POST api/<NumbersController>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Number num)
        {
            Number number;
            try
            {
                number = _numbersRepository.Add(num);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(e.Message),
                    StatusCode = HttpStatusCode.PreconditionFailed
                };
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(number.ToString()),
                StatusCode = HttpStatusCode.Created
            };
        }

        // DELETE api/<NumbersController>/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            Number number;
            try
            {
                number = _numbersRepository.Delete(id);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(e.Message),
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(number.ToString()),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
