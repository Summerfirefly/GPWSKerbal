using System;
using System.Reflection;
using UnityEngine;

namespace GPWSKerbal
{
    class GPWS_Settings
    {
        static private bool hasLoaded = false;

        public struct HeightAnnouncementSettings
        {
            static public int HeightUnit = 0;
            static public bool TwentyFiveHundred = true;
		    static public bool Thousand = true;
		    static public bool FiveHundred = true;
            static public bool FourHundred = false;
            static public bool ThreeHundred = false;
            static public bool TwoHundred = false;
            static public bool Hundred = true;
            static public bool Fifty = true;
            static public bool Forty = true;
            static public bool Thirty = true;
            static public bool Twenty = true;
            static public bool Ten = true;
        }

        static public void LoadConfig()
        {
            if (hasLoaded)
            {
                return;
            }

            ConfigNode settings = ConfigNode.Load(KSPUtil.ApplicationRootPath + "GameData/GPWSKerbal/Settings.cfg");

            if (settings != null)
            {
                if (settings.HasNode("GPWS"))
                {
                    ConfigNode gpwsSettings = settings.GetNode("GPWS");
                    if (gpwsSettings.HasNode("PlayHeightAnnouncement"))
                    {
                        ConfigNode phaSettings = gpwsSettings.GetNode("PlayHeightAnnouncement");
                        if (phaSettings.HasValue("HeightUnit"))
                        {
                            HeightAnnouncementSettings.HeightUnit = int.Parse(phaSettings.GetValue("HeightUnit"));
                        }
                        if (phaSettings.HasValue("TwentyFiveHundred"))
                        {
                            HeightAnnouncementSettings.TwentyFiveHundred = bool.Parse(phaSettings.GetValue("TwentyFiveHundred"));
                        }
                        if (phaSettings.HasValue("Thousand"))
                        {
                            HeightAnnouncementSettings.Thousand = bool.Parse(phaSettings.GetValue("Thousand"));
                        }
                        if (phaSettings.HasValue("FiveHundred"))
                        {
                            HeightAnnouncementSettings.FiveHundred = bool.Parse(phaSettings.GetValue("FiveHundred"));
                        }
                        if (phaSettings.HasValue("FourHundred"))
                        {
                            HeightAnnouncementSettings.FourHundred = bool.Parse(phaSettings.GetValue("FourHundred"));
                        }
                        if (phaSettings.HasValue("ThreeHundred"))
                        {
                            HeightAnnouncementSettings.ThreeHundred = bool.Parse(phaSettings.GetValue("ThreeHundred"));
                        }
                        if (phaSettings.HasValue("TwoHundred"))
                        {
                            HeightAnnouncementSettings.TwoHundred = bool.Parse(phaSettings.GetValue("TwoHundred"));
                        }
                        if (phaSettings.HasValue("Hundred"))
                        {
                            HeightAnnouncementSettings.Hundred = bool.Parse(phaSettings.GetValue("Hundred"));
                        }
                        if (phaSettings.HasValue("Fifty"))
                        {
                            HeightAnnouncementSettings.Fifty = bool.Parse(phaSettings.GetValue("Fifty"));
                        }
                        if (phaSettings.HasValue("Forty"))
                        {
                            HeightAnnouncementSettings.Forty = bool.Parse(phaSettings.GetValue("Forty"));
                        }
                        if (phaSettings.HasValue("Thirty"))
                        {
                            HeightAnnouncementSettings.Thirty = bool.Parse(phaSettings.GetValue("Thirty"));
                        }
                        if (phaSettings.HasValue("Twenty"))
                        {
                            HeightAnnouncementSettings.Twenty = bool.Parse(phaSettings.GetValue("Twenty"));
                        }
                        if (phaSettings.HasValue("Ten"))
                        {
                            HeightAnnouncementSettings.Ten = bool.Parse(phaSettings.GetValue("Ten"));
                        }
                    }
                }

                hasLoaded = true;
            }
        }

        static public void SaveConfig()
        {
            ConfigNode settings = new ConfigNode();
            ConfigNode gpwsSettings = settings.AddNode("GPWS");
            ConfigNode phaSettings = gpwsSettings.AddNode("PlayHeightAnnouncement");

            phaSettings.AddValue("HeightUnit", HeightAnnouncementSettings.HeightUnit);
            phaSettings.AddValue("TwentyFiveHundred", HeightAnnouncementSettings.TwentyFiveHundred);
            phaSettings.AddValue("Thousand", HeightAnnouncementSettings.Thousand);
            phaSettings.AddValue("FiveHundred", HeightAnnouncementSettings.FiveHundred);
            phaSettings.AddValue("FourHundred", HeightAnnouncementSettings.FourHundred);
            phaSettings.AddValue("ThreeHundred", HeightAnnouncementSettings.ThreeHundred);
            phaSettings.AddValue("TwoHundred", HeightAnnouncementSettings.TwoHundred);
            phaSettings.AddValue("Hundred", HeightAnnouncementSettings.Hundred);
            phaSettings.AddValue("Fifty", HeightAnnouncementSettings.Fifty);
            phaSettings.AddValue("Forty", HeightAnnouncementSettings.Forty);
            phaSettings.AddValue("Thirty", HeightAnnouncementSettings.Thirty);
            phaSettings.AddValue("Twenty", HeightAnnouncementSettings.Twenty);
            phaSettings.AddValue("Ten", HeightAnnouncementSettings.Ten);

            settings.Save(KSPUtil.ApplicationRootPath + "GameData/GPWSKerbal/Settings.cfg");
        }
    }
}
