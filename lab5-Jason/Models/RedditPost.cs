using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab5_Jason.Models
{
    public class RedditPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
        public byte[] URL { get; set; }

        public DateTime PostTime { get; set; }
    }
}