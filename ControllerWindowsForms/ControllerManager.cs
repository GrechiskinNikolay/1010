﻿using Controllers;
using ControllerWindowsForms;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewWindowsForms;

namespace ControllerWindowsForms
{
  public class ControllerManager : Controller
  {
    private EWindows _nextWindow;
    private readonly Object _lockNextWindow = new Object();
    public EWindows NextWindow
    {
      get
      {
        lock (_lockNextWindow)
        {
          return _nextWindow;
        }
      }
      set
      {
        lock (_lockNextWindow)
        {
          _nextWindow = value;
          _changeWindow = true;
        }
      }
    }
    private volatile bool _changeWindow = false;
    private ControllerWindows _controllerWindows;
    /// <summary>
    /// Объект менеджера
    /// </summary>
    private static ControllerManager _instance = null;
    /// <summary>
    /// Приватный конструктор
    /// </summary>
    private ControllerManager() { }
    /// <summary>
    /// Метод получения экземпляра 
    /// </summary>
    /// <returns></returns>
    public static ControllerManager GetInstance()
    {
      if (_instance == null)
        _instance = new ControllerManager();
      return _instance;
    }

    public EWindows Execute()
    {
      ControllerCreatorWindows controllerCreatorWindows = new ControllerCreatorWindows();
      Controller controller = new ControllerMenuWindows();
      while (true)
      {
        while (!_changeWindow)
        {
          Thread.Sleep(100);
        }
        _changeWindow = false;
        if (NextWindow == EWindows.Exit)
        {
          break;
        }
        controller = controllerCreatorWindows.GetController(NextWindow);
      }
      return EWindows.Exit;
    }
  }
}