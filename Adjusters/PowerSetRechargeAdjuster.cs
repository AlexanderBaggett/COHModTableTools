namespace Adjusters
{
    public class PowerSetRechargeAdjuster : PowerAttributeAdjuster
    { 

        public PowerSetRechargeAdjuster(string powerSetName) : base(powerSetName, "RechargeTime", ScalerAdjustmentType.Multiply)
        {
            this.PowerSetFilePath = PowerSetFilePath;
        }

    }
}