﻿namespace Teg_Coding_Challenge.ModelBO
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int VenueId { get; set; }
    }
}
