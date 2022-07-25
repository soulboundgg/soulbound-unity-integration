using UnityEngine;
using System;
namespace SoulBound
{
  public class Logger
  {

    private static int logLevel = LogLevel.INFO;

    public static void Init(int _logLevel)
    {
      if (_logLevel < LogLevel.NONE)
      {
        _logLevel = LogLevel.NONE;
      }
      if (_logLevel > LogLevel.VERBOSE)
      {
        _logLevel = LogLevel.VERBOSE;
      }
      logLevel = _logLevel;
    }

    public static void LogError(string message)
    {
      if (logLevel >= LogLevel.ERROR)
      {
        Console.Write(_WrapMessage("Error", message));
      }
    }

    public static void LogWarn(string message)
    {
      if (logLevel >= LogLevel.WARN)
      {
                Console.Write(_WrapMessage("Warning", message));
      }
    }

    public static void LogInfo(string message)
    {
      if (logLevel >= LogLevel.INFO)
      {
                Console.Write(_WrapMessage("Info", message));
      }
    }

    public static void LogDebug(string message)
    {
      if (logLevel >= LogLevel.DEBUG)
      {
                Console.Write(_WrapMessage("Debug", message));
      }
    }


    private static string _WrapMessage(string type, string message)
    {
      return "SDK: " + type + ": " + message;
    }
  }

  public static class LogLevel
  {
    public static int VERBOSE = 5;
    public static int DEBUG = 4;
    public static int INFO = 3;
    public static int WARN = 2;
    public static int ERROR = 1;
    public static int NONE = 0;
  }
}
