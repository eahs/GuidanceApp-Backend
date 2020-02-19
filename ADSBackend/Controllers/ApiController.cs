using ADSBackend.Models;
using ADSBackend.Models.ApiModels;
using ADSBackend.Models.LinksModels;
using ADSBackend.Models.JobsViewModel;
using ADSBackend.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ADSBackend.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly Services.Configuration Configuration;
        private readonly Services.Cache _cache;
        private readonly ApplicationDbContext _context;

        public ApiController(Services.Configuration configuration, Services.Cache cache)
        {
            Configuration = configuration;
            _cache = cache;
        }

        // GET: api/News
        [HttpGet("News")]
        public async Task<List<NewsFeedItem>> GetNewsFeed()
        {
            var newsUrl = new Uri("https://www.eastonsd.org/apps/news/news_rss.jsp");

            string sourceUrl = newsUrl.GetLeftPart(UriPartial.Authority);
            string endpoint = newsUrl.PathAndQuery;

            Task<List<NewsFeedItem>> fetchNewsFromSource() => Util.RSS.GetNewsFeed(sourceUrl, endpoint);

            var feedItems = await _cache.GetAsync("RSS", fetchNewsFromSource, TimeSpan.FromMinutes(5));
            return feedItems.OrderByDescending(x => x.PublishDate).ToList();
        }
        //GET: api/Links
        [HttpGet("Links")]
        public async Task<List<LinkItem>> GetLinks()
        {
            var links = await _context.LinkItem.ToListAsync();
            return links;
        }
        //GET: api/Jobs
        [HttpGet("Jobs")]
        public async Task<List<Jobs>> GetJobs()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return jobs;
        }

        // GET: api/Config
        [HttpGet("Config")]
        public ConfigResponse GetConfig()
        {
            // TODO: extend this object to include some configuration items
            return new ConfigResponse();
        }

   
    }
}