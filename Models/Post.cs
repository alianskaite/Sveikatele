﻿namespace tp_sveikatele.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string CreationDate { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
