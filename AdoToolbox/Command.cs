using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoToolbox
{
    public class Command
    {
        internal string Query { get; private set; }
        internal bool IsStoredProcedure { get; private set; }
        internal Dictionary<string, object> Parameters { get; private set; }

        public Command(string Command, bool isStoredProcedure = false)
        {
            if (string.IsNullOrWhiteSpace(Command)) throw new ArgumentNullException();

            Query = Command;
            IsStoredProcedure = isStoredProcedure;
            Parameters = new Dictionary<string, object>();
        }

        public void AddParameter(string ParameterName, object Value)
        {
            Parameters.Add(ParameterName, Value);
        }
    }
}
