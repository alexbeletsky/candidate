using Candidate.Core.Settings.Model.Configurations;

namespace Candidate.Core.Settings.Model
{
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
