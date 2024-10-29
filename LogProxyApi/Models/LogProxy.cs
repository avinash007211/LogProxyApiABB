using System.ComponentModel.DataAnnotations;

namespace LogProxyApi.Models
{
    public class LogProxy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime RecievedAt { get; set; } 
        public string UserId { get; set; }
        
        public string Module { get; set; }
        public string Severity { get; set; }        
        
    }
    public class LogRequest
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public string UserId { get; set; }
        public string Module { get; set; }
        public string Severity { get; set; }
    }

}
