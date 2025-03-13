using JobBoard.Data;
using JobBoard.Models;

namespace JobBoard.Repository {

    public class JobBoardRepository : IJobPostRepository {
        
        private readonly DataContextEntityFramework _dataContext;

        public JobBoardRepository(IConfiguration config) {
            _dataContext = new DataContextEntityFramework(config);
        }

        public void AddJobPost(JobPost jobPost) {
            throw new NotImplementedException();
        }

        public void DeleteJobPost(int postId) {
            throw new NotImplementedException();
        }

        public void UpdateJobPost(JobPost jobPost) {
            throw new NotImplementedException();
        }

        public JobPost GetJobPost(int postId) {
          return  _dataContext.JobPosts.FirstOrDefault(post => post.PostId == postId);
        }

        public IEnumerable<JobPost> GetJobPosts() {
            return _dataContext.JobPosts.ToList<JobPost>();
        }
    }
}