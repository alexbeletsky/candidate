namespace Candidate.Core.Settings.Model
{
    /// <summary>
    /// Base class for visiting SiteConfiguration object structure.
    /// </summary>
    public abstract class SiteConfigurationNodeVisitor
    {
        /// <summary>
        /// Performs SiteConfiguration node specific actions
        /// </summary>
        /// <param name="node">The SiteConfiguration node.</param>
        public abstract void Visit(SiteConfiguration node);

        /// <summary>
        /// Performs GitHub node specific actions
        /// </summary>
        /// <param name="node">The GitHub node.</param>
        public abstract void Visit(GitHub node);

        /// <summary>
        /// Performs Solution node specific actions
        /// </summary>
        /// <param name="node">The Solution node.</param>
        public abstract void Visit(Solution node);

        /// <summary>
        /// Performs Iis node specific actions
        /// </summary>
        /// <param name="node">The Iis node.</param>
        public abstract void Visit(Iis node);

        /// <summary>
        /// Performs Post node specific actions
        /// </summary>
        /// <param name="node">The Post node.</param>
        public abstract void Visit(Post node);
    }
}
