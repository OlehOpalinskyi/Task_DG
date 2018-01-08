using System.Collections.Generic;
using System.Web.Http;
using Task.api.Models;
using Task.api.Services;

namespace Task.api.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiController
    {
        private readonly NewsService _service = new NewsService();

        //public NewsController(NewsService service)
        //{
        //    _service = service;
        //}

        [Route("")]
        public IEnumerable<NewsModel> GetNews()
        {
            return _service.GetNews();
        }

        [Route("byTitle")]
        [HttpGet]
        public IEnumerable<NewsModel> ByTitle()
        {
            return _service.ByTitle();
        }

        [Route("byDate")]
        [HttpGet]
        public IEnumerable<NewsModel> ByDate()
        {
            return _service.ByDate();
        }
    }
}
