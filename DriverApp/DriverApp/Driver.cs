using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverApp
{ 
    public class Driver : DriverBase
    {
        public Driver(string name, string TeamName, int CarId):base(name, TeamName, CarId) { }
        public override event PointsAddedDelegate PointsAdded;
        public override event PositionWithoutPoints PointsNotAdded;
        private List<float> points = new List<float>();
        public override void AddPoints(float points)
        {
            if (points == 0)
            {
                this.points.Add(0); 
                if (PointsNotAdded != null)
                {
                    PointsNotAdded(this, new EventArgs()); //brak punktow za to miejsce
                }
            }
            else if (points > 0 && points <=100) 
            {
                this.points.Add(points);
                if (PointsAdded != null)
                {
                    PointsAdded(this, new EventArgs());
                }

            }
            else
            {
                throw new Exception("Invalid points value");
            }
                
            }
        public override void AddPoints(int position)
        {
            float pointAsFloat = (float)position;
            this.AddPoints(pointAsFloat);
        }
        public override void AddPoints(string position)
        {
            if (position.Contains("."))
            {
                string positionWithoutStep = position.Remove(position.IndexOf("."));
                int.TryParse(positionWithoutStep, out int result);
                if (result >= 1 && result <= 20)
                {
                    switch (result)
                    {
                        case 1: AddPoints(100); break;
                        case 2: AddPoints(72); break;
                        case 3: AddPoints(60); break;
                        case 4: AddPoints(48); break;
                        case 5: AddPoints(40); break;
                        default: AddPoints(0); break; //brak punktow za inne miejsca
                    }
                }
                else
                {
                    throw new Exception($"Your {result} position is wrong");
                }
            }
            else if (float.TryParse(position, out float result))
            {
                this.AddPoints(result);
            }
            
        }

        public override Stats GetStats()
        {
            var stats = new Stats();

            foreach (float point in this.points)
            {
                stats.AddPoints(point);
            }


            return stats;
        }
    }
}
