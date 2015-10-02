using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab5_Jason.Models
{
    public class RedditPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
        public string URL { get; set; }

        [NotMapped]
        public int TotalVotes {
            get
            {
                return UpVote - DownVote;
            }
        }

        public DateTime PostTime { get; set; }
    }
}