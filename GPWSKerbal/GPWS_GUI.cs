using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GPWSKerbal
{
    [KSPAddon(KSPAddon.Startup.EveryScene, false)]
    public class GPWS_GUI : MonoBehaviour
    {
        public Rect windowPosition = new Rect(Screen.width / 4, Screen.height / 4, 10f, 10f);
        int windowID = new System.Random().Next();
        GUIStyle infomation;
        public string stateInfo = "On", gearInfo = "Normal", terrInfo = "Normal";
        public bool isGPWSAvailable = true;

        private static ApplicationLauncherButton m_ToolbarButton = null;
        private static bool isVisible = false;

        static void onAppLauncherTrue()
        {
            isVisible = true;
        }

        static void onAppLauncherFalse()
        {
            isVisible = false;
        }

        ApplicationLauncherButton InitAppLauncherButton()
        {
            ApplicationLauncherButton button = null;
            Texture2D iconTexture = null;
            if (GameDatabase.Instance.ExistsTexture("GPWSKerbal/GPWS_Icon"))
            {
                iconTexture = GameDatabase.Instance.GetTexture("GPWSKerbal/GPWS_Icon", false);
                button = ApplicationLauncher.Instance.AddModApplication(onAppLauncherTrue, onAppLauncherFalse,
                    null, null, null, null,
                    ApplicationLauncher.AppScenes.FLIGHT,
                    iconTexture);
            }
            else
            {
                Debug.LogError("-------GPWSKerbal/GPWS_Icon does not exist-------");
            }
            return button;
        }

        public void Awake()
        {
            if (HighLogic.LoadedScene == GameScenes.FLIGHT)
            {

                if (m_ToolbarButton == null && ApplicationLauncher.Ready)
                {
                    m_ToolbarButton = InitAppLauncherButton();
                }

                RenderingManager.AddToPostDrawQueue(3, new Callback(DrawWindow));
            }
        }

        public void stringChange()
        {
            if (isGPWSAvailable)
                stateInfo = "On";
            else
                stateInfo = "Off";
        }

        public void DrawWindow()
        {
            GUI.skin = HighLogic.Skin;
            infomation = new GUIStyle(GUI.skin.label);
            infomation.normal.textColor = Color.white;
            infomation.fontStyle = FontStyle.Normal;
            infomation.fixedWidth = 230;
            if (HighLogic.LoadedScene == GameScenes.FLIGHT && isVisible)
            {
                windowPosition = GUILayout.Window(windowID, windowPosition, FlightGUI, "GPWS - Flight");
            }
        }

        public void FlightGUI(int windowID)
        {
            GUILayout.BeginVertical();
            GUILayout.Label("");
            GUILayout.Label("GPWS On/Off: " + stateInfo, infomation);
            GUILayout.Label("Gear Inhibit: " + gearInfo, infomation);
            GUILayout.Label("Terrain Inhibit: " + terrInfo, infomation);
            if (GUILayout.Button("Toggle GPWS"))
            {
                isGPWSAvailable = !isGPWSAvailable;
            }
            GUILayout.EndVertical();
            
            GUI.DragWindow();
        }
    }
}
