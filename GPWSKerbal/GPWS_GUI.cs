using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GPWSKerbal
{
    public class GPWS_GUI
    {
        public Rect windowPosition = new Rect(50, 50, 100, 90);
        int windowID = new System.Random().Next();
        GUIStyle infomation;
        GPWSKerbal GPWS = new GPWSKerbal();
        public string stateInfo = "On", gearInfo = "Normal", terrInfo = "Normal";
        public bool isGPWSWork = true, showGUI = false;

        public void stringChange()
        {
            if (isGPWSWork)
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
            windowPosition = GUILayout.Window(windowID, windowPosition, Window, "GPWS - Controller");
        }

        public void Window(int windowID)
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Radar Altitude: " + GPWS.m_Height, infomation);
            GUILayout.Label("");
            GUILayout.Label("GPWS On/Off: " + stateInfo, infomation);
            GUILayout.Label("Gear Inhibit: " + gearInfo, infomation);
            GUILayout.Label("Terrain Inhibit: " + terrInfo, infomation);
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Toggle GPWS"))
            {
                isGPWSWork = !isGPWSWork;
            }

            if (GUILayout.Button("Close"))
            {
                showGUI = false;
            }
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }
    }
}
