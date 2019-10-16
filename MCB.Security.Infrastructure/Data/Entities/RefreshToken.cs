using System;

namespace MCB.Security.Infrastructure.Data.Entities
{
    public class RefreshToken : BaseEntity
    {
        public int Guid { get; set; }
        public int UserGuid { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsValid
        {
            get
            {
                return DateTime.Compare(DateTime.Now, Expiration) < 0;
            }
        }
    }
}
