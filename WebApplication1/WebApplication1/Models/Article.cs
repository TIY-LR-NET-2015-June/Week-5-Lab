using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Article
    {   
        [Key]
        public int Id { get; set; }

        public DateTime Submitted { get; set; }

        [Required]
        public string Headline { get; set; }

        [Required]
        public string Url { get; set; }

        public string PictureUrl { get; set; }

        public ApplicationUser User { get; set; }

        public int? UpVotes { get; set; }

        public int? DownVotes { get; set; }

        [NotMapped]
        public int? Popularity { get { return (UpVotes - DownVotes); } }
    }

}