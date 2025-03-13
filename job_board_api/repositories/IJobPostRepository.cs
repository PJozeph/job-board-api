using JobBoard.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JobBoard.Repository
{
    public interface IJobPostRepository
    {
        int AddJobPost(JobPost jobPost);
        void DeleteJobPost(int postId);
        void UpdateJobPost(JobPost jobPost);
        JobPost GetJobPost(int postId);
        IEnumerable<JobPost> GetJobPosts();
    
    }
}