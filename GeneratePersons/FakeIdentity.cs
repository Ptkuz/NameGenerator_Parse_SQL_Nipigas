using System;
using System.Collections.Generic;

namespace GeneratePersons
{
    // Класс личностей
    public partial class FakeIdentity
    {
        public int Id { get; set; }
        public string PersonName { get; set; } = null!;
        public string Addres { get; set; } = null!;
        public string MothersMaidenName { get; set; } = null!;
        public string Ssn { get; set; } = null!;
        public string GeoCoordinates { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int CountryCode { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string TropicalZodiac { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Website { get; set; } = null!;
        public string MasterCard { get; set; } = null!;
        public string Expires { get; set; } = null!;
        public int Cvc2 { get; set; }
        public string Company { get; set; } = null!;
        public string Occupation { get; set; } = null!;
        public string Height { get; set; } = null!;
        public string Weight { get; set; } = null!;
        public string BloodType { get; set; } = null!;
        public string FavoriteColor { get; set; } = null!;
        public string? Guid { get; set; }
    }
}
