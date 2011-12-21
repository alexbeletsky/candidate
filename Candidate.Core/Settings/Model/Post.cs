using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Candidate.Core.Settings.Model
{
    public class Post
    {
        /// <summary>
        /// Accepts the specified node visitor and passes control to it
        /// </summary>
        /// <param name="nodeVisitor">The node visitor.</param>
        public void Accept(SiteConfigurationNodeVisitor nodeVisitor)
        {
            nodeVisitor.Visit(this);
        }

        [Required]
        [DisplayName("Post batch")]
        public string PostBatch { get; set; }
    }
}
