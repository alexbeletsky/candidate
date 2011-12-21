using Bounce.Framework;

namespace Candidate.Core.Setup
{
    public class SetupFactory : ISetupFactory
    {
        private ITargetsObjectBuilder _targetsObjectBuilder;
        private ITargetsBuilder _targetsBuilder;
        private IBounceFactory _bounceFactory;

        public SetupFactory(ITargetsObjectBuilder targetsObjectBuilder, ITargetsBuilder targetsBuilder, IBounceFactory bounceFactory)
        {
            _targetsObjectBuilder = targetsObjectBuilder;
            _targetsBuilder = targetsBuilder;
            _bounceFactory = bounceFactory;
        }

        public ISetup CreateSetup()
        {
            return new DefaultSetup(_targetsObjectBuilder, _targetsBuilder, _bounceFactory);
        }
    }
}
