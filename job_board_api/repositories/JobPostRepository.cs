using AutoMapper;
using JobBoard.Data;
using JobBoard.Dtos;
using JobBoard.exceptions;
using JobBoard.Models;

namespace JobBoard.Repository
{

    public class JobBoardRepository : IJobPostRepository
    {

        private readonly DataContextEntityFramework _dataContext;
        private readonly IMapper _addJobPostMapper;


        public JobBoardRepository(IConfiguration config)
        {
            _dataContext = new DataContextEntityFramework(config);

            _addJobPostMapper = new MapperConfiguration(
                cfg => cfg.CreateMap<AddJobPostDTO, JobPost>()).CreateMapper();
        }

        public int AddJobPost(AddJobPostDTO jobPost, int userId)
        {
            JobPost addJobPost = _addJobPostMapper.Map<JobPost>(jobPost);
            addJobPost.UserId = userId;
            addJobPost.CreatedTime = DateTime.Now;
            _dataContext.JobPosts.Add(addJobPost);
            return _dataContext.SaveChanges();
        }

        public bool DeleteJobPost(int postId, int userId)
        {
               JobPost postForDelete = _dataContext.JobPosts.FirstOrDefault(post => post.Id == postId && post.UserId == userId)!;
            if (postForDelete == null)
            {
                throw new NotFoundException("The job post was not found");
            }

            _dataContext.JobPosts.Remove(postForDelete);
            return _dataContext.SaveChanges() > 0;
        }

        public bool UpdateJobPost(EditJobPostDTO editJobPostDTO, int userId)
        {
            JobPost post = _dataContext.JobPosts.FirstOrDefault(post => post.Id == editJobPostDTO.PostId && post.UserId == userId)!;
            if (post == null)
            {
                throw new NotFoundException("The job post was not found");
            }

            post.Title = editJobPostDTO.Title;
            post.Description = editJobPostDTO.Description;
            _dataContext.JobPosts.Update(post);
            return _dataContext.SaveChanges() > 0;
        }

        public JobPost GetJobPost(int postId)
        {
            return _dataContext.JobPosts.FirstOrDefault(post => post.Id == postId)!;
        }

        public IEnumerable<JobPost> GetJobPostsByUserId(int userId)
        {
            return _dataContext.JobPosts.Where(post => post.UserId == userId).ToList<JobPost>();
        }

        public IEnumerable<JobPost> GetJobPosts()
        {
            return _dataContext.JobPosts.ToList<JobPost>();
        }

    }
}