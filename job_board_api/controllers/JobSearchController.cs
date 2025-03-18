using JobBoard.Models;
using JobBoard.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.contollers
{

    [ApiController]
    [Route("[controller]")]
    public class JobSearchController : ControllerBase
    {
        public readonly IJobSearchRepository _jobSearchRepository;

        public JobSearchController(IJobSearchRepository jobSearchRepository)
        {
            _jobSearchRepository = jobSearchRepository;
        }

        [HttpGet("Search")]

        public PagedResponse<List<JobPost>> Search([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? searchQuery = null)
        {
            return _jobSearchRepository.GetJobs(new PaginationFilter(pageNumber, pageSize), searchQuery);
        }


    }

}