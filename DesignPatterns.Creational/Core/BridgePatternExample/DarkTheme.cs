namespace DesignPatterns.Core.BridgePatternExample
{
    public class DarkTheme : ITheme
    {
        public string GetColor()
        {
            return "Dark Black";
        }
    }
}
