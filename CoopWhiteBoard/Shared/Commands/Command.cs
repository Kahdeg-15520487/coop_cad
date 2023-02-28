using CoopWhiteBoard.Shared.Shapes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopWhiteBoard.Shared.Commands
{
    public class Command
    {
        public string Action { get; set; }
        public Shape Parameter { get; set; }
    }
}
