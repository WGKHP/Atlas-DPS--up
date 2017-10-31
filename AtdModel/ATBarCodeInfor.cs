using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atd.Model
{
    public class ATBarCodeInfor: ATStationSetInfor
    {
        /* SELECT[BarCodeID]
       ,[BarCode]
       ,[BarCodeName]
       ,[CreatDateTime]
       ,[GAReStates]
       ,[StationNum]
       ,[DeFlag]
       ,[UpDateTime]
       ,[BarCodebeizhu]
         FROM[dbo].[ATBarCode]
         GO*/
        private string _BarCodeID;
        private string _BarCode;
        private string _BarCodeName;
        private DateTime _CreatDateTime;
        private int _DeFlag;
        private string _BarCodeCount;
        private DateTime _UpDateTime;
        private string _BarCodebeizhu;
        private int _StationNum;
        private int _GAReStates;
        

        public string BarCodeID
        {
            get
            {
                return _BarCodeID;
            }

            set
            {
                _BarCodeID = value;
            }
        }

        public string BarCode
        {
            get
            {
                return _BarCode;
            }

            set
            {
                _BarCode = value;
            }
        }

        public string BarCodeCount
        {
            get
            {
                return _BarCodeCount;
            }

            set
            {
                _BarCodeCount = value;
            }
        }

        public string BarCodeName
        {
            get
            {
                return _BarCodeName;
            }

            set
            {
                _BarCodeName = value;
            }
        }

        public new  DateTime CreatDateTime
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

        public new int DeFlag
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

        public new  DateTime UpDateTime
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

        public string BarCodebeizhu
        {
            get
            {
                return _BarCodebeizhu;
            }

            set
            {
                _BarCodebeizhu = value;
            }
        }

        public new int StationNum
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

        public int GAReStates
        {
            get
            {
                return _GAReStates;
            }

            set
            {
                _GAReStates = value;
            }
        }
    }
  }

