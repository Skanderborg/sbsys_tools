using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SbsysXmlLibrary
{
	/// <summary>
	/// Skanderborg Kommune - oprettelse af SBSYS venlig XML ud fra filnavn generet af QR kode i Pixedit.
	/// <author>Jacob Hansen</author>
	/// </summary>
    public class SbsysXmlService
    {


        /// <summary>
        /// Opretter og returnerer et XmlDocument indeholdende data som kan bruges i SBSYS proscan dropfolder.
        /// 
        /// @filenameWithoutExtension bliver til PID:POSTASSEID eller UID:USER i GetRecipiantId, men burde egentligt bare være korrekt modtager fra start.
        /// </summary>
        /// <auther>Skanderborg Kommune - Jacob Hansen</auther>
        /// <param name="filenameWithoutExtension">Filename + UID/PID + Postkassenavn/brugernavn</param>
        /// <returns></returns>
        public XmlDocument GetSbsysXmlDocument(string filenameWithoutExtension)
        {
            string recipient = GetRecipiantId(filenameWithoutExtension);

            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //string.Empty giver bedre kode
            
            //Batch element
            XmlElement xeBatch = doc.CreateElement(string.Empty, "Batch", string.Empty);
            doc.AppendChild(xeBatch);

            //Batch property
            XmlElement xeProperty = doc.CreateElement(string.Empty, "Property", string.Empty);

            // xml fil navn
            XmlAttribute xaValue = doc.CreateAttribute("Value");
            xaValue.Value = filenameWithoutExtension +".XML";   
            xeProperty.Attributes.Append(xaValue);

            XmlAttribute xaType = doc.CreateAttribute("Type");
            xaType.Value = "2";
            xeProperty.Attributes.Append(xaType);

            XmlAttribute xaName = doc.CreateAttribute("Name");
            xaName.Value = "PROSCANBAR";
            xeProperty.Attributes.Append(xaName);

            xeBatch.AppendChild(xeProperty);

            //document element
            XmlElement xeDocument = doc.CreateElement(string.Empty, "Document", string.Empty);

            XmlAttribute xaDocName = doc.CreateAttribute("Name");
            xaDocName.Value = "DOC1";
            xeDocument.Attributes.Append(xaDocName);

            xeBatch.AppendChild(xeDocument);

            //document property1 <- PROSCANBAR
            XmlElement xeProperty1 = doc.CreateElement(string.Empty, "Property", string.Empty);

            // recipient
            XmlAttribute xaValue1 = doc.CreateAttribute("Value");
            xaValue1.Value = recipient;                                                              
            xeProperty1.Attributes.Append(xaValue1);

            XmlAttribute xaType1 = doc.CreateAttribute("Type");
            xaType1.Value = "2";
            xeProperty1.Attributes.Append(xaType1);

            XmlAttribute xaName1 = doc.CreateAttribute("Name");
            xaName1.Value = "PROSCANBAR";
            xeProperty1.Attributes.Append(xaName1);

            xeDocument.AppendChild(xeProperty1);

            //document property2 <- PROSCAN_BARCODECOUNT <- WAT?
            XmlElement xeProperty2 = doc.CreateElement(string.Empty, "Property", string.Empty);

            XmlAttribute xaValue2 = doc.CreateAttribute("Value");
            xaValue2.Value = "2";
            xeProperty2.Attributes.Append(xaValue2);

            XmlAttribute xaType2 = doc.CreateAttribute("Type");
            xaType2.Value = "1";
            xeProperty2.Attributes.Append(xaType2);

            XmlAttribute xaName2 = doc.CreateAttribute("Name");
            xaName2.Value = "PROSCAN_BARCODECOUNT";
            xeProperty2.Attributes.Append(xaName2);

            xeDocument.AppendChild(xeProperty2);

            //document property3 <- DocNoInBatch
            XmlElement xeProperty3 = doc.CreateElement(string.Empty, "Property", string.Empty);

            XmlAttribute xaValue3 = doc.CreateAttribute("Value");
            xaValue3.Value = "1";
            xeProperty3.Attributes.Append(xaValue3);

            XmlAttribute xaType3 = doc.CreateAttribute("Type");
            xaType3.Value = "2";
            xeProperty3.Attributes.Append(xaType3);

            XmlAttribute xaName3 = doc.CreateAttribute("Name");
            xaName3.Value = "DocNoInBatch";
            xeProperty3.Attributes.Append(xaName3);

            xeDocument.AppendChild(xeProperty3);

            //file element
            XmlElement xeFile = doc.CreateElement(string.Empty, "File", string.Empty);

            // DOC FIL NAVN
            XmlAttribute xaFileName = doc.CreateAttribute("Name");
            xaFileName.Value = filenameWithoutExtension + ".PDF";                                                           
            xeFile.Attributes.Append(xaFileName);

            xeDocument.AppendChild(xeFile);

            //file property 1 <- FileName
            XmlElement xeFileProperty1 = doc.CreateElement(string.Empty, "Property", string.Empty);

            // DOC FILNAVN
            XmlAttribute xaFileValue1 = doc.CreateAttribute("Value");
            xaFileValue1.Value = filenameWithoutExtension + ".PDF"; 
            xeFileProperty1.Attributes.Append(xaFileValue1);

            XmlAttribute xaFileType1 = doc.CreateAttribute("Type");
            xaFileType1.Value = "2";
            xeFileProperty1.Attributes.Append(xaFileType1);

            XmlAttribute xaFileName1 = doc.CreateAttribute("Name");
            xaFileName1.Value = "FileName";
            xeFileProperty1.Attributes.Append(xaFileName1);

            xeFile.AppendChild(xeFileProperty1);

            //file property 2 <- FileType
            XmlElement xeFileProperty2 = doc.CreateElement(string.Empty, "Property", string.Empty);

            // FILETYPE
            XmlAttribute xaFileValue2 = doc.CreateAttribute("Value");
            xaFileValue2.Value = "PDF";                                                                                
            xeFileProperty2.Attributes.Append(xaFileValue2);

            XmlAttribute xaFileType2 = doc.CreateAttribute("Type");
            xaFileType2.Value = "1";
            xeFileProperty2.Attributes.Append(xaFileType2);

            XmlAttribute xaFileName2 = doc.CreateAttribute("Name");
            xaFileName2.Value = "FileType";
            xeFileProperty2.Attributes.Append(xaFileName2);

            xeFile.AppendChild(xeFileProperty2);

            //file property 3 <- Pages
            XmlElement xeFileProperty3 = doc.CreateElement(string.Empty, "Property", string.Empty);

            XmlAttribute xaFileValue3 = doc.CreateAttribute("Value");
            xaFileValue3.Value = "1";
            xeFileProperty3.Attributes.Append(xaFileValue3);

            XmlAttribute xaFileType3 = doc.CreateAttribute("Type");
            xaFileType3.Value = "1";
            xeFileProperty3.Attributes.Append(xaFileType3);

            XmlAttribute xaFileName3 = doc.CreateAttribute("Name");
            xaFileName3.Value = "Pages";
            xeFileProperty3.Attributes.Append(xaFileName3);

            xeFile.AppendChild(xeFileProperty3);

            //file property 4 <- 
            XmlElement xeFileProperty4 = doc.CreateElement(string.Empty, "Property", string.Empty);

            XmlAttribute xaFileValue4 = doc.CreateAttribute("Value");
            xaFileValue4.Value = "1";
            xeFileProperty4.Attributes.Append(xaFileValue4);

            XmlAttribute xaFileType4 = doc.CreateAttribute("Type");
            xaFileType4.Value = "1";
            xeFileProperty4.Attributes.Append(xaFileType4);

            XmlAttribute xaFileName4 = doc.CreateAttribute("Name");
            xaFileName4.Value = "Sheets";
            xeFileProperty4.Attributes.Append(xaFileName4);

            xeFile.AppendChild(xeFileProperty4);
            return doc;
        }

        private string GetRecipiantId(string  filenameWithoutExtension)
        {
            int typeStop = filenameWithoutExtension.IndexOf(" ");
            string strType = filenameWithoutExtension.Substring(0, typeStop);

            int idLength = filenameWithoutExtension.Length - typeStop - 1;
            string strId = filenameWithoutExtension.Substring(typeStop + 1, idLength);

            int idStop = strId.IndexOf("_");

            strId = strId.Remove(idStop);

            return strType + ":" + strId;
        }
    }
}
