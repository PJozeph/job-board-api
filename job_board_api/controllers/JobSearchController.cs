using JobBoard.Models;
using JobBoard.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.contollers
{

    [ApiController]
    [Route("[controller]")]
    public class JobSearchController : ControllerBase
    {
        public readonly IJobPostRepository jobPostRepository;

        public JobSearchController(IJobPostRepository jobPostRepository)
        {
            this.jobPostRepository = jobPostRepository;
        }

        [HttpGet("GetAll")]

        public IActionResult search()
        {
            var jobSearch = jobPostRepository.GetJobPosts();
            return Ok(new Response<IEnumerable<JobPost>>(jobSearch));
        }

        [HttpGet("GetSingle/{id}")]
        public IActionResult GetSingleJobPost(int id)
        {
            JobPost jobPost = jobPostRepository.GetJobPost(id);
            return Ok(jobPost);
        }

    }

}