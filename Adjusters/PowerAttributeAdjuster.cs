using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjusters
{
    public class PowerAttributeAdjuster : IPowerSetAdjuster
    {
        public string PowerSetFilePath { get; set; }
        public string PowerAttributeName { get; set; }

        public ScalerAdjustmentType AdjustmentType { get; set; }

        public PowerAttributeAdjuster(string powerSetFilePath, string powerAttributeName, ScalerAdjustmentType adjustmentType)
        {
            this.PowerSetFilePath = powerSetFilePath;
            this.PowerAttributeName = powerAttributeName;
            this.AdjustmentType = adjustmentType;
        }

        //public static char space = ' ';

        //public static string Spaces(int count)
        //{
        //    List<char> list = new List<char>();
        //    for (int i = 0; i < count; i++)
        //    {
        //        list.Add(space);
        //    }
        //    return new string(list.ToArray());
        //}


        public bool Adjust(double amount)
        {
            var lines = PowerTraverser.GetLines(PowerSetFilePath);

            var newLines = new List<string>();
            foreach (var line in lines)
            {
                if (line.Contains(PowerAttributeName))
                {
                    var spaceCount = line.ToArray().Where(c => c.Equals(" ")).Count();
                    var split = line.Split(' ');
                    var oldValue = double.Parse(split[1]); //the attribute's value
                    var newValue = AdjustmentFunctions.ScalerAdjustByType(oldValue, amount, this.AdjustmentType);
                    var newLine = split[0] + Utils.Spaces(spaceCount) + newValue.ToString();

                    newLines.Add(newLine);
                }
                else
                {
                    newLines.Add(line);
                }
            }
            PowerTraverser.SetLines(PowerSetFilePath, newLines.ToArray());

            return true;

        }
    }
}
