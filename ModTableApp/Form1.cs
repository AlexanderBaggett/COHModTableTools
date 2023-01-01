namespace PowerAdjustmentApp
{
    using System.Text;
    using Adjusters;
    using static Adjusters.AdjustmentFunctions;
    public partial class Form1 : Form
    {

        string FxFile1 = "";
        string FxFile2 = "";
        public Form1()
        {
            InitializeComponent();
            ModTableAdjustmentTypeDropdown.SelectedIndex = 0;
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillInModTableButton_Click(object sender, EventArgs e)
        {
            try
            {
                var start = ParseDoubleOrZero(FillInModTableStartTextBox.Text);
                var end = ParseDoubleOrZero(FillInModTableEndTextBox.Text);
                var endweight = ParseDoubleOrZero(FillInModTableEndWeightTextBox.Text);

                var result = FillInModTable(start, end, endweight);

                FillInModTableResultTextBox.Text = ToCSV(result);
            }
            catch
            {
                FillInModTableResultTextBox.Text = "Failed. Values must be parsable as a double";
            }
        }

        private string ToCSV (List<double> modTable)
        {

            var csv = modTable.Select(x => x.ToString() + ",").ToArray();

            var sb = new StringBuilder();

            for(int i = 0; i < csv.Length; i++)
            {
                if(i == csv.Length -1)
                {
                    var s = new string(csv[i].Where(x => !char.Equals(x, ',')).ToArray());
                    sb.Append(s);
                }
                else
                {
                    sb.Append(csv[i]);
                }

            }
            return sb.ToString();
        }
        private List<double> FromCSV(string csv)
        {
            var split = csv.Split(',');
            var result = new List<double>();
            foreach(var line in split)
            {
                result.Add(ParseDoubleOrZero(line.Trim()));
            }
            return result;
        }

        private double ParseDoubleOrZero (string input)
        {
            var success = double.TryParse(input, out double result);

            if(success)
                return result;

            return 0;
        }
        private TableAdjustmentType ParseTableAdjustment(string text)
        {
            if (text == "Add To Each")
                return TableAdjustmentType.AddToeach;
            else if (text == "Multiply Each By")
                return TableAdjustmentType.MultiplyEachBy;
            else if (text == "Set Each To")
                return TableAdjustmentType.SetEachTo;
            else if (text == "Progressively Add to Each")
                return TableAdjustmentType.ProgressivleAddToeach;

            else throw new Exception("Bad adjustment type");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var table = FromCSV(ModTableAdustTableTextbox.Text);
                var scalar = ParseDoubleOrZero(ModTableAdjustScalarTextbox.Text);
                var increment = ParseDoubleOrZero(ModTableAdjustIncrementTextbox.Text);

                var adjustmentType = ParseTableAdjustment(ModTableAdjustmentTypeDropdown.SelectedItem.ToString()??"");


                var result = TableAdjustmentByType(table,scalar,increment,adjustmentType);


                ModTableAdjustmentResultTextbox.Text = ToCSV(result);
            }
            catch (Exception ex)
            {
                ModTableAdjustmentResultTextbox.Text = ex.Message; 
            }

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var modtable1 = FromCSV(textBox17.Text);
            var modtable2 = FromCSV(textBox15.Text);

           var result =  TableAdjustmentByType(modtable1, modtable2, 0, TableInteropationType.AverageOf2Tables);

            textBox16.Text = ToCSV(result);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var modtable1 = FromCSV(textBox18.Text);
            var modtable2 = FromCSV(textBox19.Text);
            var weight = ParseDoubleOrZero(textBox21.Text);

            var result = TableAdjustmentByType(modtable1, modtable2, weight, TableInteropationType.InteroplationOf2TablesByFactor);

            textBox14.Text = ToCSV(result);
        }

        private void intsToDoublesConverterButton_Click(object sender, EventArgs e)
        {
            var doubles = FromCSV(doublesIn.Text);

            var result = doubles.Select(x => (int)x)
                .Select(x => (double)x).ToList();

            intsOut.Text = ToCSV(result);

        }

        private void GenerateModTableButton_Click(object sender, EventArgs e)
        {
            var start = ParseDoubleOrZero(GenerateModTableStartTextBox.Text);
            var increment = ParseDoubleOrZero(GenerateModTableIncrementTextBox.Text);
            var grow = ParseDoubleOrZero(GenerateModTableIncrementGrowTextBox.Text);

           var result =  GenerateModTable(start, increment, grow);
            GenerateModTableResultTextBox.Text = ToCSV(result);
        }

        private void ClampModTableResultTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClampModTableGoButton_Click(object sender, EventArgs e)
        {
            var table = FromCSV(ClampModTableTextbox.Text);
            int decimalPlaces = (int)ParseDoubleOrZero(ClampModTablePlacesTextBox.Text);

            var result = ClampModTablePlaces(table, decimalPlaces);

            ClampModTableResultTextBox.Text = ToCSV(result);
        }
    }


}