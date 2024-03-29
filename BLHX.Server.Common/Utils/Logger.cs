﻿using System.Diagnostics;

namespace BLHX.Server.Common.Utils
{
    public class Logger
    {
        public static readonly Logger c = new("BLHX.Server", ConsoleColor.Blue);
        private readonly string _name;
        private readonly bool TraceOnError;
        private readonly ConsoleColor _color;

        public Logger(string name, ConsoleColor color = ConsoleColor.Cyan, bool traceOnError = true)
        {
            _name = name;
            _color = color;
            TraceOnError = traceOnError;
        }

        public void Log(params string[] message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(DateTime.Now.ToString("HH:mm:ss "));
            Console.ResetColor();
            Console.Write("<");
            Console.ForegroundColor = _color;
            Console.Write(_name);
            Console.ResetColor();
            Console.Write("> ");
            Console.Write(string.Join("\t", message.Append(Environment.NewLine)));
            Console.ResetColor();
        }

        public void Warn(params string[] message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(DateTime.Now.ToString("HH:mm:ss "));
            Console.ResetColor();
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(_name);
            Console.ResetColor();
            Console.Write("> ");
            Console.Write(string.Join("\t", message.Append(Environment.NewLine)));
            Console.ResetColor();
        }

        public void Trail(params string[] msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"\t└── {string.Join(' ', msg)}\n");
            Console.ResetColor();
        }

        public void Error(params string[] message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(DateTime.Now.ToString("HH:mm:ss "));
            Console.ResetColor();
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(_name);
            Console.ResetColor();
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;
            if (TraceOnError)
                Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(string.Join("\t", message.Append(Environment.NewLine)));
            Console.ResetColor();
#if DEBUG
            StackTrace trace = new(true);
            if (TraceOnError)
                Trail(trace.ToString());
#endif
        }

        public void Debug(params string[] message)
        {
#if DEBUG
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(DateTime.Now.ToString("HH:mm:ss "));
            Console.ResetColor();
            Console.Write("<");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(_name);
            Console.ResetColor();
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Write(string.Join("\t", message.Append(Environment.NewLine)));
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;

            StackTrace trace = new(true);
            if (TraceOnError)
                Trail(trace.ToString());
#endif
        }
    }
}
