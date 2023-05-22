using System.Runtime.CompilerServices;

namespace DriverApp
{
    public class Stats
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int  Count { get; private set; }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public float AveragePosition
        {
            get
            {
                return this.Average / (this.Count*100);
            }
        }

        public Stats()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = int.MinValue;
            this.Min = int.MaxValue;
        }

        public void AddPoints(float point)
        {
            this.Count++;
            this.Sum += point;
            this.Max = Math.Max(this.Max, point);
            this.Min = Math.Min(this.Min, point);
        }
    }
}
