﻿using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewWindowsForms;

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
    public static ControllerWindows CreateController(EWindows parEWindows)
    {
      switch (parEWindows)
      {
        case EWindows.Menu:
          return new ControllerMenuWindows();
        case EWindows.GamePlay:
          return new ControllerGamePlayWindows();
        case EWindows.GameOver:
          return new ControllerGameOverWindows();
        case EWindows.Records:
          return new ControllerRecordsWindows();
        case EWindows.Help:
          return new ControllerHelpWindows();
        default:
          throw new ArgumentException($"No controller \"{parEWindows.ToString()}\"");
      }
    }
  }
}
