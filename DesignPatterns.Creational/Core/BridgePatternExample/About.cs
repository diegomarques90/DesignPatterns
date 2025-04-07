using System.Runtime.CompilerServices;

namespace DesignPatterns.Core.BridgePatternExample
{
    public class About : IWebPage
    {
        private ITheme _theme { get; set; }

        public About(ITheme theme)
        {
            _theme = theme;
        }

        public string GetContent()
        {
            return $"About page in {_theme.GetColor()}";
        }
    }
}
