using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIS.ERP.POPUP
{
    public class MyLocale
    {
        // 지역명
        public string Name
        {
            get;
            private set;
        }

        //도로명
        public string RName
        {
            get;
            private set;
        }

        // 위도
        public double Lat
        {
            get;
            private set;
        }

        // 경도
        public double Lng
        {
            get;
            private set;
        }

        //생성자
        /// <param name="name">지역 명</param>
        /// <param name="lat">위도</param>
        /// <param name="lng">경도</param>
        public MyLocale(string name, string rname,double lat, double lng)
        {
            Name = name;
            RName = rname;
            Lat = lat;
            Lng = lng;
        }

        public override string ToString() 
        {
            return Name+"//"+RName;
        }


    }
}
