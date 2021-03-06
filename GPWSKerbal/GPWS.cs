﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GPWSKerbal
{
    public class GPWS : PartModule
    {
        public double m_Height = 0, terr_verticalSpeed = 0, m_height_backup = 0;
        bool isAvailable = true;
        GPWS_GUI mGUI = new GPWS_GUI();
        public static GPWS sActiveModule = null;

        #region Sounds
        public FXGroup pullUp = null; // Make sure this is public so it can be initialised internally.
        public FXGroup twentyfiveHundred = null;
        public FXGroup thousand = null;
        public FXGroup fivehundred = null;
        public FXGroup fourHundred = null;
        public FXGroup threeHundred = null;
        public FXGroup twoHundred = null;
        public FXGroup hundred = null;
        public FXGroup fifty = null;
        public FXGroup forty = null;
        public FXGroup thirty = null;
        public FXGroup twenty = null;
        public FXGroup ten = null;
        #endregion

        #region Flags
        public int twentyfiveHundredFlag = 0;
        public int thousandflag = 0;
        public int fivehundredflag = 0;
        public int fourHundredFlag = 0;
        public int threeHundredFlag = 0;
        public int twoHundredFlag = 0;
        public int hundredflag = 0;
        public int fiftyFlag = 0;
        public int fortyFlag = 0;
        public int thirtyFlag = 0;
        public int twentyFlag = 0;
        public int tenFlag = 0;
        #endregion

        public void ResetHeightFlag()
        {
            if (m_Height > 775)
                twentyfiveHundredFlag = 0;
            else if (m_Height > 315)
                thousandflag = 0;
            else if (m_Height > 165)
                fivehundredflag = 0;
            else if (m_Height > 132)
                fourHundredFlag = 0;
            else if (m_Height > 102)
                threeHundredFlag = 0;
            else if (m_Height > 73)
                twoHundredFlag = 0;
            else if (m_Height > 40)
                hundredflag = 0;
            else if (m_Height > 21)
                fiftyFlag = 0;
            else if (m_Height > 17)
                fortyFlag = 0;
            else if (m_Height > 13.5)
                thirtyFlag = 0;
            else if (m_Height > 9.5)
                twentyFlag = 0;
            else if (m_Height > 6)
                tenFlag = 0;
        }

        public override void OnStart(PartModule.StartState state)
        {
            if (state == StartState.Editor || state == StartState.None) return;

            pullUp.audio = gameObject.AddComponent<AudioSource>();
            pullUp.audio.volume = GameSettings.SHIP_VOLUME;
            pullUp.audio.maxDistance = 10;
            pullUp.audio.Stop();
            pullUp.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/pullup");
            pullUp.audio.loop = false;

            twentyfiveHundred.audio = gameObject.AddComponent<AudioSource>();
            twentyfiveHundred.audio.volume = GameSettings.SHIP_VOLUME;
            twentyfiveHundred.audio.maxDistance = 10;
            twentyfiveHundred.audio.Stop();
            twentyfiveHundred.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/2500");
            twentyfiveHundred.audio.loop = false;

            thousand.audio = gameObject.AddComponent<AudioSource>();
            thousand.audio.volume = GameSettings.SHIP_VOLUME;
            thousand.audio.maxDistance = 10;
            thousand.audio.Stop();
            thousand.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/1000");
            thousand.audio.loop = false;

            fivehundred.audio = gameObject.AddComponent<AudioSource>();
            fivehundred.audio.volume = GameSettings.SHIP_VOLUME;
            fivehundred.audio.maxDistance = 10;
            fivehundred.audio.Stop();
            fivehundred.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/500");
            fivehundred.audio.loop = false;

            fourHundred.audio = gameObject.AddComponent<AudioSource>();
            fourHundred.audio.volume = GameSettings.SHIP_VOLUME;
            fourHundred.audio.maxDistance = 10;
            fourHundred.audio.Stop();
            fourHundred.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/400");
            fourHundred.audio.loop = false;

            threeHundred.audio = gameObject.AddComponent<AudioSource>();
            threeHundred.audio.volume = GameSettings.SHIP_VOLUME;
            threeHundred.audio.maxDistance = 10;
            threeHundred.audio.Stop();
            threeHundred.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/300");
            threeHundred.audio.loop = false;

            twoHundred.audio = gameObject.AddComponent<AudioSource>();
            twoHundred.audio.volume = GameSettings.SHIP_VOLUME;
            twoHundred.audio.maxDistance = 10;
            twoHundred.audio.Stop();
            twoHundred.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/200");
            twoHundred.audio.loop = false;

            hundred.audio = gameObject.AddComponent<AudioSource>();
            hundred.audio.volume = GameSettings.SHIP_VOLUME;
            hundred.audio.maxDistance = 10;
            hundred.audio.Stop();
            hundred.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/100");
            hundred.audio.loop = false;

            fifty.audio = gameObject.AddComponent<AudioSource>();
            fifty.audio.volume = GameSettings.SHIP_VOLUME;
            fifty.audio.maxDistance = 10;
            fifty.audio.Stop();
            fifty.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/50");
            fifty.audio.loop = false;

            forty.audio = gameObject.AddComponent<AudioSource>();
            forty.audio.volume = GameSettings.SHIP_VOLUME;
            forty.audio.maxDistance = 10;
            forty.audio.Stop();
            forty.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/40");
            forty.audio.loop = false;

            thirty.audio = gameObject.AddComponent<AudioSource>();
            thirty.audio.volume = GameSettings.SHIP_VOLUME;
            thirty.audio.maxDistance = 10;
            thirty.audio.Stop();
            thirty.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/30");
            thirty.audio.loop = false;

            twenty.audio = gameObject.AddComponent<AudioSource>();
            twenty.audio.volume = GameSettings.SHIP_VOLUME;
            twenty.audio.maxDistance = 10;
            twenty.audio.Stop();
            twenty.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/20");
            twenty.audio.loop = false;

            ten.audio = gameObject.AddComponent<AudioSource>();
            ten.audio.volume = GameSettings.SHIP_VOLUME;
            ten.audio.maxDistance = 10;
            ten.audio.Stop();
            ten.audio.clip = GameDatabase.Instance.GetAudioClip("GPWSKerbal/Sounds/10");
            ten.audio.loop = false;
        }

        public void FixedUpdate()
        {
            mGUI.stringChange();

            if (!isAvailable) return;
            if (!mGUI.isGPWSAvailable) return;
            if (FlightGlobals.ActiveVessel.checkLanded() || FlightGlobals.ActiveVessel.checkSplashed()) return;

            ResetHeightFlag();

            m_height_backup = m_Height;
            if (vessel.terrainAltitude < 0)
            {
                m_Height = vessel.mainBody.GetAltitude(vessel.CoM);
            }
            else
            {
                m_Height = vessel.mainBody.GetAltitude(vessel.CoM) - vessel.terrainAltitude;
            }
            terr_verticalSpeed = (m_Height - m_height_backup) / Time.fixedDeltaTime;

            if (terr_verticalSpeed < -50 && m_Height < 350)
            {
                if (pullUp.audio.isPlaying == false)
                {
                    StopAllCoroutines();
                    pullUp.audio.Play();
                }
                return;
            }//Pull up

            if (m_Height < 770 && m_Height > 750 && terr_verticalSpeed < 0)
            {
                if (twentyfiveHundred.audio.isPlaying == false && twentyfiveHundredFlag == 0)
                {
                    StopAllCoroutines();
                    twentyfiveHundred.audio.Play();
                    twentyfiveHundredFlag = 1;
                }
                return;
            }//2500ft

            if (m_Height < 310 && m_Height > 290 && terr_verticalSpeed < 0)
            {
                if (thousand.audio.isPlaying == false && thousandflag == 0)
                {
                    StopAllCoroutines();
                    thousand.audio.Play();
                    thousandflag = 1;
                }
                return;
            }//2000ft

            if (m_Height < 160 && m_Height > 140 && terr_verticalSpeed < 0)
            {
                if (fivehundred.audio.isPlaying == false && fivehundredflag == 0)
                {
                    StopAllCoroutines();
                    fivehundred.audio.Play();
                    fivehundredflag = 1;
                }
                return;
            }//500ft

            if (m_Height < 127 && m_Height > 107 && terr_verticalSpeed < 0)
            {
                if (fourHundred.audio.isPlaying == false && fourHundredFlag == 0)
                {
                    StopAllCoroutines();
                    fourHundred.audio.Play();
                    fourHundredFlag = 1;
                }
                return;
            }//400ft

            if (m_Height < 97 && m_Height > 77 && terr_verticalSpeed < 0)
            {
                if (threeHundred.audio.isPlaying == false && threeHundredFlag == 0)
                {
                    StopAllCoroutines();
                    threeHundred.audio.Play();
                    threeHundredFlag = 1;
                }
                return;
            }//300ft

            if (m_Height < 68 && m_Height > 48 && terr_verticalSpeed < 0)
            {
                if (twoHundred.audio.isPlaying == false && twoHundredFlag == 0)
                {
                    StopAllCoroutines();
                    twoHundred.audio.Play();
                    twoHundredFlag = 1;
                }
                return;
            }//200ft

            if (m_Height < 35 && m_Height > 20 && terr_verticalSpeed < 0)
            {
                if (hundred.audio.isPlaying == false && hundredflag == 0)
                {
                    StopAllCoroutines();
                    hundred.audio.Play();
                    hundredflag = 1;
                }
                return;
            }//100ft

            if (m_Height < 18 && m_Height > 14 && terr_verticalSpeed < 0)
            {
                if (fifty.audio.isPlaying == false && fiftyFlag == 0)
                {
                    StopAllCoroutines();
                    fifty.audio.Play();
                    fiftyFlag = 1;
                }
                return;
            }//50ft

            if (m_Height < 14 && m_Height > 10.5 && terr_verticalSpeed < 0)
            {
                if (forty.audio.isPlaying == false && fortyFlag == 0)
                {
                    StopAllCoroutines();
                    forty.audio.Play();
                    fortyFlag = 1;
                }
                return;
            }//40ft

            if (m_Height < 10.5 && m_Height > 7.5 && terr_verticalSpeed < 0)
            {
                if (thirty.audio.isPlaying == false && thirtyFlag == 0)
                {
                    StopAllCoroutines();
                    thirty.audio.Play();
                    thirtyFlag = 1;
                }
                return;
            }//30ft

            if (m_Height < 7.5 && m_Height > 4.5 && terr_verticalSpeed < 0)
            {
                if (twenty.audio.isPlaying == false && twentyFlag == 0)
                {
                    StopAllCoroutines();
                    twenty.audio.Play();
                    twentyFlag = 1;
                }
                return;
            }//20ft

            if (m_Height < 4 && m_Height > 2.9 && terr_verticalSpeed < 0)
            {
                if (ten.audio.isPlaying == false && tenFlag == 0)
                {
                    StopAllCoroutines();
                    ten.audio.Play();
                    tenFlag = 1;
                }
                return;
            }//10ft

            pullUp.audio.Stop();
        }

        //This function is used to fix the issue that two or more same sounds play at the same time
        public override void OnUpdate()
        {
            if (sActiveModule == null && this.vessel == FlightGlobals.ActiveVessel)
            {
                sActiveModule = this;
            }

            if (sActiveModule == this)
            {
                isAvailable = true;
            }
            else
            {
                isAvailable = false;
            }

            if (sActiveModule != null && sActiveModule.vessel != FlightGlobals.ActiveVessel)
            {
                sActiveModule = null;
            }

            base.OnUpdate();
        }
    }
}
