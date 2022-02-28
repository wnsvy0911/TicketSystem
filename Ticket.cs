using System;
using System.IO;
using System.Collections.Generic;

namespace TicketSystem
{
    class Ticket
    {
        int ticketId {get; set;}
        public string summary {get; set;}        
        Status status;
        Priority priority;
        public string submitter {get; set;}
        public string assigned {get; set;}
        List<string> watching {get; set;}

        Ticket(int ticketId, string summary, Status status, Priority priority, string submitter, string assigned, List<string> watchers) {
            this.ticketId = ticketId;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigned = assigned;
            this.watching = watching;
        }
    }
} 