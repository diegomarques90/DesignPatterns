namespace DesignPatterns.Core.BridgePatternExample
{
    public class Careers : IWebPage
    {
        private ITheme _theme { get; set; }

        public Careers(ITheme theme)
        {
            _theme = theme;
        }

        public string GetContent()
        {
            return $"Careers page in {_theme.GetColor()}";
        }
    }
}
