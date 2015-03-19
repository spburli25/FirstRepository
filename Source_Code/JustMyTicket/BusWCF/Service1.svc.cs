using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using System.Xml.Linq;
namespace BusWCF
{
    
    public class Service1 : IService1
    {
        Bus_DetailsDataContext busObject = new Bus_DetailsDataContext();
        static List<Bus> resultBus = new List<Bus>();
        static List<string> resultBus_No = new List<string>();
        static string[] buses;
        REGISTER User = new REGISTER();
        public string User_Register(REGISTER newUser)
        {
            try
            {
                //REGISTER userObj = (REGISTER)newUser;
                busObject.REGISTERs.InsertOnSubmit(newUser);
                busObject.SubmitChanges();
                return "Success !";
            }
            catch (Exception)
            {
                return "Failed !";
            }
        }
        public bool login(string userEmail, string password)
        {
            try
            {
                var result = from temp in busObject.REGISTERs
                             where temp.Email_ID==userEmail && temp.Password ==password
                             select temp;
                return Enumerable.Count(result) > 0;
                //User = (REGISTER)result;

               // return User.Email_ID.ToString();
            }
            catch (Exception)
            {
                return false;
            }
        }
        //public string Money_Transfer(string em_ID, int amount)
        //{
        //    try
        //    {
        //        busObject.usp_UpdateDetails(Convert.ToInt32(amount), em_ID);
        //        busObject.usp_UpdateDetailsTransaction(Convert.ToInt32(amount), em_ID);
        //        return amount.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
        //public REGISTER Current_Balance(string email)
        //{
        //    var balance = from temp in busObject.REGISTERs where temp.Email_ID.Equals(email) select temp;
        //    User = (REGISTER)balance;
        //    return User;
        //}
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
        //public bool payMoney(string email, int money)
        //{
        //    busObject.usp_UpdateDetails(money,email);
        //    busObject.SubmitChanges();
        //    return true;
        //}

        //public string BusDetails(string from, string to)
        //{
        //    string basrul = "http://www.bbus.in/api/v1/search/?from=Attibele&to=Bommanahalli&how=Maximum%20Bus%20Route%20Availability";
        //    basrul = "http://www.bbus.in/api/v1/search/?from=" + from + "&to=" + to + "&how=Maximum%20Bus%20Route%20Availability";
        //    string location = string.Empty;
        //    string requestUri = string.Format(basrul);
        //    String result = String.Empty;

        //    BusNumber obj1 = null;
        //    using (WebClient wc = new WebClient())
        //    {

        //        obj1 = new BusNumber();
        //        result = wc.DownloadString(requestUri);
        //    };
        //    result = result.Replace("\"route1\": [{", String.Empty);
        //    result = result.Replace("}]", String.Empty);
        //    obj1 = JsonDeserialize<BusNumber>(result);
        //    return obj1.distance + "*" + obj1.duration + "*" + obj1.bus_nos;
        //    //return obj1.distance;

        //}
             
        public string RetrieveFormatedAddress(string lat, string lng)
        {
            string baseUri = "http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";
            string location = string.Empty;
            string requestUri = string.Format(baseUri, lat, lng);

            using (WebClient wc = new WebClient())
            {
                string result = wc.DownloadString(requestUri);
                var xmlElm = XElement.Parse(result);
                var status = (from elm in xmlElm.Descendants()
                              where
                                  elm.Name == "status"
                              select elm).FirstOrDefault();
                if (status.Value.ToLower() == "ok")
                {
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
                    return "fail";
            }
            
        }

        public List<Bus> BusRoute(string source, string destination)
        {
            resultBus.Clear();
            var Result = from a in busObject.Bus_Routes where (a.Source.Contains(source)) && (a.Destination.Contains(destination)) select a;
            //var Result =from a in busObject.Bus_Routes where (a.Source.Equals(source)) && (a.Destination.Equals(destination)) select a;
            foreach (Bus_Route item in Result)
            {
                Bus temp = new Bus {Bus_No=item.Bus_No,Distance=item.Distance,Source=item.Source,Destination=item.Destination,Mappath=item.Map_Path,Duration=item.Duration};
                resultBus.Add(temp);
            }
            return resultBus;
        }

        public String[] BusRoute1(string source, string destination)
        {
            var Result = from a in busObject.Bus_Routes where (a.Source.Contains(source)) && (a.Destination.Contains(destination)) select a.Bus_No;
            //var Result =from a in busObject.Bus_Routes where (a.Source.Equals(source)) && (a.Destination.Equals(destination)) select a;
            foreach (string item in Result)
            {
                //Bus temp = new Bus { Bus_No = item.Bus_No, Distance = item.Distance, Source = item.Source, Destination = item.Distance, Mappath = item.Map_Path, Duration = item.Duration };
                //resultBus.Add(item);
                resultBus_No.Add(item.ToString());
            }
            buses= resultBus_No.ToArray();
            return buses;
        }

    }
    
}
