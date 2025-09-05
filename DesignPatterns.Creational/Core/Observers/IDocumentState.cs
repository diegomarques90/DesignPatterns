using DesignPatterns.Core.Entities;

namespace DesignPatterns.Core.Observers
{
    public interface IDocumentState
    {
        void Render(bool isAdmUser, Document document);
        void Publish(bool isAdmUser, Document document);
        void SetContext(DocumentStateContext context);
        DocumentStateContext Context { get; }
    }
}
