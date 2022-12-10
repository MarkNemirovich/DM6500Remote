using System;
using System.IO;
using System.Linq;
using GemBox.Spreadsheet;

namespace DM6500Remote
{
    internal class ExcelWritter
    {
        const string zerothColumnName = "Time";
        private readonly string _date = DateTime.Today.ToShortDateString().Replace(':', '_');
        private readonly string _directory;
        private readonly string _fileName;
        private int _numberOfMeasurement;
        private int _line;
        private ExcelFile _exelFile;
        private ExcelWorksheet _exelSheet;
        private string[] _title;
        private int _listNumber = 0;
        static ExcelWritter()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public ExcelWritter(string directory, string fileName, string firstColumnName, string secondColumnName)
        {
            _directory = directory;
            _fileName = fileName;
            _exelFile = new ExcelFile();
            
            var list = Directory.GetFiles(_directory);
            foreach (string file in list)
            {
                if (file.Contains($"{_fileName}_{_date}") == true)
                {
                    int start = file.IndexOf('№')+1;
                    int end = file.IndexOf(".xlsx");
                    string number = file.Substring(start, end - start);
                    Int32.TryParse(number, out int num);
                    if (num > _numberOfMeasurement)
                        _numberOfMeasurement = num;
                }
            }
            if (_numberOfMeasurement > 0)
                _numberOfMeasurement++;
            _title = new string[] { zerothColumnName, firstColumnName, secondColumnName };
            CreateNewList();
        }
        public void CreateNewList()
        {
            _exelSheet = _exelFile.Worksheets.Add($"{_fileName}_№{_listNumber}");
            _line = 0;
            AddLine(_title);
            _listNumber++;
        }
        public void AddLine(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                _exelSheet.Cells[_line, i].Value = data[i];
            }
            _line++;
        }
        public void AddLine(double[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                _exelSheet.Cells[_line, i].Value = data[i];
            }
            _line++;
        }
        public void SaveFile()
        {

            _exelFile.Save($"{_directory}/{_fileName}_{_date}_№{_numberOfMeasurement}.xlsx");
        }
    }
}
