using JobBoard.Data;
using JobBoard.Models;

namespace JobBoard.Repository
{
    public class JobSearchRepository : IJobSearchRepository
    {
        private readonly DataContextEntityFramework _context;

        public JobSearchRepository (IConfiguration configuration)
        {
            _context = new DataContextEntityFramework(configuration);

        }

        PagedResponse<List<JobPost>> IJobSearchRepository.GetJobs(PaginationFilter paginationFilter)
        {
                var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
                List<JobPost> JobPostList = _context.JobPosts.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
            return new PagedResponse<List<JobPost>>(JobPostList, validFilter.PageNumber, validFilter.PageSize);


            throw new NotImplementedException();
        }
    }
}