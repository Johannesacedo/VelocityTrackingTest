using System.ComponentModel.DataAnnotations;

namespace VelocityTrackingTest.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Projects { get; set; }

        [Required(ErrorMessage ="Task Title is required")]
        public string taskTitle { get; set; }

        [Required(ErrorMessage = "Task must have a description")]
        public string taskDescription { get; set; }
        public float totalEstimate { get; set; }

        public string Employee { get; set; }

        public float estimatedHours { get; set; }
        public float actualHours { get; set; }
    }
}
