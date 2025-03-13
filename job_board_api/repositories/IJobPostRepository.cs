using JobBoard.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JobBoard.Repository
{
    public interface IJobPostRepository
    {
        int AddJobPost(JobPost jobPost);
        bool DeleteJobPost(int postId);
        bool UpdateJobPost(JobPost jobPost);
        JobPost GetJobPost(int postId);
        IEnumerable<JobPost> GetJobPosts();
    
    }
}