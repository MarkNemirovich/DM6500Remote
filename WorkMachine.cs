using System;
using System.Reflection;
using System.Threading;
using Ivi.Visa;
using NationalInstruments.Restricted;
using NationalInstruments.Visa;
using static System.Collections.Specialized.BitVector32;

namespace DM6500Remote
{
    internal class WorkMachine
    {
        private const int SECOND = 1000;
        private readonly double _delay;
        private readonly int _amount;
        private string deviceID;            // = "USB0::0x05E6::0x6500::04531633::INSTR";
        private Ivi.Visa.IMessageBasedSession session;

        public delegate void Message(string[] str);
        public event Message WriteMessage;
        public event Action Finish;

        public WorkMachine(double delay, int amount) 
        { 
            _delay = delay;
            _amount = amount;
            try
            {
                GetVisaResourceName();
                Thread.Sleep(SECOND); // wait 1 sec
                session = new UsbSession(deviceID, AccessModes.None, openTimeout: 2 * SECOND);
                session.Clear();
            }
            catch (Exception e)
            {
                string[] args = new string[2];
                args[0] = "error";
                args[1] = e.Message;
                WriteMessage?.Invoke(args);
            }                
        }

        public void StartExchange()
        {
            string[] data = new string[3];
            double time = 0;
            for (int i = 0; i < _amount; i++)
            {
                data[0] = time.ToString();
                session.FormattedIO.WriteLine("*RST\n");
                data[1] = CurrentMeasurement(session);
                session.FormattedIO.WriteLine("*RST\n");
                data[2] = SetTemperatureMeasurement(session);
                WriteMessage?.Invoke(data);
                Thread.Sleep((int)(SECOND * _delay));
                time += _delay;
            }
            StopExchange();
        }
        public void StopExchange()
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
        private string CurrentMeasurement(IMessageBasedSession session)
        {
            session.FormattedIO.WriteLine(":SENS:FUNC \"VOLT:DC\"\n");
            return ReadAnswer(session);
        }
        private string ReadAnswer(IMessageBasedSession session)
        {
            session.FormattedIO.WriteLine("READ?\n");
            string answer = session.FormattedIO.ReadLine();
            answer = answer.Replace('.', ',');
            answer = answer.TrimEnd(new char[] { '\r', '\n' });
            return answer;
        }
    }
}
