namespace JobBoard.Services
{
    public class JobPostService
    {

        private readonly IConfiguration configuration;

        public JobPostService(IConfiguration config)
        {
            configuration = config;
        }

    }
}