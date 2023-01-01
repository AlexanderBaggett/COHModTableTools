using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerAdjustmentApp
{
    public partial class InputAndOutputSet : UserControl
    {
        Action buttonAction  = null;
        public InputAndOutputSet(string FirstLabel, Action AdjusterFunction)
        {
            label1.Text = FirstLabel;
            buttonAction = AdjusterFunction;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonAction.Invoke();
        }
    }
}
