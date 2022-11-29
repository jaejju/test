using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace TIS.ERP.POPUP
{
    public static class PUEL
    {
       
        public static string CalculateDistance(string start, string goal)
        {
            string distance = "";
            string fuelPrice = "";
            //int divk = 1000;
            //int divD;

                try
                {
            
                string url = string.Format("https://naveropenapi.apigw.ntruss.com/map-direction/v1/driving?start={0}&goal={1}&option=trafast&fueltype=gasoline&mileage=9", start, goal);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("X-NCP-APIGW-API-KEY-ID", "6oyp7bu4n7");
                    request.Headers.Add("X-NCP-APIGW-API-KEY", "EhsNFYicyJERLPfYaytpzGKAd6IGluPmJhD2XgNf");


                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string res = reader.ReadToEnd();
                        JObject jObject = new JObject();
                        jObject = JObject.Parse(res);
                    try
                    {
                        distance = jObject["route"]["trafast"][0]["summary"]["distance"].ToString();
                        fuelPrice = jObject["route"]["trafast"][0]["summary"]["fuelPrice"].ToString();

                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                 

                }

            }
                catch (Exception ex)
                {
                    fuelPrice = ex.Message;
                }
            //divD = Convert.ToInt32(distance);

           // MessageBox.Show("거리 :" + String.Format("{0:N1}", ((double)divD / (double)divk)) + "," + "유류비 :" + fuelPrice);



            return fuelPrice;

        }

        }

}

