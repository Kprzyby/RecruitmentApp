﻿using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        [Required(ErrorMessage = "Field is required!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required!")]
        [MaxLength(75, ErrorMessage = "Name of field is to long (max. 75 characters!")]
        public SkillNameEnum Name { get; set; }

        public virtual ICollection<RecruitmentRequirement> RecruitmentRequirements {get;set;}
    }
}
