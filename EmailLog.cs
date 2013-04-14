using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHarness
{
    public static class EmailLog
    {
        public static void send()
        {
            string fileText = File.ReadAllText(Globals.Instance.fileName);

            Mail.send(fileText);
        }

    }
}
