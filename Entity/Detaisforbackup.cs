using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Detaisforbackup
    {
        public int LastLedgerId { get; set; }
        public string LastLedgerEntryOn { get; set; }
        public int LastTransactionId { get; set; }
        public string LastTransactionEntryOn { get; set; }
    }
}
