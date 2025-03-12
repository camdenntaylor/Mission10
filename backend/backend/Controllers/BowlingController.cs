using backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private BowlingLeagueContext _bowlingContext;
        public BowlingController(BowlingLeagueContext temp) 
        {
            _bowlingContext = temp;
        }

        [HttpGet(Name = "GetBowlers")]
        public IEnumerable<Bowler> Get()
        {
            var bowlerList = _bowlingContext.Bowlers
                .Include(b => b.Team)
                .ToList();

            return bowlerList;
        }
    }
}
