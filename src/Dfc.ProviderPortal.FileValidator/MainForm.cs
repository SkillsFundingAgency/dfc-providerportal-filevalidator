using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dfc.Providerportal.FileValidator
{
    public partial class MainForm : Form
    {
        private const int _larsCharacterLength = 8;
        private const string _larsHeader = "LARS_QAN";
        private const string _courseNameHeader = "COURSE_NAME";

        public MainForm()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileLocation = new OpenFileDialog
            {
                CheckPathExists = true,
                CheckFileExists = true,
                Multiselect = false,
                Filter = "CSV files |*.csv"
            };

            if (fileLocation.ShowDialog() == DialogResult.OK)
            {
                selectFileTextBox.Text = fileLocation.FileName;
            }
        }

        private void ValidateFileButton_Click(object sender, EventArgs e)
        {
            string file = selectFileTextBox.Text;

            if (File.Exists(file))
            {

                try
                {
                    outputTextBox.Clear();

                    using (var reader = new StreamReader(file))
                    {
                        using (var csv = new CsvReader(reader))
                        {

                            csv.Read();
                            csv.ReadHeader();
                            bool isHeaderValidated = ValidateHeader(csv.Context.NamedIndexes.Select(x => x.Key).ToArray());
                            while (csv.Read())
                            {
                                if(isHeaderValidated)
                                {
                                    ValidateLARSNumber(csv.GetField(_larsHeader).Trim(), csv.Context.RawRow);
                                    ValidateCourseName(csv.GetField(_courseNameHeader).Trim(), csv.Context.RawRow);
                                }
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    AppendTextBox($"Could not continue processing. Stopping validation. Error: {ex} ");
                }
                finally
                {
                    if (string.IsNullOrEmpty(outputTextBox.Text))
                    {
                        AppendTextBox($"File validation completed successfully. File is ready to be uploaded to Course Directory.");
                    }
                }
            }
            else
            {
                AppendTextBox("Could not find file, please ensure the file, and path are correct");
            }

        }
        private void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            outputTextBox.Text += $"{value}\r\n";
        }
        private bool ValidateHeader(string[] headerItems)
        {
            string[] requiredHeaders =
            {
                "LARS_QAN", "WHO_IS_THIS_COURSE_FOR", "ENTRY_REQUIREMENTS",
                "WHAT_YOU_WILL_LEARN" , "HOW_YOU_WILL_LEARN", "WHAT_YOU_WILL_NEED_TO_BRING",
                "HOW_YOU_WILL_BE_ASSESSED", "WHERE_NEXT", "ADVANCED_LEARNER_OPTION",
                "ADULT_EDUCATION_BUDGET", "COURSE_NAME", "ID", "DELIVERY_MODE",
                "START_DATE", "FLEXIBLE_START_DATE", "VENUE",
                "NATIONAL_DELIVERY", "REGION", "SUB_REGION",
                "URL", "COST", "COST_DESCRIPTION",
                "DURATION", "DURATION_UNIT", "STUDY_MODE", "ATTENDANCE_PATTERN"
            };

            var missingItems = requiredHeaders.Except(headerItems);
            if (missingItems.Any())
            {
                AppendTextBox($"Line 1: The following headers are missing: {string.Join(", ", missingItems)}. Please resolve, and re-run validation.");
                return false;
            }
            return true;
        }
        private void ValidateLARSNumber(string LARS, int lineCounter)
        {
            if (LARS.Length != _larsCharacterLength)
                AppendTextBox($"Line {lineCounter}: LARS reference is invalid");

        }
        private void ValidateCourseName(string courseName, int lineCounter)
        {
            if (courseName.Length == 0)
                AppendTextBox($"Line {lineCounter}: Empty Course Name");

        }
    }
}
