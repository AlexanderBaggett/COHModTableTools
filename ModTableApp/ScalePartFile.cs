using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Adjusters;
using PowerAdjustmentApp;
using static Adjusters.AdjustmentFunctions;

namespace ModTableApp
{
    public partial class ScalePartFile : Form
    {
        string FxFile1 = "";
        string FxFile2 = "";
        public ScalePartFile()
        {
            InitializeComponent();
        }


        private string OpenOrSaveFile(string filetype, bool open)
        {
            FileDialog dialogue = open ? new OpenFileDialog() : new SaveFileDialog();
            dialogue.Filter = filetype;
            dialogue.Title = "Choose a file";


            DialogResult dialogResult = dialogue.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                return dialogue.FileName;
            }
            return "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FxFile1 = OpenOrSaveFile(FileTypes.Partfile, true);
        }



        private void ScaleFxOutputButton_Click(object sender, EventArgs e)
        {
            FxFile2 = OpenOrSaveFile(FileTypes.Partfile, false);
        }

        private void ScaleFxGoButton_Click(object sender, EventArgs e)
        {
            PartScaler.Scale(FxFile1, FxFile2, ParseDoubleOrZero(FxScaleAmountTextBox.Text));
        }

        private double ParseDoubleOrZero(string input)
        {
            var success = double.TryParse(input, out double result);

            if (success)
                return result;

            return 0;
        }

    }
}
