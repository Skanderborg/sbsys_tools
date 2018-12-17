using SbsysXmlLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TestForBarcode;
using TestForBarcode.DAL;

namespace TestForBarcodeInternal
{
	/// <summary>
	/// Skanderborg Kommune program til fordeling af post.
	/// <author>Jacob Hansen</author>
	/// </summary>
	public class InternalScanService
    {
        private BarcodeService barcodeService = new BarcodeService();
        private SbsysXmlService xmlService = new SbsysXmlService();
        private IRepo<Postfordeling_Lokalscan> repo = new InternalRepo(Properties.Settings.Default.conStr);

        public void ProcessScannedMail(string sourcePath)
        {
            DirectoryInfo info = new DirectoryInfo(sourcePath);
            foreach (FileInfo file in info.GetFiles("*.PDF"))
            {
                try
                {
                    MoveFilesToSbsys(file);
                }
                catch (Exception ex)
                {
                    MailMessage msg = new MailMessage();
                    foreach (string item in Properties.Settings.Default.mail.Split(';'))
                    {
                        msg.To.Add(new MailAddress(item));
                    }
                    msg.From = new MailAddress("noreply@skanderborg.dk", "Intet svar");
                    msg.Subject = "Fejl i import fra internt skanning";
                    msg.Body = ex.StackTrace + " " + ex.Message;

                    SmtpClient client = new SmtpClient(Properties.Settings.Default.smtp);
                    client.Send(msg);
                }
            }
        }

        private void MoveFilesToSbsys(FileInfo document)
        {
            int startIndex = document.Name.IndexOf('_');
            string filename = document.Name.Remove(startIndex) + "_" + DateTime.Now.ToFileTimeUtc().ToString();
            string postkasse = GetPostKasse(filename);

            document.MoveTo(Properties.Settings.Default.SbsysDestination + filename +".PDF");
            xmlService.GetSbsysXmlDocument(filename).Save(Properties.Settings.Default.SbsysDestination + filename + ".XML");

            LogEntry(postkasse);
        }

        private void LogEntry(string postkasse)
        {

            repo.Add(postkasse);
        }


        private string GetPostKasse(string filenameWithoutExtension)
        {
            int strStart = filenameWithoutExtension.IndexOf(" ");
            int idLength = filenameWithoutExtension.Length - strStart - 1;
            string postkasse = filenameWithoutExtension.Substring(strStart + 1, idLength);
            int idStop = postkasse.IndexOf("_");
            postkasse = postkasse.Remove(idStop);
            return postkasse;
        }
    }
}
