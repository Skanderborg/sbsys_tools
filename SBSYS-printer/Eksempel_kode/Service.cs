using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SbsysPrinter
{
    public class Service
    {
        /// <summary>
        /// Opretter XML til SBSYS drop folder.
        /// string.empty, giver bedre xml kode
        /// </summary>
        /// <author>Jacob Hansen - Skanderborg Kommune</author>
        /// <param name="filename"></param>
        public void CreateXmlDocument(string filename)
        {
            string navnStr = filename;
            string cprNummerStr = "";
            string verbStr = "JournaliserFiler";

            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement sbsysDropFileElm = doc.CreateElement(string.Empty, "SbsysDropFile", string.Empty);
            doc.AppendChild(sbsysDropFileElm);

            XmlElement commandElm = doc.CreateElement(string.Empty, "Command", string.Empty);

            //attributter
            XmlAttribute navnAtb = doc.CreateAttribute("Navn");
            navnAtb.Value = navnStr;
            commandElm.Attributes.Append(navnAtb);

            XmlAttribute cprNummerAtb = doc.CreateAttribute("CprNummer");
            cprNummerAtb.Value = cprNummerStr;
            commandElm.Attributes.Append(cprNummerAtb);

            XmlAttribute verbAtb = doc.CreateAttribute("Verb");
            verbAtb.Value = verbStr;
            commandElm.Attributes.Append(verbAtb);

            sbsysDropFileElm.AppendChild(commandElm);

            XmlElement filElm = doc.CreateElement(string.Empty, "Fil", string.Empty);

            XmlAttribute filAtb = doc.CreateAttribute("Sti");
            filAtb.Value = filename +".PDF";
            filElm.Attributes.Append(filAtb);

            commandElm.AppendChild(filElm);
            //System.IO.TextWriter test = System.IO.File.CreateText("c:\\Work\\test.txt");
            //test.WriteLine(filename);
            //test.Close();

            // stil til de lokalebrugeres sbsys folder
            //doc.Save("P:\\SBSys\\DropFolder\\" + filename + ".xml");

            doc.Save("H:\\Sbsys\\Drop\\" + filename + ".xml");
        }

        public string GetFileNameWithoutFileextension(string filename)
        {
            int start = filename.LastIndexOf('\\') + 1;
            int stop = filename.Length - 4 - start;
            return filename.Substring(start, stop);
        }
    }
}
