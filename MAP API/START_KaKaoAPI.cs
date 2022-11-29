using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace TIS.ERP.POPUP
{
    public partial class START_KaKaoAPI : TIS.Controls.BizPopupBase
    {

        public START_KaKaoAPI()
        {
            InitializeComponent();
        }


        private void INIT()
        {
            this.bar_Title.Visible = false;
            
        }

        /// <summary>
        /// 지역 검색 (정적)메서드
        /// </summary>
        /// <param name="qstr">검색어</param>
        /// <returns>검색 결과(지역 컬렉션)</returns>


        public static List<MyLocale> Search(string qstr)
        {
            string site = "https://dapi.kakao.com/v2/local/search/keyword.json";
            string query = string.Format("{0}?query={1}", site, qstr);

            WebRequest request = WebRequest.Create(query);

            string rkey = "ca6d7ddccba50fd57a3cdb4bbab5fffa";
            string header = "KakaoAK " + rkey;

            request.Headers.Add("Authorization", header);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
           
            String json = reader.ReadToEnd();

            JavaScriptSerializer js = new JavaScriptSerializer();

            dynamic dob = js.Deserialize<dynamic>(json);
            dynamic docs = dob["documents"];
            object[] buf = docs;

            int length = buf.Length;

            List<MyLocale> mls = new List<MyLocale>();
            for (int i = 0; i < length; i++)
            {
                string lname = docs[i]["place_name"];
                string rname = docs[i]["road_address_name"];
                double x = double.Parse(docs[i]["x"]);
                double y = double.Parse(docs[i]["y"]);
                mls.Add(new MyLocale(lname,rname, y, x));
            }
            return mls;
        }

        //private void START_KaKaoAPI_PopupSearch(object sender, EventArgs e)
        //{
        //    string qstr = tbox_query.Text;
        //    List<MyLocale> mls = START_KaKaoAPI.Search(qstr);
        //    lbox_locale.Items.Clear();
        //    foreach (MyLocale locale in mls)
        //    {
        //        lbox_locale.Items.Add(locale);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            string qstr = tbox_query.Text;
            List<MyLocale> mls = START_KaKaoAPI.Search(qstr);
            lbox_locale.Items.Clear();
            foreach (MyLocale locale in mls)
            {
                lbox_locale.Items.Add(locale);
            }
        }

        private void lbox_locale_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void START_KaKaoAPI_PopupActivate(object sender, EventArgs e)
        {
            //string hString1 = "<head></head><body ><p style=\"text-align:center\"><img src=\"";
            //string hString2 = "\" height=\"100%\"></p></body>";
            //string url = "http://sku.nkcf.com/kakao.html";
            //wb_map.DocumentText = hString1 + url + hString2;

            this.wb_map.Navigate("http://sku.nkcf.com/kakao.html");

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        //private void lbox_locale_DoubleClick(object sender, EventArgs e)
        //{
        //    //Lng 경도 Lat 위도 -> 거리 계산시 경도,위도 순서
        //    MyLocale ml = lbox_locale.SelectedItem as MyLocale;
        //    string Lat = ml.Lat.ToString();
        //    string Lng = ml.Lng.ToString();
        //    string Name = ml.Name;

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Name", typeof(string));
        //    dt.Columns.Add("Lat", typeof(string));
        //    dt.Columns.Add("Lng", typeof(string));


        //    DataRow row = dt.NewRow();

        //    row["Name"] = Name;
        //    row["Lat"] = Lat;
        //    row["Lng"] = Lng;

        //    dt.Rows.Add(row);


        //    if (row != null)
        //    {
        //        PopupResultSet.ResultValue = row["Name"];
        //            //(Name);
        //        PopupResultSet.SetDataDictionary(row);
        //    }
        //}


        private void START_KaKaoAPI_PopupSelected(object sender, EventArgs e)
        {
            //Lng 경도 Lat 위도 -> 거리 계산시 경도,위도 순서
            MyLocale ml = lbox_locale.SelectedItem as MyLocale;
            string Lat = ml.Lat.ToString();
            string Lng = ml.Lng.ToString();
            string Name = ml.Name;

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Lat", typeof(string));
            dt.Columns.Add("Lng", typeof(string));


            DataRow row = dt.NewRow();

            row["Name"] = Name;
            row["Lat"] = Lat;
            row["Lng"] = Lng;

            dt.Rows.Add(row);


            if (row != null)
            {
                PopupResultSet.ResultValue = row["Name"];
                //PopupResultSet.ResultValue = row["Lng"];
                //PopupResultSet.ResultValue = row["Lat"];
                //(Name);
                PopupResultSet.SetDataDictionary(row);
            }
        }

        private void tbox_query_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string qstr = tbox_query.Text;
                List<MyLocale> mls = START_KaKaoAPI.Search(qstr);
                lbox_locale.Items.Clear();
                foreach (MyLocale locale in mls)
                {
                    lbox_locale.Items.Add(locale);
                }
            }
        }

      
    }
} 
