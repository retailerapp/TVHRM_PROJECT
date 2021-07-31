using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Epoint.Systems.Elements
{
    public class ElementHrm
    {
        private static string ZaloCodeID;
        private static string ZaloOfficialID;
        private static string ZaloSeccretKey;
        private static string ZaloAccessToken;
        private static string LinkInfo;        
       
        public static string sysZaloOfficialID
        {
            set
            {
                ZaloOfficialID = value;
            }
            get
            {
                return ZaloOfficialID;
            }
        }
        public static string sysZaloCodeID
        {
            set
            {
                ZaloCodeID = value;
            }
            get
            {
                return ZaloCodeID;
            }
        }
        public static string sysZaloSeccretKey
        {
            set
            {
                ZaloSeccretKey = value;
            }
            get
            {
                return ZaloSeccretKey;
            }
        }
        public static string sysZaloAccessToken
        {
            set
            {
                ZaloAccessToken = value;
            }
            get
            {
                return ZaloAccessToken;
            }
        }
        public static string sysLinkInfo
        {
            set
            {
                LinkInfo = value;
            }
            get
            {
                return LinkInfo;
            }
        }
    }
    public class Follower
    {
        public string id { get; set; }
        public string birthday { get; set; }
        public string gender { get; set; }
        public string Addr { get; set; }
        public string picture { get; set; }
        public string name { get; set; }
        public string Phone { get; set; }
        public bool shared_info { get; set; }
        public string Avatar { get; set; }
        public string TagName { get; set; }
    }
    public class Message
    {
        public string Message_id { get; set; }
        public string From_id { get; set; }
        public string To_id { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
    }
}
