using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForBarcodeInternal
{
	/// <summary>
	/// Skanderborg Kommune program til fordeling af post.
	/// <author>Jacob Hansen</author>
	/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            InternalScanService s = new InternalScanService();

            s.ProcessScannedMail(Properties.Settings.Default.DocumentSource);
        }
    }
}
