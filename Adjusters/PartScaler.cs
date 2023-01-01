using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Adjusters
{
    public static class Utils
    {
        public static char space = ' ';

        public static string Spaces(int count)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < count; i++)
            {
                list.Add(space);
            }
            return new string(list.ToArray());
        }

    }

    public static class PartScaler
    {
        //use windows specific newline
        public const string CLRF = "\r\n";
        public static bool Scale (string inputFileName, string outputFileName, double amount)
        {
            var lines = File.ReadAllLines(inputFileName);
            StringBuilder sb = new StringBuilder ();

            foreach (var line in lines)
            {
                //we don't scale colors or mess with comments 
                if (line.StartsWith("#") 
                    || line.ToLower().Contains("color") 
                    || line.ToLower().Contains("system") 
                    || line =="" 
                    || line.ToLower().Contains("alpha"))
                {
                    sb.Append(line);
                    sb.Append(CLRF);
                    continue;
                    
                }
                var correctedLine = line.Replace("\t", "   ");
                var words = correctedLine.Split(' ');
                words = words.Where(x=> x!="").ToArray();
                if(words.Length == 0)
                {
                    sb.Append(line);
                    sb.Append(CLRF);
                    continue;
                }
                var spaceCount = correctedLine.ToArray().Where(c => c.Equals(' ')).Count();

                //There's commented out code that happens after the regular code
                if (words.Length > 2)
                {
                    spaceCount = spaceCount / 2;
                }
                //empty line or single property or binary property
                else if (words.Length == 1 || ContainsBinaryProperties(correctedLine))
                {
                    sb.Append(line);
                    sb.Append(CLRF);
                    continue;
                }

                //its either a 3 value property without comments or a 3 value property with comments
                // but it can't be a 3 value property if some of those values are actually comments
                if( (words.Length == 4 && !words.Any(x=> x.Contains("#")))  || (words.Length > 4 && words.Any(x => x.Contains("#")) ) )
                {
                    process3ValueProperties(correctedLine, words, spaceCount,sb, amount);
                }
                //same idea here for 1 value properties
                else if(words.Length == 2 || (words.Length > 2 && words.Any(x => x.Contains("#"))) )
                {
                    process1ValueProperties(correctedLine, words, spaceCount, sb, amount);
                }

                

                sb.Append(CLRF);

            }
            File.WriteAllText (outputFileName,sb.ToString ());
         
            return true;
        }

        private static void process1ValueProperties(string correctedLine, string[] words, int spaceCount, StringBuilder sb, double amount)
        {
            var propertyName = words[0];
            string propertyValue = GetNextValidValue(words);

            //0 times anything is still 0 no need to change anything
            if (propertyValue == "0")
            {
                sb.Append(correctedLine);
            }
            else
            {
                //its a texture name
                if (propertyValue.Contains(".tga"))
                {
                    sb.Append(correctedLine);
                }
                //It's a decimal value
                else if (propertyValue.Contains("."))
                {
                    var newValue = double.Parse(propertyValue) * amount; ;
                    sb.Append(propertyName + Utils.Spaces(spaceCount) + newValue);
                }

                //It's an integer
                else
                {
                    int newValue = (int)(int.Parse(propertyValue) * amount);
                    sb.Append(propertyName + Utils.Spaces(spaceCount) + newValue);
                }
            }
        }

        private static void process3ValueProperties(string correctedLine, string[] words, int spaceCount, StringBuilder sb, double amount)
        {
            var propertyName = words[0];
            var value1 = words[1];
            var value2 = words[2];
            var value3 = words[3];

            var newValue1 = double.Parse(value1) * amount;
            var newValue2 = double.Parse(value2) * amount; 
            var newValue3 = double.Parse(value3) * amount; 
            sb.Append(propertyName + Utils.Spaces(spaceCount) + newValue1 +" " + newValue2 + " " + newValue3);


        }

        //properties whose values cannot be multiplied eg they can only be a 1 or a 0
        private static readonly string[] BinaryProperties = { 
            "StreakOrient", "StreakDirection", "Blend_mode", "SpinJitter" , "WorldOrLocalPosition",
            "KillOnZero", "TightenUp"
        };

        private static bool ContainsBinaryProperties(string line)
        {
            foreach(var property in BinaryProperties)
            {
                if(line.Contains(property))
                    return true;
            }
            return false;
        }

        private static string GetNextValidValue(string[] words)
        {
           for(int i = 1; i < words.Length; i++)
            {
                if (words[i] == "")
                {
                    continue;
                }
                return words[i];
            }
           return null;
        }
    }
}
