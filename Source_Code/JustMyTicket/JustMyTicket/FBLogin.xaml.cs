using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using System.Net.Browser;
using System.Windows.Media.Imaging;
namespace JustMyTicket
{
    public partial class FBLogin : PhoneApplicationPage
    {
        public string AccessToken { get; set; }
        public string UserProfile { get; set; }
        App thisApp = Application.Current as App;
        
        public string Key = "440354016116049";
        public string Secret = "c0d56e8d2047b11b3bf18a375e61c02f";

        [DataContract]
        public class FacebookUserProfile
        {

            [DataMember(Name = "name")]
            public string Name { get; set; }



            [DataMember(Name = "picture")]
            public FacebookImageData FacebookUserImage { get; set; }


            [DataContract]
            public class FacebookImageData
            {
                [DataMember(Name = "data")]
                public FacebookImageUrl imageData { get; set; }
            }

            [DataContract]
            public class FacebookImageUrl
            {
                [DataMember(Name = "url")]
                public string imageUrl { get; set; }
            }
        }


        public FBLogin()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(FB_LoginPage_Loaded); //load facebook login page 
        }
        //load facebook login page 
        void FB_LoginPage_Loaded(object sender, RoutedEventArgs e)
        {

            var url = "https://www.facebook.com/dialog/oauth?client_id=440354016116049&redirect_uri=https://www.facebook.com/connect/login_success.html&scope=email,user_location,friends_location,user_hometown,friends_hometown,publish_stream,offline_access,read_stream,user_status,user_photos,friends_photos,friends_status,user_checkins,friends_checkins,user_events,publish_checkins&display=wap";
            //var url = "https://www.facebook.com/dialog/oauth?client_id="+Key+"&redirect_uri=https://www.facebook.com/connect/login_success.html&scope=email,user_location,friends_location,user_hometown,friends_hometown,publish_stream,offline_access,read_stream,user_status,user_photos,friends_photos,friends_status,user_checkins,friends_checkins,user_events,publish_checkins&display=wap";
            webBrowser1.Navigate(new Uri(url));
        }

        //get web browser response  
        private void BrowserNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            
           if (e.Uri.IsAbsoluteUri)
            {
                string code = e.Uri.Query.ToString();

                string[] split = code.Split(new Char[] { '=' });

                string codeString = split.GetValue(0).ToString();
                string codeValue = split.GetValue(1).ToString();
                if (codeValue.Length > 0)
                {
                    //var url = "https://graph.facebook.com/oauth/access_token?client_id=<Your Key>&redirect_uri=https://www.facebook.com/connect/login_success.html&client_secret=<Your Secret>&code=" + codeValue;
                    var url = "https://graph.facebook.com/oauth/access_token?client_id=" + Key + "&redirect_uri=https://www.facebook.com/connect/login_success.html&client_secret=" +Secret+ "&code=" + codeValue;
                  
                    //call access token
                    WebRequest request = WebRequest.Create(url); //FB access token  Link
                    request.BeginGetResponse(new AsyncCallback(this.ResponseCallback_AccessToken), request);
                    
                }
               
            }
            else
                return;

        }
        private void ResponseCallback_AccessToken(IAsyncResult asynchronousResult)
        {

            try
            {
                var request = (HttpWebRequest)asynchronousResult.AsyncState;

                using (var resp = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
                {
                    using (var streamResponse = resp.GetResponseStream())
                    {
                        using (var streamRead = new StreamReader(streamResponse))
                        {
                            string responseString = streamRead.ReadToEnd();
                            // MessageBox.Show(responseString);
                            string[] splitAccessToken = responseString.Split(new Char[] { '=', '&' });

                            string accessTokenString = splitAccessToken.GetValue(0).ToString();
                            string accessTokenValue = splitAccessToken.GetValue(1).ToString();
                            string accessTokenValueTemp = splitAccessToken.GetValue(2).ToString();
                            if (accessTokenString == "access_token")
                            {
                                AccessToken = accessTokenValue;

                            }


                            // do something with responseString to check if login was successful
                        }
                    }
                }
            }
            catch (WebException ex)
            {

            }


            GetAccessToken();

        }


        void GetAccessToken()
        {

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {

                if (string.IsNullOrEmpty(AccessToken))
                {
                  //  MessageBox.Show("AccessToken not valid");
                }
                else
                {
                  //  MessageBox.Show("AccessToken= " + AccessToken);
                   
                    LoadUserProfile();
                }
            });


        }

        void LoadUserProfile()
        {
            var urlProfile = "https://graph.facebook.com/me?fields=name,picture&access_token=" + AccessToken;
            //call access token
            WebRequest request = WebRequest.Create(urlProfile); //FB access token  Link
            request.BeginGetResponse(new AsyncCallback(this.ResponseCallbackProfile), request);

        }
        private void ResponseCallbackProfile(IAsyncResult asynchronousResult)
        {

            try
            {
                var request = (HttpWebRequest)asynchronousResult.AsyncState;

                using (var resp = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
                {
                    using (var streamResponse = resp.GetResponseStream())
                    {
                        var facebookSerializerData = new DataContractJsonSerializer(typeof(FacebookUserProfile));
                        var facebookProfileData = facebookSerializerData.ReadObject(streamResponse) as FacebookUserProfile;
                        this.Dispatcher.BeginInvoke(
                            (Action<FacebookUserProfile>)((facebookUserData) =>
                            {

                                thisApp.UserName = facebookUserData.Name;
                                thisApp.UserImage = facebookUserData.FacebookUserImage.imageData.imageUrl;
                               
                                NavigationService.GoBack();


                            }), facebookProfileData);

                        }
                }
            }
            catch (WebException ex)
            {

            }

        }
    }
}