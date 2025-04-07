namespace DesignPatterns.Core.BridgePatternExample
{
    public class LightTheme : ITheme
    {
        public string GetColor()
        {
            return "Off white";
        }
    }
}
