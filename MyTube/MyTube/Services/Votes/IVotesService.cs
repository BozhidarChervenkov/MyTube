namespace MyTube.Services.Votes
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(int videoId, string userId, bool isUpVote);

        int LikesCount(int videoId);

        int DislikesCount(int videoId);
    }
}
