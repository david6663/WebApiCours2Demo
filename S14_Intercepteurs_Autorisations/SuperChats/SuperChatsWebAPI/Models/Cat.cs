using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SuperChatsWebAPI.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("FK_VillagerID")]
        public int VillagerID { get; set; }

        [JsonIgnore]
        public virtual Villager? Villager { get; set; }   //si on n'a pas mis ?, pour le post, faut choisir un villager, assumer que ca existe. Donc, Jsonignore PAS villagerID
    }
}
