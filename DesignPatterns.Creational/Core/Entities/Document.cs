using DesignPatterns.Core.Enums;

namespace DesignPatterns.Core.Entities
{
    public class Document
    {
        public Document(Guid id)
        {
            
        }
        public Guid Id { get; set; }
        public DocumentStatus Status { get; set; }
    }
}
