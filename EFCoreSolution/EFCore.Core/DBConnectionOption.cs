using System.Collections.Generic;

namespace EFCore.Core
{
    public class DBConnectionOption
    {
        public string MainConnection { get; set; }
        public List<string> SlaveConnections { get; set; }
    }
}
