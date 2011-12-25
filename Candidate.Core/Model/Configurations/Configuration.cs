namespace Candidate.Core.Model.Configurations
{
    public abstract class Configuration
    {
        public string Id { get; set; }
        public string ReadableName { get; set; }

        public abstract string Type { get; }
        public abstract string ViewName { get; }
    }
}