using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Settings.Extensions
{
    public static class VisitorExtensions
    {
        public static void Visit(this SiteConfiguration self, SiteConfigurationNodeVisitor visitor)
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

        static void Visit(this Pre self, SiteConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }
        }

        static void Visit(this GitHub self, SiteConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }

        }

        static void Visit(this Solution self, SiteConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }
        }

        static void Visit(this Iis self, SiteConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }
        }

        static void Visit(this Post self, SiteConfigurationNodeVisitor visitor)
        {
            if (self != null)
            {
                visitor.Visit(self);
            }
        }
    }
}
