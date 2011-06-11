using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Crawler.Core.Domain;
using System.Data.Entity.Infrastructure;

namespace Crawler.Core
{
    public interface ICrawlerRepository
    {
        Database Database { get; } 

        void Add(TddDemandRecord record);
        void Delete(TddDemandRecord record);

        IEnumerable<TddDemandRecord> GetBySiteName(string site);
        IEnumerable<TddDemandRecord> GetByCompanyName(string companyName);
        
        
        void SaveChanges();
    }
}
