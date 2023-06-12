using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Note
    {
        [Key]
        public Guid NoteID { get; set; }
        public string Title { get; set; }
        public string TitleColor { get; set; }
        public string NoteText { get; set; }
        public string Tag { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
    }
}
