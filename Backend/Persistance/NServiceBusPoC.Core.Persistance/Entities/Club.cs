﻿namespace NServiceBusPoC.Core.Persistance.Entities
{
    public class Club
    {
        public int ClubId { get; set; }

        public string ClubName { get; set; }

        public string Contact { get; set; }

        public int LimitDateChild { get; set; }

        public string Location { get; set; }

        public int NumberOfCoach { get; set; }
    }
}
