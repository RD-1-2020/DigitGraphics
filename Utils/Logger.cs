﻿using System;
using System.Diagnostics;

namespace DigitGraphics.Utils
{
    static class Logger
    {
        public static void info(String info)
        {
            Debug.WriteLine($"[INFO]: {info}.");
        }

        public static void error(String exceptionText)
        {
            Debug.WriteLine($"[ERROR]: {exceptionText}.");
        }

        public static void error(String exceptionText, Exception ex)
        {
            Debug.WriteLine($"[ERROR]: {exceptionText}\n[Exception]: {ex.Message}\n{ex.StackTrace}.");
        }
    }
}
