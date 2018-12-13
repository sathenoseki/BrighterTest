using System;
using System.Threading;
using System.Threading.Tasks;
using Paramore.Brighter;

namespace BrighterTest
{
   public class BlogCommand : Command
    {
        public BlogCommand() :base(Guid.NewGuid())
        {}

        public string Name { get; set; }
    }
    public class BlogHandler : RequestHandlerAsync<BlogCommand>
    {
        private BlogRepo _context { get; set; }
        public BlogHandler(BlogRepo context)
        {
            _context = context;
        }

        public override async Task<BlogCommand> HandleAsync(BlogCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            await _context.Add(command.Name); 
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}