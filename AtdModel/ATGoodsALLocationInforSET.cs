using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atd.Model
{
    public class ATGoodsALLocationInforSET: ATBarCodeInfor
    {
        /* SELECT[GoodsAllocationID]
       ,[GoodsAllocationNum]
       ,[GoodsCode]
       ,[GoodsAllocationName]
       ,[GAPartsCount]
       ,[DeFlag]
       ,[CreatDateTime]
       ,[UpDateTime]
       ,[GoodsAllocationbeizhu]
         FROM[dbo].[ATGoodsAllocation]
         GO*/

        private string _GoodsAllocationID;
        private int _GoodsAllocationNum;
        private string _GoodsCode;
        private string _GoodsAllocationName;
        private int _GAPartsCount;
        private int _DeFlag;
        private DateTime _CreatDateTime;
        private DateTime _UpDateTime;
        private string _GoodsAllocationbeizhu;
        private int _GoodsAlllocationCount;

        public string GoodsAllocationID
        {
            get
            {
                return _GoodsAllocationID;
            }

            set
            {
                _GoodsAllocationID = value;
            }
        }

        public int GoodsAllocationNum
        {
            get
            {
                return _GoodsAllocationNum;
            }

            set
            {
                _GoodsAllocationNum = value;
            }
        }

        public string GoodsAllocationName
        {
            get
            {
                return _GoodsAllocationName;
            }

            set
            {
                _GoodsAllocationName = value;
            }
        }

        public int GAPartsCount
        {
            get
            {
                return _GAPartsCount;
            }

            set
            {
                _GAPartsCount = value;
            }
        }

        public new  int DeFlag
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

        public new DateTime CreatDateTime
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

        public new DateTime  UpDateTime
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

        public string GoodsAllocationbeizhu
        {
            get
            {
                return _GoodsAllocationbeizhu;
            }

            set
            {
                _GoodsAllocationbeizhu = value;
            }
        }

        public int  GoodsAlllocationCount
        {
            get
            {
                return _GoodsAlllocationCount;
            }

            set
            {
                _GoodsAlllocationCount = value;
            }
        }

        public string GoodsCode
        {
            get
            {
                return _GoodsCode;
            }

            set
            {
                _GoodsCode = value;
            }
        }

        //  SELECT[SaveGAid]
        //,[SaveGoodsAllocationNum]
        //  [ SaveGoodsCode]
        //,[SaveGoodsAllocationName]
        //,[SaveGoodsAllocationPartsQTY]
        //,[DeFlag2]
        //,[SelectStates]
        //  FROM[dbo].[ATSaveGoodsAllocationNum]
        //  GO


        private string _SaveGAid;
        private int _SaveGoodsAllocationNum;
        private string _SaveGoodsCode;
        private string _SaveGoodsAllocationName;
        private int _SaveGoodsAllocationPartsQTY;
        private int _DeFlag2;
        private bool _SelectStates;

        public string SaveGAid
        {
            get
            {
                return _SaveGAid;
            }

            set
            {
                _SaveGAid = value;
            }
        }

        public int SaveGoodsAllocationNum
        {
            get
            {
                return _SaveGoodsAllocationNum;
            }

            set
            {
                _SaveGoodsAllocationNum = value;
            }
        }

        public string SaveGoodsAllocationName
        {
            get
            {
                return _SaveGoodsAllocationName;
            }

            set
            {
                _SaveGoodsAllocationName = value;
            }
        }

        public int DeFlag2
        {
            get
            {
                return _DeFlag2;
            }

            set
            {
                _DeFlag2 = value;
            }
        }

        public bool SelectStates
        {
            get
            {
                return _SelectStates;
            }

            set
            {
                _SelectStates = value;
            }
        }

        public int SaveGoodsAllocationPartsQTY
        {
            get
            {
                return _SaveGoodsAllocationPartsQTY;
            }

            set
            {
                _SaveGoodsAllocationPartsQTY = value;
            }
        }

        public string SaveGoodsCode
        {
            get
            {
                return _SaveGoodsCode;
            }

            set
            {
                _SaveGoodsCode = value;
            }
        }
    }
    
}

