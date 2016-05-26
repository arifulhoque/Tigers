using System;

namespace Teams.Service.DomainModels
{
    public class Team
    {
        public long TeamID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public Guid PublicKey { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public DateTime UpdatedDateUTC { get; set; }
    }
}