using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPadSplitView.Core.Model;

namespace iPadSplitView.Core.Message
{
    /// <summary>
    /// This Message is sent from the MasterView to let the VM of the DetailView know, which Person to display.
    /// </summary>
    public class PrepareDetailViewMessage
    {
        public int SelectedIndexWas { get; set; }
    }
}
