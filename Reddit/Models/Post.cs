using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reddit.Models
{
    public class Post
    {
        RedditUser user = new RedditUser();
        public int ID { get; set; }
        public string Publisher { get; set; }
        public int ConsolidatedVotes
        {
            get
            {
                return PositiveVote + NegativeVote;
            }
        }
        public int PositiveVote { get; set; }
        public int NegativeVote { get; set; }
        public string ShortDescription
        {
            get
            {
                return Body.Substring(0, 50) + "...";
            }
        }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        public DateTime PublishedOn { get; private set; }

        public Post()
        {
            PublishedOn = DateTime.Now;
            Publisher = user.UserName;
        }
    }
}