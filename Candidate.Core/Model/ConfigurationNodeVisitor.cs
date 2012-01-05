using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Model
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
