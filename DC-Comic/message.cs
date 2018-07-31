//using System;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Types;
//using Twilio;

//namespace DC_Comic
//{
//    public class message
//    {
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                TwilioClient.Init(
//                    Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID"),
//                    Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN"));
//                MessageResource.Create(
//    to: new PhoneNumber("+353899516950"),
//    from: new PhoneNumber("+353766205643"),
//    body: "Ahoy from Twilio!");

//            }
//        }
//    }
//}