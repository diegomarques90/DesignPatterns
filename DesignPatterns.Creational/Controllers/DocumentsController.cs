using DesignPatterns.Core.Entities;
using DesignPatterns.Core.Observers;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult StatePatternPost()
        {
            var document = new Document(Guid.NewGuid());

            var documentContext = new DocumentStateContext(new DocumentDraftState());

            //draft with common user
            documentContext.Publish(false, document);
            documentContext.Render(false, document);


            //draft with admin user
            documentContext.Publish(true, document);
            documentContext.Render(true, document);


            //moderation with common user
            documentContext.Publish(false, document);
            documentContext.Render(false, document);


            //moderation with admin user
            documentContext.Publish(true, document);
            documentContext.Render(true, document);


            //publish with common user
            documentContext.Publish(false, document);
            documentContext.Render(false, document);

            //publish with admin user
            documentContext.Publish(true, document);
            documentContext.Render(true, document);
            
            return NoContent();
        }
    }
}
