using JobBoard.Data;
using JobBoard.Models;

namespace JobBoard.Repository
{
    public class JobSearchRepository : IJobSearchRepository
    {
        private readonly DataContextEntityFramework _context;

        public JobSearchRepository(IConfiguration configuration)
        {
            _context = new DataContextEntityFramework(configuration);

        }

        PagedResponse<List<JobPost>> IJobSearchRepository.GetJobs(PaginationFilter paginationFilter, string? searchQuery = null)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var query = _context.JobPosts.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(job => job.Title.Contains(searchQuery) || job.Description.Contains(searchQuery));
            }

            List<JobPost> jobPostList = query
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();

            return new PagedResponse<List<JobPost>>(jobPostList, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}