using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Edward;

namespace LCDTester
{
    class p
    {
        public static string AppFolder = Application.StartupPath + @"\" + Application.ProductName;
        public static string SysIni = AppFolder + @"\SysConfig.ini";
        public static string AppTitle = "WT(WCD) LCD Tester";


        public static void CreateIni()
        {
            if (!File.Exists(SysIni))
            {
                IniFile.CreateIniFile(SysIni);
                IniFile.iniFilePathValue = SysIni;
                IniFile.IniWriteValue("SysConfig", "AppTitle", AppTitle);
                IniFile.IniWriteValue("SysConfig", "AppVer:", Application.ProductVersion);
            }

        }



        public static void ReadIni()
        {
            IniFile.iniFilePathValue = SysIni;
            if (File.Exists(SysIni))
            {
                AppTitle = IniFile.IniReadValue("SysConfig", "AppTitle");
            }

        }




        public static void CheckFolder()
        {
            if (!Directory.Exists(AppFolder))
            {
                Directory.CreateDirectory(AppFolder);
            }
        }


    }
}
