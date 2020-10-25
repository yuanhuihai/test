﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;

namespace comWithPlc
{
    class getPlcValues
    {
        S7Client Client = new S7Client();
    


        public int readPlcDbwValue(string plcIp, int Rack, int Slot, int DbNum, int DbwNum)
        {
            byte[] Buffer = new byte[2];
            Client.ConnectTo(plcIp, Rack, Slot);
            Client.DBRead(DbNum, DbwNum, 2, Buffer);//读取DbwNum所对应的字的值
            Client.Disconnect();
            return S7.GetIntAt(Buffer, 0);
        }

        public void writePlcDbwValue(string plcIp, int Rack, int Slot, int DbNum, int DbwNum, int writeValue)
        {
            short a = (short)writeValue;//将整形的writeValue强制转换成short类型
            Client.ConnectTo(plcIp, Rack, Slot);
            byte[] buffer = new byte[2];
            S7.SetIntAt(buffer, 0, a);
            Client.DBWrite(DbNum, DbwNum, 2, buffer);//将DbwNum对应的字更新
            Client.Disconnect();
        }

        public float readPlcDbdValue(string plcIp, int Rack, int Slot, int DbNum, int DbdNum)
        {
            byte[] Buffer = new byte[4];
            Client.ConnectTo(plcIp, Rack, Slot);
            Client.DBRead(DbNum, DbdNum, 4, Buffer);//读取Dbd所对应的值
            Client.Disconnect();
            return S7.GetRealAt(Buffer, 0);
        }
        public void writePlcDbdValue(string plcIp, int Rack, int Slot, int DbNum, int DbdNum, float writeValue)
        {
            short a = (short)writeValue;//将writeValue强制转换成short类型
            Client.ConnectTo(plcIp, Rack, Slot);
            byte[] buffer = new byte[4];
            S7.SetDIntAt(buffer, 0, a);
            Client.DBWrite(DbNum, DbdNum, 4, buffer);//将Dbd更新
            //Client.Disconnect();

        }
        public bool getPlcDbxVaule(string plcIp, int Rack, int Slot, int DbNum, int dbx, int dbxx)
        {
            byte[] Buffer = new byte[2];
            Client.ConnectTo(plcIp, Rack, Slot);
            Client.DBRead(DbNum, dbx, 2, Buffer);//读取Dbx所对应的值      
            Client.Disconnect();
            return S7.GetBitAt(Buffer, 0, dbxx);
        }

        //20200915 添加读取字符串指令
        public string  getCharValue(string ip,int dbnum, int start, int size)
        {
            byte[] Buffer = new byte[20];
            Client.ConnectTo(ip, 0, 3);
            Client.DBRead(dbnum, start, size, Buffer);
            Client.Disconnect();
            return S7.GetCharsAt(Buffer,0, size);
        }
      
        //20200917 读取M位
        public bool getPlcMX(string plcIp,int start,int size,int pos)
        {
            byte[] Buffer = new byte[1];
            Client.ConnectTo(plcIp, 0, 3);
            Client.MBRead(start, size, Buffer);
            Client.Disconnect();
            return S7.GetBitAt(Buffer, 0, pos);

        }


    }
}
