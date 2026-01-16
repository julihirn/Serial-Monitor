using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public class MonitorObject {
        public MonitorObject(Guid ChannelId, string ChannelName, string Name, string Assignment) {
            this.channelId = ChannelId;
            this.channelName = ChannelName;
            this.name = Name;
            this.assignment = Assignment;
        }
        public MonitorObject(Guid ChannelId, string ChannelName, string Name) {
            this.channelId = ChannelId;
            this.channelName = ChannelName;
            this.name = Name;
        }
        MonitorDataType type = MonitorDataType.Actor;
        public MonitorDataType Type {
            get { return type; }
        }
        string channelName = "";
        public string ChannelName {
            get { return channelName; }
            set { channelName = value; }
        }
        string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        Guid channelId;
        public Guid ChannelId {
            get { return channelId; }
        }
        DateTime lastUpdated = DateTime.Now;
        public DateTime LastUpdated {
            get { return lastUpdated; }
        }
        DateTime lastChanged = DateTime.Now;
        public DateTime LastChanged {
            get { return lastChanged; }
        }
        string assignmentPrevious = "";
        string assignment = "";
        public string AssignmentPrevious {
            get { return assignmentPrevious; }
        }
        public void MatchPreviousAssignment() {
            assignmentPrevious = assignment;
        }
        public string Assignment {
            get { return assignment; }
            set {
                assignmentPrevious = assignment;
                assignment = value;
                if (assignmentPrevious != value) {
                    lastChanged = DateTime.Now;
                }
                lastUpdated = DateTime.Now;
            }
        }
        public bool Equals(MonitorObject? Dobj) {
            if (Dobj == null) { return false; }
            if ((Dobj.Name == this.name) && (Dobj.channelName == this.channelName)) {
                return true;
            }
            return false;
        }
    }
}
