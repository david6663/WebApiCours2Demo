using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SuperChatsWebAPI.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("FK_IdVillager")]
        public int VillagerId { get; set; }
        [JsonIgnore]
        public virtual Villager Villager { get; set; }
    }
}
