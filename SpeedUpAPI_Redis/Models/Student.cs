using System.ComponentModel.DataAnnotations;

namespace SpeedUpAPI_Redis.Models
{
    public class Student
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
