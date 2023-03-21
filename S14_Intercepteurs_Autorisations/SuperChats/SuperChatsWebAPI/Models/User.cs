using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace SuperChatsWebAPI.Models
{
    public class User: IdentityUser
    {
        public string NickName { get; set; }

        [JsonIgnore]
        public virtual List<Villager> VillagerFriends { get; set; }
    }
}
