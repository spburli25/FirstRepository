using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.IO;

//using Loc_verify;

namespace WcfService1_Location
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        static string baseUri =
    //"http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";
   "https://maps.googleapis.com/maps/api/directions/xml?origin=Toronto&destination=Montreal&key=AIzaSyAfuoZsWNKU31lgXKvyo9MLXDIKwNgTXms";
   //"https://maps.googleapis.com/maps/api/directions/json?origin=Toledo&destination=Madrid&region=es&key=AIzaSyBEybMd4yKnut_xnXHuu8_y6X1YRC-ybHE";
   public string RetrieveFormatedAddress(string lat, string lng)
        {
            string location = string.Empty;
            string requestUri = string.Format(baseUri);

            using (WebClient wc = new WebClient())
            {
                string result = wc.DownloadString(requestUri);
                var xmlElm = XElement.Parse(result);
                var status = (from elm in xmlElm.Descendants()
                              where
                                  elm.Name == "status"
                              select elm).FirstOrDefault();

                var status1 = (from elm in xmlElm.Descendants()
                              where
                                  elm.Name == "travel_mode"
                              select elm).FirstOrDefault();

                if (status.Value.ToLower() == "ZERO_RESULTS")
                {
                    //var res = (from elm in xmlElm.Elements("address_component").Descendants()
                    //           where
                    //               elm.Element("type").Value=="locality" && elm.Element("long_name").Value==
                    //           select elm).FirstOrDefault();
                    //return requestUri = res.Value;
                    var addressComponents = xmlElm.Element("result").Elements("address_component");

                    foreach (var component in addressComponents)
                    {
                        var longName = component.Element("long_name").Value;
                        var shortName = component.Element("short_name").Value;
                        var types = new List<string>();

                        foreach (var type in component.Elements("type"))
                            types.Add(type.Value);
                        if (types.Contains("sublocality_level_1"))
                        {
                            return longName;
                        }
                        else if (types.Contains("locality"))
                        {
                            return longName;

                        }
                    }
                    return "No locality";
                }
                else
                    return status.Value;
            }
        }

   public static string JsonSerializer<T>(T t)
   {
       DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
       MemoryStream ms = new MemoryStream();
       ser.WriteObject(ms, t);
       string jsonString = Encoding.UTF8.GetString(ms.ToArray());
       ms.Close();
       return jsonString;
   }
   /// <summary>
   /// JSON Deserialization
   /// </summary>
   public static T JsonDeserialize<T>(string jsonString)
   {
       DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
       MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
       T obj = (T)ser.ReadObject(ms);
       return obj;
   }

   public string BusNumberInfo(string from, string to)
   {
      string basrul = "http://www.bbus.in/api/v1/search/?from=Attibele&to=Bommanahalli&how=Maximum%20Bus%20Route%20Availability";
       basrul = "http://www.bbus.in/api/v1/search/?from=" + from + "&to=" + to + "&how=Maximum%20Bus%20Route%20Availability";
       string location = string.Empty;
       string requestUri = string.Format(basrul);
       String result = String.Empty;
       Bus obj;
       BusNumber obj1;
       using(WebClient wc = new WebClient())
       {
             obj = new Bus();
             obj1 = new BusNumber();
           result = wc.DownloadString(requestUri);
           // obj.name = "Abhi";
            //obj.number = 10;
           //result = JsonSerializer<Bus>(obj);
           //result = "{\"name\":"Tom","number":100}";

            //result = "{\"route1\": [{\"From\": \"Attibele\", \"Hop\": \"1\", \"To\": \"Bommanahalli\", \"duration\": \"2 hours 11 mins\", \"distance\": \"45.1 km\", \"bus_nos\": \"360, 360A, 360B, 360C, 360D, 360E, 360F, 360G, 360H, 360J, 360K, 360L, 360M, 360N, 360P, 360Q, 360S, 373M, 399B, 600F, 601, KBS3A, V360B, V600B\"}]}";
           // result=result.Remove(6);
          // obj1 = JsonDeserialize<BusNumber>(result);
           
       };
       //result = "{\"route1\": [{\"From\": \"Attibele\", \"Hop\": \"1\", \"To\": \"Bommanahalli\", \"duration\": \"2 hours 11 mins\", \"distance\": \"45.1 km\", \"bus_nos\": \"360, 360A, 360B, 360C, 360D, 360E, 360F, 360G, 360H, 360J, 360K, 360L, 360M, 360N, 360P, 360Q, 360S, 373M, 399B, 600F, 601, KBS3A, V360B, V600B\"}]}";
       //result = result.Skip(6);
       result = result.Replace("\"route1\": [{", String.Empty);
       result = result.Replace("}]",String.Empty);
       obj1 = JsonDeserialize<BusNumber>(result);
       return obj1.distance+"*"+obj1.duration+"*"+obj1.bus_nos;
   
   }
   public string BusNumberDetails()
   {
       string basrul = "http://www.bbus.in/api/v1/search/?from=Attibele&to=Bommanahalli&how=Maximum%20Bus%20Route%20Availability";
       string location = string.Empty;
       string requestUri = string.Format(basrul);
       String result = String.Empty;
       Bus obj;
       BusNumber obj1;
       using(WebClient wc = new WebClient())
       {
             obj = new Bus();
             obj1 = new BusNumber();
             result = wc.DownloadString(requestUri);          
       };
       result = result.Replace("\"route1\": [{", String.Empty);
       result = result.Replace("}]",String.Empty);
       obj1 = JsonDeserialize<BusNumber>(result);
       return obj1.distance+" "+obj1.duration+" "+obj1.bus_nos;
   }
    }
}
