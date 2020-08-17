using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testCRM.models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateAdded { get; set; }
        public Person()
        {          
            this.DateAdded  = DateTime.UtcNow;
        }
    }
}