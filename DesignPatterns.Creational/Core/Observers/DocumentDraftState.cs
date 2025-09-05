using DesignPatterns.Core.Entities;

namespace DesignPatterns.Core.Observers
{
    public class DocumentDraftState : IDocumentState
    {
        public DocumentStateContext Context { get; protected set; }

        public void Publish(bool isAdmUser, Document document)
        {
            if (isAdmUser)
            {
                Console.WriteLine("DocumentDraftState: The user is a admin, so he can publish this draft.");
                document.Status = Enums.DocumentStatus.Draft;
                
                //Here you can put your code to do a real publish of this document

                //after publish we change to next state
                Context.ChangeState(new DocumentInModerationState());
            } 
            else
            {
                Console.WriteLine("DocumentDraftState: User is not a administrator. He cant publish this draft.");
            }
        }

        public void Render(bool isAdmUser, Document document)
        {
            if (isAdmUser)
            {
                Console.WriteLine("DocumentDraftState: The user is a admin, so he can view this draft.");
            }
            else
            {
                Console.WriteLine("DocumentDraftState: User is not a administrator. He cant view this draft.");
            }
        }

        public void SetContext(DocumentStateContext context)
        {
            Context = context;
        }
    }
}
