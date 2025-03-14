using JobBoard.Data;
using JobBoard.Models;

namespace JobBoard.Repository {

    public class JobBoardRepository : IJobPostRepository {
        
        private readonly DataContextEntityFramework _dataContext;

        public JobBoardRepository(IConfiguration config) {
            _dataContext = new DataContextEntityFramework(config);
        }

        public int AddJobPost(JobPost jobPost) {
            _dataContext.JobPosts.Add(jobPost);
            return _dataContext.SaveChanges();
        }

        public bool DeleteJobPost(int postId) {
            JobPost jobPost = _dataContext.JobPosts.FirstOrDefault(post => post.Id == postId)!;
            if(jobPost == null) {
                throw new  KeyNotFoundException("The job post was not found");
            }
            _dataContext.JobPosts.Remove(jobPost);
            return _dataContext.SaveChanges() > 0;
        }

        public bool UpdateJobPost(JobPost jobPost) {
            _dataContext.JobPosts.Update(jobPost);
            return _dataContext.SaveChanges() > 0;
        }

        public JobPost GetJobPost(int postId) {
            return _dataContext.JobPosts.FirstOrDefault(post => post.Id == postId)!;
        }

        public IEnumerable<JobPost> GetJobPosts() {
            return _dataContext.JobPosts.ToList<JobPost>();
        }

    }
}