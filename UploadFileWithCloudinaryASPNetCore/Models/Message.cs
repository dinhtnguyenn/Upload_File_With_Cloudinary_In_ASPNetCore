using System;
namespace UploadFileWithCloudinaryASPNetCore.Models
{
    public class Message
    {
        public Message(int id, string content, string link)
        {
            Id = id;
            Content = content;
            Link = link;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
 
       
    }
}

