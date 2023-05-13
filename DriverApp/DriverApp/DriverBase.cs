namespace DriverApp
{
    public abstract class DriverBase : IDriver
    {
        public DriverBase(string name, string TeamName, int CarId)
        {
            this.Name = name;
            this.TeamName = TeamName;
            this.CarId = CarId;
        }
        public string Name { get; private set; }
        public string TeamName { get; private set; }
        public int CarId { get; private set; }
        public abstract Stats GetStats();
        public abstract void AddPoints(int position);
        public abstract void AddPoints(string position);
        

        public delegate void PointsAddedDelegate (object sender, EventArgs args);
        public abstract event PointsAddedDelegate PointsAdded;
        public delegate void PositionWithoutPoints (object sender, EventArgs args);
        public abstract event PositionWithoutPoints PointsNotAdded;
    }
}
