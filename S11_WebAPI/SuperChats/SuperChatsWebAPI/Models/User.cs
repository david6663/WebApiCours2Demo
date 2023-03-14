using Microsoft.AspNetCore.Identity;

namespace SuperChatsWebAPI.Models
{
    public class User: IdentityUser
    {
        public virtual List<Villager> VillagerFriends { get; set; }
    }
}
