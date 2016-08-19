using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5W2.M5W2.PO.Panels
{
    class SentMailListPanel
    {
        private const string rowTemplate = "//tr[contains(@class,'zA')]//span[@email='{0}']/../../..//*[text()='{1}']";

    }
}
