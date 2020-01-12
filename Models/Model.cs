﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Model
  {
    protected ScoreManager _scoresManager = new ScoreManager();

    public List<KeyValuePair<string, int>> SortedScores
    {
      get
      {
        return _scoresManager.GetScores().OrderByDescending(i => i.Value).ToList();
      }
    }
    public bool IsRunning { get; set; }
  }
}
