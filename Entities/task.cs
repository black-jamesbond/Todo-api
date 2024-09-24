using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Entities
{
    public class task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public bool IsCompleted { get; set; } = false;

        public task(string title)
        {
            Title = title;
        }

        public task()
        {
        }
    }
}
