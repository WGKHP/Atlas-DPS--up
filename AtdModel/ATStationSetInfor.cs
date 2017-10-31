using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atd.Model
{
    public class ATStationSetInfor
    {
      /*  SELECT[StationID]
      ,[StationNum]
      ,[StationName]
      ,[StationIP]
      ,[StationMac]
      ,[DeFlag]
      ,[CreatDateTime]
      ,[UpDateTime]
      ,[Stationbeizhu]
      */
        
        private string  _StationID;
        private string _StationCount;//数据显示的行号 序号
        private Int16 _StationNum;
        private string _StationName;
        private string _StationIP;
        private string _StationMac;
        private int _DeFlag;
        private DateTime _CreatDateTime;
        private DateTime _UpDateTime;
        private string _Stationbeizhu;

        public string  StationID
        {
            get
            {
                return _StationID;
            }

            set
            {
                _StationID = value;
            }
        }

        public string StationCount
        {
            get
            {
                return _StationCount;
            }

            set
            {
                _StationCount = value;
            }
        }

       
        public string StationName
        {
            get
            {
                return _StationName;
            }

            set
            {
                _StationName = value;
            }
        }

        public string StationIP
        {
            get
            {
                return _StationIP;
            }

            set
            {
                _StationIP = value;
            }
        }

        public string StationMac
        {
            get
            {
                return _StationMac;
            }

            set
            {
                _StationMac = value;
            }
        }

        public int DeFlag
        {
            get
            {
                return _DeFlag;
            }

            set
            {
                _DeFlag = value;
            }
        }

        public DateTime CreatDateTime
        {
            get
            {
                return _CreatDateTime;
            }

            set
            {
                _CreatDateTime = value;
            }
        }

        public DateTime UpDateTime
        {
            get
            {
                return _UpDateTime;
            }

            set
            {
                _UpDateTime = value;
            }
        }

        public string Stationbeizhu
        {
            get
            {
                return _Stationbeizhu;
            }

            set
            {
                _Stationbeizhu = value;
            }
        }

        public short StationNum
        {
            get
            {
                return _StationNum;
            }

            set
            {
                _StationNum = value;
            }
        }
    }
}
