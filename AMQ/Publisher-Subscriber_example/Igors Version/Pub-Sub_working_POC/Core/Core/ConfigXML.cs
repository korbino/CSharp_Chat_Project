using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Core;


namespace useRSA
{
   public class ConfigXML
    {
        private string xmlPath= @"D:\C_sharp_advanced\AMQ\SourceCode\Pub-Sub_working_POC\Core\Core\ConfigFile\test.xml";

        //public ConfigXML() { }
      /*  public ConfigXML(string xmlPath)
        {
            this.xmlPath = xmlPath;
        }   */
        /// <summary>
        /// This method returns Database connection string
        /// </summary>
        /// <param name="xmlFilename">Path to config XML</param>
        /// <returns>Connection string</returns>
        public string OpenXmlConnectionString(string xmlPath)
        {
            string dbdetails = string.Empty;
            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.Load(xmlPath);
            }
            catch (Exception ex)
            {
                
                return dbdetails;
            }

            XmlNodeList dbdetailsxml = xmlDocument.GetElementsByTagName("DBpath");
            
            for (int i = 0; i < dbdetailsxml.Count; ++i)
            {

                dbdetails = dbdetailsxml[i].InnerText;

            }

           return dbdetails;
            
        }


        /// <summary>
        /// This method returns path to PublicKey
        /// </summary>
        /// <param name="xmlFilename">Path to config XML</param>
        /// <returns>Path to PublicKey</returns>

        public string OpenXmlPublicKeyPath(string xmlPath)
        {
            string PublicKeyPath = string.Empty;

            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.Load(xmlPath);
            }
            catch (Exception ex)
            {

                return PublicKeyPath;
            }

            XmlNodeList dbdetailsxml = xmlDocument.GetElementsByTagName("PublicKeyPath");

            for (int i = 0; i < dbdetailsxml.Count; ++i)
            {

                PublicKeyPath = dbdetailsxml[i].InnerText;

            }

            return PublicKeyPath;
        }

        /// <summary>
        /// THis method returns link to ActiveMQ Broker
        /// </summary>
        /// <param name="xmlFilename">Path to config XML</param>
        /// <returns>Link to Broker</returns>
        public string ActiveMqBrokerLink()
        {
            string BrokerLink = string.Empty;

            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.Load(xmlPath);
            }
            catch (Exception ex)
            {

                return BrokerLink;
            }

            XmlNodeList dbdetailsxml = xmlDocument.GetElementsByTagName("ActiveMqBroker");

            for (int i = 0; i < dbdetailsxml.Count; ++i)
            {

                BrokerLink = dbdetailsxml[i].InnerText;

            }

            return BrokerLink;
        }

    }

}
