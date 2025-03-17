using JobBoard.Models;

namespace JobBoard.Repository
{
    public interface IJobSearchRepository
    {
        PagedResponse<List<JobPost>> GetJobs(PaginationFilter paginationFilter);
    }
}