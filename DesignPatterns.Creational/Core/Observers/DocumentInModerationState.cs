using DesignPatterns.Core.Entities;

namespace DesignPatterns.Core.Observers
{
    public class DocumentInModerationState : IDocumentState
    {
        public DocumentStateContext Context { get; protected set; }

        public void Publish(bool isAdmUser, Document document)
        {
            if (isAdmUser)
            {
                Console.WriteLine("DocumentInModerationState: The user is a admin, so he can publish this moderation.");
                document.Status = Enums.DocumentStatus.InModeration;
                //Here you can put your code to do a real publish of this document

                //after publish we change to next state
                Context.ChangeState(new DocumentPublishedState());
            }
            else
            {
                Console.WriteLine("DocumentInModerationState: Admin is not a administrator. He cant publish this moderation.");
            }
        }

        public void Render(bool isAdmUser, Document document)
        {
            if (isAdmUser)
            {
                Console.WriteLine("DocumentInModerationState: The user is a admin, so he can view this moderation.");
            }
            else
            {
                Console.WriteLine("DocumentInModerationState: User is not a administrator. He cant view this moderation.");
            }
        }

        public void SetContext(DocumentStateContext context)
        {
            Context = context;
        }
    }
}
