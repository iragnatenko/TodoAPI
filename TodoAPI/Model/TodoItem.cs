using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Model
{
//    [Table("ToDo_Items")]
    public class TodoItem
    {
//        [Column("ItemId")]
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }


    }
}
