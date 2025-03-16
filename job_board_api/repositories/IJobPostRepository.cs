using JobBoard.Dtos;
using JobBoard.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JobBoard.Repository
{
    public interface IJobPostRepository
    {
        int AddJobPost(AddJobPostDTO jobPost, int userId);
        bool DeleteJobPost(int postId);
        bool UpdateJobPost(EditJobPostDTO jobPost, int userId);
        JobPost GetJobPost(int postId);
        IEnumerable<JobPost> GetJobPosts();

        IEnumerable<JobPost> GetJobPostsByUserId(int userId);
    
    }
}