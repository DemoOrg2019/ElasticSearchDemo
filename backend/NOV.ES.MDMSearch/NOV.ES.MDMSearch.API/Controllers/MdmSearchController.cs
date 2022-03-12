using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOV.ES.MDMSearch.API.Models;
using NOV.ES.MDMSearch.API.Services;

namespace NOV.ES.MDMSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MdmSearchController : ControllerBase
    {
        private readonly ILogger<MdmSearchController> logger;
        private readonly IMDMSearchIndexService mdmSearchIndexService;

        public MdmSearchController(ILogger<MdmSearchController> logger,
            IMDMSearchIndexService mdmSearchIndexService)
        {
            this.logger = logger;
            this.mdmSearchIndexService = mdmSearchIndexService;
        }

        
        [HttpGet]
        [Route("FetchMDMDataFromDb")]
        public async Task<IActionResult> GetData()
        {
            var result = await Task.Run(() => mdmSearchIndexService.GetMdmtSearchModelsFromDbAsync());
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search([FromQuery]MDMTable table, [FromQuery]string query)
        {
            var result = await mdmSearchIndexService.SearchAsync(table, query);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.Documents.ToList());
        }

        [HttpPost]
        [Route("publish")]
        public async Task<IActionResult> publish()
        {
            await mdmSearchIndexService.PublishMdmSearchModelsToElasticSearchAsync();
            return Ok();
        }
    }
}
