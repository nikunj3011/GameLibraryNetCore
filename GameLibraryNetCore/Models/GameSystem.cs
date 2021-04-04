using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameLibraryNetCore.Models
{
    public class GameSystem
    {
        [Key]
        public int GameSystemID { get; set; }

        [Required]
        [Display(Name = "System Name")]
        [MinLength(2, ErrorMessage = "Name must be at lest 2 Characters")]
        [MaxLength(64, ErrorMessage = "Name can't be logner than 64 Characters")]
        public string SystemName { get; set; }

        public virtual ICollection<GameLibrary> GameLibrary { get; set; }
    }
}