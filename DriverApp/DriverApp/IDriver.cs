namespace DriverApp
{
    public interface IDriver
    {
        string Name { get; }
        string TeamName { get; }
        int CarId { get; }
        Stats GetStats();
        void AddPoints(int position);
        void AddPoints(string position);
        void AddPoints(float points);
    }
}
