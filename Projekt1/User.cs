using System.ComponentModel.DataAnnotations;

namespace Projekt1
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mark { get; set; }
    }
}