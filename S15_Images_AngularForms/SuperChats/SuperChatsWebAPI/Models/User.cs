using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace SuperChatsWebAPI.Models
{
    public class User: IdentityUser
    {
        [JsonIgnore]
        public virtual List<Villager> VillagerFriends { get; set; }
    }
}
