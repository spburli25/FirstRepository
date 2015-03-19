using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BusWCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string RetrieveFormatedAddress(string lat, string lng);
        //[OperationContract]
        //string BusDetails(string from, string to);
        [OperationContract]
        List<Bus> BusRoute(string source, string destination);
        [OperationContract]
        String[] BusRoute1(string source, string destination);
        [OperationContract]
        string User_Register(REGISTER newUser);
        [OperationContract]
        bool login(string userEmail, string password);
        //[OperationContract]
        //string Money_Transfer(string em_ID, int amount);
        //[OperationContract]
        //REGISTER Current_Balance(string email);
        //[OperationContract]
        //bool payMoney(string email,int money);
       
    }
        
        [DataContract]
        public class Bus
        {
            string bus_No;
            string source;
            string destination;
            string distance;
            string duration;
            string mappath;
            [DataMember]
            public string Bus_No
            {
                get { return bus_No; }
                set { bus_No = value; }
            }
            [DataMember]
            public string Source
            {
                get { return source; }
                set { source = value; }
            }
            [DataMember]
            public string Destination
            {
                get { return destination; }
                set { destination = value; }
            }
            [DataMember]
            public string Distance
            {
                get { return distance; }
                set { distance = value; }
            }
            [DataMember]
            public string Duration
            {
                get { return duration; }
                set { duration = value; }
            }
            [DataMember]
            public string Mappath
            {
                get { return mappath; }
                set { mappath = value; }
            }
            
        }
        [DataContract]
        public class User
        {
            string email;
            string name;
            string password;
            string phone_no;
            int bus_money;
            [DataMember]
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            [DataMember]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            [DataMember]
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            [DataMember]
            public string Phone_No
            {
                get { return phone_no; }
                set { phone_no = value; }
            }
            [DataMember]
            public int Bus_Money
            {
                get { return bus_money; }
                set { bus_money = value; }
            }
        }
}
