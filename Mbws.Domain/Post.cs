using System;

namespace Mbws.Domain
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; } // Applied on the client-side.
    }
}
