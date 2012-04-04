using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BookResearcher
{
    public abstract class Search
    {
        public int TotalRequests;
        public int CurrentRequest;
        public String Error;

        public virtual CsvTable CreateTable(BackgroundWorker worker)
        {
            return null;
        }
    }
}
