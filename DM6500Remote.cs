using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DM6500Remote
{
    public partial class Background : Form
    {
        private const double MIN_DELAY = 0.1;
        private const double MAX_DELAY = 60;
        private const int SECOND = 1000;
        private string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private string _errorMessage = "Wrong input parameters";
        private VirtualMachine _workMachinge;
        private ExcelWritter _excelFile;

        public Background()
        {
            InitializeComponent();
            ChangeDirectory.Text = _folderPath;
        }
        #region UI
        private void ChangeDirectory_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                return;
            _folderPath = FolderBrowserDialog.SelectedPath;
            ChangeDirectory.Text = _folderPath;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (CheckName() == false)
            {
                MessageBox.Show("File name can contatin only letters, numbers and underscore");
                return;
            }
            if (CheckParameters())
            {
                Progress.Value = 0;
                Int32.TryParse(Count.Text, out int value);
                Progress.Maximum = value;
                Progress.Value = 0;
                StartMeasurement();
            }
            else
                MessageBox.Show(_errorMessage);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            _workMachinge.StopExchange();
            StopMeasurement();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if(_excelFile != null)
            {
                _excelFile.SaveFile();
            }
            Application.Exit();
        }

        private void Language_Click(object sender, EventArgs e)
        {

        }
        private void FillTheData(string[] data)
        {
            Current.Text = data[1];
            Temperature.Text = data[2];            
            Progress.Value++;
        }
        #endregion

        private bool CheckParameters()
        {
            bool isCorrect = true;
            isCorrect &= (Int32.TryParse(Count.Text, out int value) & value > 0 & value < Int16.MaxValue);
            isCorrect &= (Double.TryParse(Interval.Text, out double delay) & delay >= MIN_DELAY & delay <= MAX_DELAY);
            return isCorrect;
        }
        private bool CheckName()
        {
            return Regex.IsMatch(FileName.Text, @"^[a-zA-Z0-9_]+$");
        }
        private void ChangeEnableState()
        {
            Start.Enabled = !Start.Enabled;
            Stop.Enabled = !Stop.Enabled;
            Exit.Enabled = !Exit.Enabled;
            CountPanel.Enabled = !CountPanel.Enabled;
            IntervalPanel.Enabled = !IntervalPanel.Enabled;
            CurrentPanel.Enabled = !CurrentPanel.Enabled;
            TemperaturePanel.Enabled = !TemperaturePanel.Enabled;
            ChangeDirectory.Enabled = !ChangeDirectory.Enabled;
            FileName.Enabled = !FileName.Enabled;
            Progress.Enabled = !Progress.Enabled;
        }
        private void StartMeasurement()
        {
            Int32.TryParse(Count.Text, out int amount);
            Double.TryParse(Interval.Text, out double delay);
            if (_excelFile == null)
                _excelFile = new ExcelWritter(_folderPath, FileName.Text, "Current", "Temperature");
            else
                _excelFile.CreateNewList();
           // _workMachinge = new VirtualMachine(delay, amount);
            _workMachinge = new WorkMachine(delay, amount);
            _workMachinge.WriteMessage += ReadMessage;   // Subscription
            _workMachinge.Finish += StopMeasurement;   // Subscription
            _workMachinge.StartExchange();
            ChangeEnableState();
        }

        private void StopMeasurement()
        {
            _excelFile.SaveFile();
            _workMachinge.WriteMessage -= ReadMessage;   // Unsubscription
            _workMachinge.Finish += StopMeasurement;   // Unsubscription
            ChangeEnableState();
        }
        private void ReadMessage(string[] args)
        {
            if (args[0] == "error")
            {
                MessageBox.Show(args[1]);
                return;
            }
            if (args.Length != 3)
            {
                MessageBox.Show(_errorMessage);
                return;
            }
            FillTheData(args);
            double[] data = new double[3];
            Double.TryParse(args[0], out data[0]);
            Double.TryParse(args[1], out data[1]);
            Double.TryParse(args[2], out data[2]);
            _excelFile.AddLine(data);
        }
    }
}
