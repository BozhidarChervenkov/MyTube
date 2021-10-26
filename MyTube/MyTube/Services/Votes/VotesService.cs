namespace MyTube.Services.Votes
{
    using System.Linq;
    using System.Threading.Tasks;

    using MyTube.Data;

    public class VotesService : IVotesService
    {
        private readonly ApplicationDbContext context;

        public VotesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task VoteAsync(int videoId, string userId, bool isUpVote)
        {
            // Todo: Keep track of who voted using the userId

            var video = this.context.Videos.FirstOrDefault(v => v.Id == videoId);

            if (isUpVote == true)
            {
                video.LikesCount++;
            }
            else
            {
                video.DislikesCount++;
            }

            await this.context.SaveChangesAsync();
        }

        public int LikesCount(int videoId)
        {
            var video = this.context.Videos.FirstOrDefault(v => v.Id == videoId);

            return video.LikesCount;
        }

        public int DislikesCount(int videoId)
        {
            var video = this.context.Videos.FirstOrDefault(v => v.Id == videoId);

            return video.DislikesCount;
        }
    }
}
