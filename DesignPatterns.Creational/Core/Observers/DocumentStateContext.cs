using DesignPatterns.Core.Entities;

namespace DesignPatterns.Core.Observers
{
    public class DocumentStateContext
    {
        private IDocumentState _state = null;

        public DocumentStateContext(IDocumentState state)
        {
            ChangeState(state);
        }
        public void Publish(bool isAdmUser, Document document)
        {
            _state.Publish(isAdmUser, document);
        }

        public void Render(bool isAdmUser, Document document)
        {
            _state.Render(isAdmUser, document);
        }

        public void ChangeState(IDocumentState state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}");
            _state = state;
            _state.SetContext(this);
        }
    }
}
