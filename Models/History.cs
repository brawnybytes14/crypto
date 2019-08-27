using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto.Models
{
    public class History
    {
        public Guid Id { get; set; }
        public string FileTitle { get; set; }
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public int OperationType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
