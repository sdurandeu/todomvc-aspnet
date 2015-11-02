namespace TodoApp.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ToDo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool Completed { get; set; }
        
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
    }
}