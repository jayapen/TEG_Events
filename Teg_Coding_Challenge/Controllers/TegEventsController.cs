using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Teg_Coding_Challenge.ModelBO;

namespace Teg_Coding_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TegEventsController : ControllerBase
    {
        string apiUrl = "https://teg-coding-challenge.s3.ap-southeast-2.amazonaws.com/events/event-data.json";

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            EventListing eventListing = new EventListing();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        eventListing = JsonConvert.DeserializeObject<EventListing>(json);
                    }
                    else
                    {
                        return BadRequest($"Unable to connect to the TEG Data Server! Please Try again");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"HTTP request failed Reason {ex.Message}");
            }
            return Ok(eventListing);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            EventListing eventListing = new EventListing();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        eventListing = JsonConvert.DeserializeObject<EventListing>(json);
                    }
                    else
                    {
                        return BadRequest($"Unable to connect to the TEG Data Server! Please Try again");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"HTTP request failed Reason {ex.Message}");
            }
            var selectedEvent = eventListing.Venues.FirstOrDefault(x => x.Id == id);
            return Ok(selectedEvent);
        }
    }
}
