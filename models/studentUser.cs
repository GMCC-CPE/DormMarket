using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class studentUser
{
    [BsonId]
    public int Id { get; set; }

    [BsonElement("first_Name")]
    public string FirstName { get; set; }

    [BsonElement("last_Name")]
    public string LastName { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("password")]
    public string Password { get; set; }

    [BsonElement("phone")]
    public string Phone { get; set; }

    [BsonElement("date_Joined")]
    public DateTime DateJoined { get; set; }

    [BsonElement("id_image_path")]
    public string? IdImagePath { get; set; }

    [BsonElement("verification_status")]
    public string? VerificationStatus { get; set; }

    [BsonElement("verified_at_utc")]
    public DateTime? VerifiedAtUtc { get; set; }
}