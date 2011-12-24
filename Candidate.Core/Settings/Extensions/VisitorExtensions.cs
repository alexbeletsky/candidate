using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Settings.Extensions
{
    public static class VisitorExtensions
    {
        public static void Visit(this VisualStudioConfiguration self, ConfigurationNodeVisitor visitor)
        {
            if (self == null)
            {
                throw new ArgumentNullException("SiteConfiguration");
            }

            self.Github.Visit(visitor);
            self.Solution.Visit(visitor);
            self.Iis.Visit(visitor);
            self.Pre.Visit(visitor);
            self.Post.Visit(visitor);
        }

        static void Visit(this Pre self, ConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }
        }

        static void Visit(this Github self, ConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }

        }

        static void Visit(this Solution self, ConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }
        }

        static void Visit(this Iis self, ConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }
        }

        static void Visit(this Post self, ConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }
        }
    }
}
