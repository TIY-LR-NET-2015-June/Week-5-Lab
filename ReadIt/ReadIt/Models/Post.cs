using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace ReadIt.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual SiteUser User { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpCount { get; set; }
        public int DownCount { get; set; }
        private int VoteTotal
        {
            get
            {
                return UpCount - DownCount;
            }
        }

        public string LinkTarget { get; set; }
        public string ImageResource { get; set; }

        public int GetVoteTotal()
        {
            return VoteTotal;
        }
        public int UpVote()
        {
            UpCount++;
            return UpCount;
        }
        public int DownVote()
        {
            DownCount++;
            return DownCount;
        }
    }
}
