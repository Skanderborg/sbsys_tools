using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbsysPrinter
{
    /// <summary>
    /// SBSYS Printer applikation, der modtager filnavn som argument fra NovaPDF OEM, og derefter opretter XML fil til SBSYS dropfolderen.
    /// </summary>
    /// <author>Jacob Hansen - Skanderborg Kommune</author>
    class Program
    {
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            Service service = new Service();

            //args[1] er filnavnet på den PDF NovaPDF har oprettet.
            if (args != null)
                service.CreateXmlDocument(service.GetFileNameWithoutFileextension(args[1]));
                 
        }
    }
}
