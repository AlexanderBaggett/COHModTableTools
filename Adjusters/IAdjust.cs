using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjusters
{
    internal interface IScalarAdjust
    {
        bool Adjust(double amount);
    }
    internal interface ITableAdjust
    {
        bool Adjust(double amount, double progressiveIncrement);
    }


    internal interface IPowerAdjuster : IScalarAdjust
    {

    }
    internal interface IPowerSetAdjuster : IScalarAdjust
    {

    }

    internal interface IPowerCategoryAdjuster : IScalarAdjust
    {

    }
    internal interface IArchetypeDefAdjuster : ITableAdjust
    {

    }

    public enum ScalerAdjustmentType
    {
        Add,
        Multiply,
        OneMinus,
        OneOver,
    }


    public enum TableAdjustmentType
    {
        AddToeach,
        MultiplyEachBy,
        SetEachTo,
        ProgressivleAddToeach,
        ProgressiveMultiplyEachBy,
    }

    public enum TableInteropationType
    {
        AverageOf2Tables,
        InteroplationOf2TablesByFactor,
    }

    public static class AdjustmentFunctions
    {


        public static List<double> FillInModTable(double start, double end, double endWeight)
        {
            var difference = end - start;

            var list = new List<double>();
            list.Add(start);

            var startWeight = 1 - endWeight;
            var listOfWeights = new List<double>();
            listOfWeights.Add((double)startWeight);

            var weightDifference = endWeight - startWeight;


            var currentWeight = startWeight;
            for (int i = 1; i < 54; i++)
            {
                currentWeight += weightDifference / 54;
                listOfWeights.Add(currentWeight);
            }
            listOfWeights.Add(endWeight);

            var current = start;
            for (int i = 1; i < 54; i++)
            {
                current += (difference*(listOfWeights[i]*2))  / 54;
                list.Add(current);
            }

            list.Add(end);
            return list.ClampDecimalPlaces(4).ToList();
            
        }

        public static List<double> FillInModTable(double start, double end) //double endWieght
        {
            var difference = end - start;

            var list = new List<double>();
            list.Add(start);

            var current = start;
            for(int i = 1; i < 54; i++)
            {
                current += difference / 54;
                list.Add(current);
            }

            list.Add(end);
            return list.ClampDecimalPlaces(4).ToList();

        }

        /// <summary>
        /// send in negative values for damage tables
        /// </summary>
        /// <param name="start"></param>
        /// <param name="increment"></param>
        /// <param name="incrementGrow"></param>
        /// <returns></returns>
        public static List<double> GenerateModTable(double start, double increment, double incrementGrow)
        {
            var list = new List<double>(); 

            double current = start;
            for(int i = 0; i < 55; i++)
            {
                current += increment;
                increment += incrementGrow;
                list.Add(current);
            }    
            return list.ClampDecimalPlaces(4).ToList();
        }


        public static List<double> ClampModTablePlaces(List<double> table, int places)
        {
            return table.ClampDecimalPlaces(places).ToList();
        }

        public static List<double> TableAdjustmentByType(IEnumerable<double> oldValues, IEnumerable<double> oldValues2, double scalar, TableInteropationType type)
        {
            switch (type)
            {
                case TableInteropationType.AverageOf2Tables:
                    {
                        var oldArray = oldValues.ToArray();
                        var oldArray2 = oldValues2.ToArray();  
                        var newValues = new List<double>();
                        for(int i = 0; i < oldArray.Length; i++)
                        {
                            double newValue = (oldArray[i] + oldArray2[i]) / 2;
                            newValues.Add(newValue);
                        }
                        return newValues.ClampDecimalPlaces(4).ToList();
                    }


                case TableInteropationType.InteroplationOf2TablesByFactor:
                    {
                        var oldArray = oldValues.ToArray();
                        var oldArray2 = oldValues2.ToArray();
                        var inverseScalar = 1 - scalar; //expectation here is that both scalar and inverse scalar are values between 0 and 1
                        var newValues = new List<double>();
                        for(int i = 0; i < oldArray.Length; i++)
                        {
                            double newValue = (oldArray[i]*scalar + oldArray2[i]*inverseScalar);
                            newValues.Add(newValue);
                        }
                        return newValues.ClampDecimalPlaces(4).ToList();
                    }

           
                default: return oldValues.ToList();

            }

        }

        public static double ScalerAdjustByType(double oldValue, double scalar, ScalerAdjustmentType type)
        {
            switch (type)
            {
                case ScalerAdjustmentType.Add: return oldValue + scalar;
                case ScalerAdjustmentType.Multiply: return oldValue * scalar;
                case ScalerAdjustmentType.OneMinus: return 1 - scalar;
                case ScalerAdjustmentType.OneOver: return 1 / scalar;
                default: return oldValue * scalar;

            }

        }
        public static IEnumerable<double> ClampDecimalPlaces(this IEnumerable<double> values, int amount)
        {
            return values.Select(x => Math.Round(x, amount));
        }


        public static List<double> TableAdjustmentByType(IEnumerable<double> oldValues, double scalar, double progressiveIncrementScalar, TableAdjustmentType type)
        {
            switch (type)
            {
                case TableAdjustmentType.AddToeach: 
                        return oldValues.Select(x=> x+ scalar).ClampDecimalPlaces(4).ToList();

                case TableAdjustmentType.MultiplyEachBy: 
                    return oldValues.Select(x => x * scalar).ClampDecimalPlaces(4).ToList();

                case TableAdjustmentType.SetEachTo:
                    return oldValues.Select(x => scalar).ClampDecimalPlaces(4).ToList();

                case TableAdjustmentType.ProgressivleAddToeach:
                    {
                        double currentScalar = scalar;

                        return oldValues.Select(x =>
                        {
                            var val = x + currentScalar;

                            currentScalar += progressiveIncrementScalar;
                            return val;

                        }).ClampDecimalPlaces(4).ToList();
                    }

                case TableAdjustmentType.ProgressiveMultiplyEachBy:
                    {
                        double currentScalar = scalar;

                        return oldValues.Select(x =>
                        {
                            var val = x * currentScalar;

                            currentScalar += progressiveIncrementScalar;
                            return val;

                        }).ClampDecimalPlaces(4).ToList();
                    }
                default: return oldValues.ToList();

            }

        }
    }
}
