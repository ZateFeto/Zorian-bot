using AmongUsCapture;
using System.Drawing;

namespace ZorianAmongUs
{
    internal class ZorianLogger : IConsoleInterface
    {
        public bool CrackDetected()
        {
            return true;
        }

        public Color getNormalColor()
        {
            return Color.White;
        }

        public void WriteColoredText(string ColoredText)
        {
        }

        public void WriteLine(string s)
        {
        }

        public void WriteModuleTextColored(string ModuleName, Color moduleColor, string text)
        {
        }

        public void WriteTextFormatted(string text, bool acceptNewLines = true)
        {
        }
    }
}