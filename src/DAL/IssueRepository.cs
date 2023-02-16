using WebApp.BLL;

namespace WebApp.DAL;

public interface IIssueRepository : IRepository<Issue> {
}

public class IssueRepository : BaseRepository<Issue>, IIssueRepository {
}