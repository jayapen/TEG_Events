namespace Teg_Coding_Challenge
{
    public class Globals
    {
        public string GlobalApiUrl { get; set; }
        public Globals() {

            GlobalApiUrl = "https://teg-coding-challenge.s3.ap-southeast-2.amazonaws.com/events/event-data.json";
        }

    }
}
