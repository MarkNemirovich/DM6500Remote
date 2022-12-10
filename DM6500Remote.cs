using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DM6500Remote
{
    public partial class Background : Form
    {
        private const double MIN_DELAY = 0.1;
        private const double MAX_DELAY = 60;
        private const int SECOND = 1000;
        private string errorMessage = "Wrong input parameters";
        private VirtualMachine workMachinge;

        public Background()
        {
            InitializeComponent();
        }
        #region UI

        private void Start_Click(object sender, EventArgs e)
        {
            if (CheckParameters())
            {
                Progress.Value = 0;
                Int32.TryParse(Count.Text, out int value);
                Progress.Maximum = value;
                StartMeasurement();
            }
            else
                MessageBox.Show(errorMessage);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            ChangeEnableState();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Language_Click(object sender, EventArgs e)
        {

        }
        private void FillTheData(string[] data)
        {
            Voltage.Text = data[0];
            Temperature.Text = data[1];            
            Progress.Value++;
        }
        #endregion

        private bool CheckParameters()
        {
            bool isCorrect = true;
            isCorrect &= (Int32.TryParse(Count.Text, out int value) & value > 0 & value < Int16.MaxValue);
            isCorrect &= (Double.TryParse(Interval.Text, out double delay) & delay > MIN_DELAY & delay < MAX_DELAY);
            return isCorrect;
        }
        private void ChangeEnableState()
        {
            Start.Enabled = !Start.Enabled;
            Stop.Enabled = !Stop.Enabled;
            Exit.Enabled = !Exit.Enabled;
            CountPanel.Enabled = !CountPanel.Enabled;
            IntervalPanel.Enabled = !IntervalPanel.Enabled;
            VoltagePanel.Enabled = !VoltagePanel.Enabled;
            TemperaturePanel.Enabled = !TemperaturePanel.Enabled;
        }
        private void StartMeasurement()
        {
            Int32.TryParse(Count.Text, out int amount);
            Double.TryParse(Interval.Text, out double delay);
            workMachinge = new VirtualMachine((int)(SECOND * delay), amount);
            workMachinge.WriteMessage += ReadMessage;   // Subscription
            ChangeEnableState();
        }

        private void StopMeasurement()
        {
            workMachinge.WriteMessage -= ReadMessage;   // Unsubscription
            ChangeEnableState();
        }
        private void ReadMessage(string[] args)
        {
            if (args.Length != 2)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (args[0] == "error")
            {
                MessageBox.Show(args[1]);
                return;
            }
            FillTheData(args);
            Double.TryParse(args[0], out double voltage);
            Double.TryParse(args[1], out double temperature);
        }
    }
}
