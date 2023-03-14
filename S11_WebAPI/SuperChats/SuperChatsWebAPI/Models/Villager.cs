namespace SuperChatsWebAPI.Models
{
    public class Villager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public bool Zombified { get; set; }

        public virtual List<User> UserFriends { get; set; }
    }
}
