using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RedditClone.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime PostTime { get; set; }

        //Foreign key for user
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }

    }
}