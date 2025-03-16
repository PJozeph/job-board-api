using JobBoard.Dtos;
using JobBoard.Models;
using JobBoard.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.contollers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JobPostController : ControllerBase
    {
        public readonly IJobPostRepository jobPostRepository;

        public JobPostController(IJobPostRepository jobPostRepository)
        {
            this.jobPostRepository = jobPostRepository;
        }

        [HttpGet("GetAll")]
        [Authorize]

        public IEnumerable<JobPost> Get()
        {
            string userId = User.FindFirst("userId")?.Value + "";
            return jobPostRepository.GetJobPostsByUserId(int.Parse(userId));
        }

        [HttpGet("GetSingle/{id}")]
        public IActionResult GetSingleJobPost(int id)
        {
            JobPost jobPost = jobPostRepository.GetJobPost(id);
            return Ok(jobPost);
        }

        [HttpPost("Add")]
        public IActionResult Save(AddJobPostDTO addJobPostDTO)
        {
            string userId = User.FindFirst("userId")?.Value + "";

            if (jobPostRepository.AddJobPost(addJobPostDTO, int.Parse(userId)) == 0)
            {
                return BadRequest("The job post was not added");
            }
            return Ok("The job post created");
        }

        [HttpPut("Update")]
        public IActionResult Update(EditJobPostDTO editJobPostDTO)
        {
            string userId = User.FindFirst("userId")?.Value + "";

            if (jobPostRepository.UpdateJobPost(editJobPostDTO, int.Parse(userId)))
            {
                return Ok();
            }
            return BadRequest("The job post was not updated");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            string userId = User.FindFirst("userId")?.Value + "";
            return jobPostRepository.DeleteJobPost(id,int.Parse(userId)) ? Ok() : BadRequest();
        }

    }

}