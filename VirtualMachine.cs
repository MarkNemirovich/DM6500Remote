﻿using Ivi.Visa;
using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using Ivi.Visa;
using NationalInstruments.Restricted;
using NationalInstruments.Visa;
using static System.Collections.Specialized.BitVector32;

namespace DM6500Remote
{
    internal class VirtualMachine : WorkMachine
    {
        private const int SECOND = 1000;
        private readonly double _delay;
        private readonly int _amount;
        private string deviceID;            // = "USB0::0x05E6::0x6500::04531633::INSTR";
        private Ivi.Visa.IMessageBasedSession session;

        public delegate void Message(string[] str);
        public event Message WriteMessage;
        public event Action Finish;

        public VirtualMachine(double delay, int amount):base(delay,amount)
        {
            _delay = delay;
            _amount = amount;
            StartExchange();
        }
        private new void StartExchange()
        {
            string[] data = new string[3];
            double time = 0;
            for (int i = 0; i < _amount; i++)
            {
                Thread.Sleep((int)(SECOND * _delay));
                Random randomizer = new Random();
                data[0] = time.ToString();
                data[1] = randomizer.NextDouble().ToString();
                data[2] = randomizer.NextDouble().ToString();
                WriteMessage?.Invoke(data);
                time += _delay;
            }
            StopExchange();
        }
        private new void StopExchange()
        {
            Finish?.Invoke();
            session.Dispose();
        }

        private void GetVisaResourceName()
        {
            var rmSession = new ResourceManager();
            foreach (string s in rmSession.Find("USB?*INSTR")) //VISA resouces list over USB connection
            {
                deviceID = s;
                break;
            }
            rmSession.Dispose();
        }
        private string SetTemperatureMeasurement(IMessageBasedSession session)
        {
            session.FormattedIO.WriteLine(":SENS:FUNC \"TEMP\"\n");
            return ReadAnswer(session);
        }
        private string VoltageMeasurement(IMessageBasedSession session)
        {
            session.FormattedIO.WriteLine(":SENS:FUNC \"VOLT:DC\"\n");
            return ReadAnswer(session);
        }
        private string ReadAnswer(IMessageBasedSession session)
        {
            session.FormattedIO.WriteLine("READ?\n");
            string answer = session.FormattedIO.ReadLine();
            answer = answer.Replace(',', '.');
            return answer;
        }
    }
}
