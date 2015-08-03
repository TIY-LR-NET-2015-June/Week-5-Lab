using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MikeIt.Models
{
    public class Post
    {
        [Key]
        public int? PostId { get; set; }

        [Required]
        public string Headline { get; set; }

        [Required]
        public string Url { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public DateTime SubmittedOn { get; set; }

        public ApplicationUser User { get; set; }

        public int UpVotes { get; set; }

    }
   
}