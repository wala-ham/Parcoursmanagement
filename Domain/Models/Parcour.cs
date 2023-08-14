using System.ComponentModel.DataAnnotations;

namespace Parcours_management.Domain.Models
{
    public class Parcour
    {
        
        [Key]
        public int ParcoursId { get; set; }
        public string ParcoursName { get; set; }
        public string ParcoursDescription { get; set; }
        public DateTime DateCreation { get; set; }




    }
}
