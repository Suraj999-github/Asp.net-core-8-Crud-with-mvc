using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("salutation")]
        public string? Salutation { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("middle_name")]
        public string? MiddleName { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }
    }
    public class AddStudent
    {
        public string? PhoneNumber { get; set; }
        public string? Salutation { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
    }
    public class UpdateStudent
    {
        public long Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Salutation { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
    }

}
