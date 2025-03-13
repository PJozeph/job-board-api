using JobBoard.Data;
using JobBoard.Models;
using JobBoard.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.contollers {

    [ApiController]
    [Route("[controller]")]
    public class JobPostController : ControllerBase {


        public readonly IJobPostRepository jobPostRepository;

        public JobPostController(IJobPostRepository jobPostRepository) {
            this.jobPostRepository = jobPostRepository;
        }

        [HttpGet("GetJobPosts")]
        public IEnumerable<JobPost> Get() {
            return jobPostRepository.GetJobPosts();
        }


        [HttpPost("AddJobPost")]
        public IActionResult Save() {
            return Ok();
        }

        [HttpPut("UpdateJobPost")]
        public IActionResult Update() {
            return Ok();
        }

        [HttpDelete("DeleteJobPost")]
        public IActionResult Delete(int id) {
            return Ok();
        }

    }

}