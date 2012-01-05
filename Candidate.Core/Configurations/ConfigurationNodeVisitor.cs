using Candidate.Core.Configurations.Parts;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Configurations
{
    // TODO: ABE remove
    public abstract class ConfigurationNodeVisitor
    {
        public abstract void Visit(Pre node);
        public abstract void Visit(VisualStudioConfiguration node);
        public abstract void Visit(Github node);
        public abstract void Visit(Solution node);
        public abstract void Visit(Iis node);
        public abstract void Visit(Post node);
    }
}
