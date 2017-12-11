using System;

namespace Na.ConsoleHelper
{
    public enum ConsoleWriteLevel
    {
        Defualt,
        Success,
        Info,
        Warn,
        Error,
    }

    public static class ConsoleHelper
    {
        static ConsoleColor DefaultBackground = ConsoleColor.Black;
        
        public static void ConsoleWrite(this string msg, ConsoleColor? backColor = null, ConsoleColor forColor = ConsoleColor.White)
        {
            ConsoleWrite(msg, ConsoleWriteLevel.Defualt, backColor ?? DefaultBackground, forColor);
        }

        public static void ConsoleSuccess(this string msg, ConsoleColor? backColor = null, ConsoleColor forColor = ConsoleColor.DarkGreen)
        {
            ConsoleWrite(msg, ConsoleWriteLevel.Success, backColor ?? DefaultBackground, forColor);
        }

        public static void ConsoleInfo(this string msg, ConsoleColor? backColor = null, ConsoleColor forColor = ConsoleColor.Cyan)
        {
            ConsoleWrite(msg, ConsoleWriteLevel.Info, backColor ?? DefaultBackground, forColor);
        }

        public static void ConsoleWarn(this string msg, ConsoleColor? backColor = null, ConsoleColor forColor = ConsoleColor.Yellow)
        {
            ConsoleWrite(msg, ConsoleWriteLevel.Warn, backColor ?? DefaultBackground, forColor);
        }

        public static void ConsoleError(this string msg, ConsoleColor? backColor = null, ConsoleColor forColor = ConsoleColor.Red)
        {
            ConsoleWrite(msg, ConsoleWriteLevel.Error, backColor ?? DefaultBackground, forColor);
        }

        private static void ConsoleWrite(string msg, ConsoleWriteLevel level, ConsoleColor backColor, ConsoleColor forColor)
        {
            Console.BackgroundColor = backColor;
            Console.ForegroundColor = forColor;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
