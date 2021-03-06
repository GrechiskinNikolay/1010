﻿using Controllers;
using ControllersConsole;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerWindowsForms
{
  /// <summary>
  /// Базовый класс контроллеров
  /// </summary>
  public abstract class ControllerWindows : Controller
  {
    /// <summary>
    /// Фабричный метод создания контроллера
    /// </summary>
    /// <param name="parEWindows">Идинтификатор типа</param>
    public static ConsoleController CreateController(EWindows parEWindows)
    {
      switch (parEWindows)
      {
        case EWindows.Menu:
          return new ControllerMenuConsole();
        case EWindows.GamePlay:
          return new ControllerGamePlayConsole();
        case EWindows.GameOver:
          return new ControllerGameOverConsole();
        case EWindows.Records:
          return new ControllerRecordsConsole();
        case EWindows.Help:
          return new ControllerHelpConsole();
        default:
          throw new ArgumentException($"No controller \"{parEWindows.ToString()}\"");
      }
    }
  }
}
