using JobBoard.Data;
using JobBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.contollers {

    [ApiController]
    [Route("[controller]")]
    public class JobPostController : ControllerBase {

        private readonly DataContextEntityFramework _dataContext;
        private readonly IConfiguration _config;

        public JobPostController(IConfiguration config) {
            _config = config;
            _dataContext = new DataContextEntityFramework(_config);
        }

        [HttpGet]
        public IEnumerable<JobPost> Get() {
            Console.WriteLine("Get", _dataContext);
            return _dataContext.JobPosts;
        }

    }

}