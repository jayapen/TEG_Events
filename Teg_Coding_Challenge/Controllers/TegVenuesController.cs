using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Teg_Coding_Challenge.ModelBO;

namespace Teg_Coding_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TegVenuesController : ControllerBase
    {
        private string URL;
        public TegVenuesController(Globals url)
        {

            URL = url.GlobalApiUrl;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            EventListing eventListing = new EventListing();
            List<Venue> lstVenues= new List<Venue>();
            try
            {


                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        eventListing = JsonConvert.DeserializeObject<EventListing>(json);
                        lstVenues = eventListing.Venues;

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
            return Ok(lstVenues);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            EventListing eventListing = new EventListing();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(URL);
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
            var selectedEvent = eventListing.Events.Where(x => x.VenueId == id).ToList();
            return Ok(selectedEvent);
        }


    }
}
