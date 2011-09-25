namespace Candidate.Core.Settings.Model
{
    /// <summary>
    /// Base class for visiting SiteConfiguration object structure.
    /// </summary>
    public abstract class SiteConfigurationNodeVisitor
    {
        /// <summary>
        /// Perfoms SiteConfiguration node specific actions
        /// </summary>
        /// <param name="node">The SiteConfiguration node.</param>
        public abstract void Visit(SiteConfiguration node);

        /// <summary>
        /// Perfoms GitHub node specific actions
        /// </summary>
        /// <param name="node">The GitHub node.</param>
        public abstract void Visit(GitHub node);

        /// <summary>
        /// Perfoms Solution node specific actions
        /// </summary>
        /// <param name="node">The Solution node.</param>
        public abstract void Visit(Solution node);

        /// <summary>
        /// Perfoms Iis node specific actions
        /// </summary>
        /// <param name="node">The Iis node.</param>
        public abstract void Visit(Iis node);

        /// <summary>
        /// Perfoms Post node specific actions
        /// </summary>
        /// <param name="node">The Post node.</param>
        public abstract void Visit(Post node);
    }
}
