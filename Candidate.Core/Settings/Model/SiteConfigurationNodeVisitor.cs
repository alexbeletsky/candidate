namespace Candidate.Core.Settings.Model
{
    public abstract class SiteConfigurationNodeVisitor
    {
        public abstract void Visit(Pre node);
        public abstract void Visit(SiteConfiguration node);
        public abstract void Visit(GitHub node);
        public abstract void Visit(Solution node);
        public abstract void Visit(Iis node);
        public abstract void Visit(Post node);
    }
}
