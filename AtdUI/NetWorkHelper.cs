using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Collections;

namespace AtdUI
{
  public class NetWorkHelper
    {
        /// <summary>
        /// 将16进制字符串进行CRC16校验
        /// </summary>
        /// <param name="hexString">16进制字符串</param>
        /// <returns>返回的是一个16进制字符串</returns>
        public string CRC16Calc(string hexString)
        {
            byte CRC16High = 0;
            byte CRC16Low = 0;
            //string hexString = ""; //拼接16进制字符串总和
            byte[] sendbuffer;//发送的字节数组
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            sendbuffer = new byte[hexString.Length / 2];
            for (int j = 0; j < sendbuffer.Length; j++)
            {
                sendbuffer[j] = Convert.ToByte(hexString.Substring(j * 2, 2), 16);
            }
            //CRC16 -Modbus 校验 多项式算法
            int CRCResult = 0xFFFF;
            for (int i = 0; i < sendbuffer.Length; i++)
            {
                CRCResult = CRCResult ^ sendbuffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((CRCResult & 1) == 1)
                        CRCResult = (CRCResult >> 1) ^ 0xA001;
                    else
                        CRCResult >>= 1;
                }
            }
            CRC16High = Convert.ToByte(CRCResult & 0xff);
            CRC16Low = Convert.ToByte(CRCResult >> 8);
            //return (CRC16High+CRC16High);//整数返回
            string b = Convert.ToString(CRC16High, 16).PadLeft(2,'0')+Convert.ToString(CRC16Low, 16).PadLeft(2, '0');
            return b;
        }


        /// <summary>
        /// 将二进制字符串转成字节数组 并返回一个16进制的字符串
        /// </summary>
        /// <param name="codestr">传入的二进制字符串</param>
        /// <returns></returns>
        public string GetHexStringByBinary (string codestr )
        {
            string HexStringRe = "";
            byte[] encodebyte = new byte[codestr.Length / 8];
            for (int i = 0; i < codestr.Length / 8; i++)
            {
                encodebyte[i] = Convert.ToByte(codestr.Substring(i * 8, 8), 2);
            }
            for (int i = 0; i < encodebyte.Length; i++)
            {
                HexStringRe = HexStringRe + String.Format("{0:X2} ", encodebyte[i]);
            }
            return HexStringRe;
        }


        // 把字节型转换成十六进制字符串  
        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                StringOut = StringOut + String.Format("{0:X2} ", InByte);
            }
            return StringOut;
        }
        public string ByteToString(byte[] InBytes, int len)
        {
            string StringOut = "";
            for (int i = 0; i < len; i++)
            {
                StringOut = StringOut + String.Format("{0:X2} ", InBytes[i]);
            }
            return StringOut;
        }

        // 把十六进制字符串转换成字节型  
        public static byte[] StringToByte(string InString)
        {
            string[] ByteStrings;
            ByteStrings = InString.Split(" ".ToCharArray());
            byte[] ByteOut;
            ByteOut = new byte[ByteStrings.Length - 1];
            for (int i = 0; i == ByteStrings.Length - 1; i++)
            {
                ByteOut[i] = Convert.ToByte(("0x" + ByteStrings[i]));
            }
            return ByteOut;
        }

        public byte[] change(string strsendbuffer)
        {
            byte[] sendbuffer;

            strsendbuffer = strsendbuffer.Replace(" ", "");
            if ((strsendbuffer.Length % 2) != 0)
                strsendbuffer += " ";
            sendbuffer = new byte[strsendbuffer.Length / 2];
            for (int j = 0; j < sendbuffer.Length; j++)//16进制字符串转字节数组
            {
                sendbuffer[j] = Convert.ToByte(strsendbuffer.Substring(j * 2, 2), 16);
            }
            return sendbuffer;
        }


    }
}
