using System;
using System.Reflection;
using System.Threading;
using Ivi.Visa;
using NationalInstruments.Restricted;
using NationalInstruments.Visa;
using static System.Collections.Specialized.BitVector32;

namespace DM6500Remote
{
    internal class VirtualMachine
    {
        private const int SECOND = 1000;
        private readonly int _delay;
        private readonly int _amount;
        private string deviceID;            // = "USB0::0x05E6::0x6500::04531633::INSTR";
        private Ivi.Visa.IMessageBasedSession session;

        public delegate void Message(string[] str);
        public event Message WriteMessage;
        public event Action Finish;

        public VirtualMachine(int delay, int amount) 
        { 
            _delay = delay;
            _amount = amount;
            GetVisaResourceName();
            Thread.Sleep(SECOND); // wait 1 sec
            try
            {
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

        private void StartExchange()
        {
            string[] data = new string[2];
            session.FormattedIO.WriteLine("*RST\n");
            for (int i = 0; i < _amount; i++)
            {
                data[0] = VoltageMeasurement(session);
                data[1] += SetTemperatureMeasurement(session);
                Thread.Sleep((_delay));
                WriteMessage?.Invoke(data);
            }
            StopExchange();
        }
        private void StopExchange()
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
