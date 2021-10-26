namespace MyTube.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    
    using MyTube.Models;
    using MyTube.Services.Votes;
    using MyTube.ViewModels.Votes;
    
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : Controller
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVotesService votesService, UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VotesResponseModel>> Post(VotesInputModel input)
        {
            var userId = userManager.GetUserId(this.User);

            await this.votesService.VoteAsync(input.VideoId, userId, input.IsUpVote);
            var likesCount = this.votesService.LikesCount(input.VideoId);
            var dislikesCount = this.votesService.DislikesCount(input.VideoId);

            return new VotesResponseModel { LikesCount = likesCount, DislikesCount = dislikesCount};
        }
    }
}
