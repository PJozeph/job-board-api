using JobBoard.Data;
using JobBoard.Dtos;
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

        [HttpGet("GetSingleJobPosts/{id}")]
        public IActionResult GetSingleJobPost(int id) {
           JobPost jobPost = jobPostRepository.GetJobPost(id);
              if (jobPost == null) {
                return NotFound("The job post was not found");
              }
            return Ok(jobPost);
        }

        [HttpPost("AddJobPost")]
        public IActionResult Save(AddJobPostDTO addJobPostDTO) {
            return Ok();
        }

        [HttpPut("UpdateJobPost")]
        public IActionResult Update(EditJobPostDTO editJobPostDTO) {
            return Ok();
        }

        [HttpDelete("DeleteJobPost")]
        public IActionResult Delete(int id) {
            return Ok();
        }

    }

}