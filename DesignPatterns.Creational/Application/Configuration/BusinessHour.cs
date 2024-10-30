namespace DesignPatterns.Creational.Application.Configuration
{
    public class BusinessHour
    {
        private static BusinessHour _instance;

        private BusinessHour(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public static BusinessHour GetInstance()
        {
            if (_instance is null)
            {
                _instance = new BusinessHour(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 19, 0, 0));

                Console.WriteLine($"New instance of {nameof(BusinessHour)} created!");
            }

            return _instance;
        }
    }
}
