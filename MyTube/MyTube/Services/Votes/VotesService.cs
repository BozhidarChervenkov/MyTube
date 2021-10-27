namespace MyTube.Services.Votes
{
    using System.Linq;
    using System.Threading.Tasks;

    using MyTube.Data;
    using MyTube.Models;

    public class VotesService : IVotesService
    {
        private readonly ApplicationDbContext context;

        public VotesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task VoteAsync(int videoId, string userId, bool isUpVote)
        {
            var video = this.context.Videos.FirstOrDefault(v => v.Id == videoId);

            // Keeping track voting logic
            if (this.context.Votes.Any(v => v.VideoId == videoId && v.ApplicationUserId == userId))
            {
                // Vote exists logic:
                var vote = this.context.Votes.FirstOrDefault(v => v.VideoId == videoId && v.ApplicationUserId == userId);

                if (vote.IsUpVote == true && isUpVote == true)
                {
                    // We don't do anything
                }
                else if (vote.IsUpVote == false && isUpVote == false)
                {
                    // We don't do anything
                }
                else if (vote.IsUpVote == true && isUpVote == false)
                {
                    vote.IsUpVote = false;
                    video.LikesCount--;
                    video.DislikesCount++;
                }
                else if (vote.IsUpVote == false && isUpVote == true)
                {
                    vote.IsUpVote = true;
                    video.LikesCount++;
                    video.DislikesCount--;
                }
            }
            else
            {
                // Vote doesn't exist logic:
                var vote = new Vote
                {
                    VideoId = videoId,
                    ApplicationUserId = userId,
                    IsUpVote = isUpVote
                };

                await this.context.Votes.AddAsync(vote);

                if (isUpVote == true)
                {
                    video.LikesCount++;
                }
                else
                {
                    video.DislikesCount++;
                }
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
