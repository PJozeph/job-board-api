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
            if (jobPost == null)
            {
                return NotFound("The job post was not found");
            }
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
            JobPost post = jobPostRepository.GetJobPost(editJobPostDTO.PostId);
            if (post == null)
            {
                return NotFound("The job post was not found");
            }
            post.Title = editJobPostDTO.Title;
            post.Description = editJobPostDTO.Description;
            if (jobPostRepository.UpdateJobPost(post))
            {
                return Ok();
            }
            return BadRequest("The job post was not updated");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return jobPostRepository.DeleteJobPost(id) ? Ok() : BadRequest();
        }

    }

}