using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Security.Authentication;
namespace Project_shst.Models

{





    public class CanadaPostServic2
    {
        //TLS 1.2 support for .NET 3.5
        public const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
        //       <!-- Replace ChangeMeAK with your USERNAME -->
        //<add key = "username" value="6e93d53968881714" />
        //<!-- Replace ChangeMePW with your PASSWORD -->
        //<add key = "password" value="0bfa9fcb9853d1f51ee57a" />
        //<!-- Replace ChangeMeCN with your Customer Number -->
        //<add key = "customerNumber" value="2004381" />
        public const string PC_USERNAME = "6e93d53968881714";
        public const string PC_PASSWORD = "0bfa9fcb9853d1f51ee57a";
        public const string PC_CUSTOMERNUMBER = "2004381";

        public pricequotes GetPosteCanadaRate(string  sOriginPostalCode, string sDestinationPostalCode, decimal decWeight)
        {
            ServicePointManager.SecurityProtocol = Tls12;

            // Your username, password and customer number are imported from the following file
            // CPCWS_Rating_DotNet_Samples\REST\rating\user.xml 
            var username = PC_USERNAME;
            var password = PC_PASSWORD;
            var mailedBy = PC_CUSTOMERNUMBER;

            var url = "https://ct.soa-gw.canadapost.ca/rs/ship/price"; // REST URL

            var method = "POST"; // HTTP Method
            String responseAsString = ".NET Framework " + Environment.Version.ToString() + "\r\n\r\n";

            // Create mailingScenario object to contain xml request
            mailingscenario mailingScenario = new mailingscenario();
            mailingScenario.parcelcharacteristics = new mailingscenarioParcelcharacteristics();
            mailingScenario.destination = new mailingscenarioDestination();
            mailingscenarioDestinationDomestic destDom = new mailingscenarioDestinationDomestic();
            mailingScenario.destination.Item = destDom;

            // Populate mailingScenario object
            mailingScenario.customernumber = mailedBy;
            mailingScenario.parcelcharacteristics.weight = decWeight;
            mailingScenario.originpostalcode = sOriginPostalCode;
            destDom.postalcode = sDestinationPostalCode;

            try
            {

                // Serialize mailingScenario object to String
                StringBuilder mailingScenarioSb = new StringBuilder();
                XmlWriter mailingScenarioXml = XmlWriter.Create(mailingScenarioSb);
                mailingScenarioXml.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
                XmlSerializer serializerRequest = new XmlSerializer(typeof(mailingscenario));
                serializerRequest.Serialize(mailingScenarioXml, mailingScenario);

                // Create REST Request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;

                // Set Basic Authentication Header using username and password variables
                string auth = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
                request.Headers = new WebHeaderCollection();
                request.Headers.Add("Authorization", auth);

                // Write Post Data to Request
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] buffer = encoding.GetBytes(mailingScenarioSb.ToString());
                request.ContentLength = buffer.Length;
                request.Headers.Add("Accept-Language", "en-CA");
                request.Accept = "application/vnd.cpc.ship.rate-v4+xml";
                request.ContentType = "application/vnd.cpc.ship.rate-v4+xml";
                Stream PostData = request.GetRequestStream();
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Close();

                // Execute REST Request
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Deserialize response to pricequotes object
                XmlSerializer serializer = new XmlSerializer(typeof(pricequotes));
                TextReader reader = new StreamReader(response.GetResponseStream());
                pricequotes priceQuotes = (pricequotes)serializer.Deserialize(reader);

                // Retrieve values from pricequotes object
                //foreach (var priceQuote in priceQuotes.pricequote)
                //{
                //    responseAsString += "Service Name: " + priceQuote.servicename + "\r\n";
                //    responseAsString += "Price Name: $" + priceQuote.pricedetails.due + "\r\n\r\n";
                //}
                return priceQuotes;

            }
            catch (WebException webEx)
            {
                HttpWebResponse response = (HttpWebResponse)webEx.Response;

                if (response != null)
                {
                    responseAsString += "HTTP  Response Status: " + webEx.Message + "\r\n";

                    // Retrieve errors from messages object
                    try
                    {
                        // Deserialize xml response to messages object
                        XmlSerializer serializer = new XmlSerializer(typeof(messages));
                        TextReader reader = new StreamReader(response.GetResponseStream());
                        messages myMessages = (messages)serializer.Deserialize(reader);


                        if (myMessages.message != null)
                        {
                            foreach (var item in myMessages.message)
                            {
                                responseAsString += "Error Code: " + item.code + "\r\n";
                                responseAsString += "Error Msg: " + item.description + "\r\n";
                            }
                            
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        // Misc Exception
                        responseAsString += "ERROR: " + ex.Message;
                    }
                    return null;
                }
                else
                {
                    // Invalid Request
                    responseAsString += "ERROR: " + webEx.Message;
                }

            }
            catch (Exception ex)
            {
                // Misc Exception
                responseAsString += "ERROR: " + ex.Message;
            }

            Console.WriteLine(responseAsString);
            Console.WriteLine("Press any key to continue...");
            return null;

        }
    }
}
   

