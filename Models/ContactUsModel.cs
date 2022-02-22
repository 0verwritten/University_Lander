using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace University_Lander.Models
{
    public class ContactUsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public List<string> Email { get; set; }
        // public List<SocialLink> SocialNets { get; set; }
        public List<string> PhoneNumber { get; set; }

        // public LocationAddress Location;
    }

    public class SocialLink{
        public string Name;
        public Uri LinkAddress;
        public Uri Icon;
    }

    public class LocationAddress{
        public string Location;
        public string Coordinates;
    }
}