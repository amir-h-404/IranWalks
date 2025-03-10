﻿namespace API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

        // Navigation properties (1 to 1 relationship):
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
