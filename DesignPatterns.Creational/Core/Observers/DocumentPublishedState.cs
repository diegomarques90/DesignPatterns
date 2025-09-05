using DesignPatterns.Core.Entities;

namespace DesignPatterns.Core.Observers
{
    public class DocumentPublishedState : IDocumentState
    {
        public DocumentStateContext Context { get; protected set; }

        public void Publish(bool isAdmUser, Document document)
        {
            if (isAdmUser)
            {
                Console.WriteLine("DocumentPublishedState: The user is a admin, so he can publish this document.");
                document.Status = Enums.DocumentStatus.Published;
                //Here you can put your code to do a real publish of this document

                //Has no more state to change.
                Console.WriteLine("DocumentPublishedState: the document has ben published.");
            }
            else
            {
                Console.WriteLine("DocumentPublishedState: Admin is not a administrator. He cant publish this document.");
            }
        }

        public void Render(bool isAdmUser, Document document)
        {
            if (isAdmUser)
            {
                Console.WriteLine("DocumentPublishedState: The user is a admin, so he can view this published document.");
            }
            else
            {
                Console.WriteLine("DocumentPublishedState: User is not a administrator. He cant view this published document.");
            }
        }

        public void SetContext(DocumentStateContext context)
        {
            Context = context;
        }
    }
}
