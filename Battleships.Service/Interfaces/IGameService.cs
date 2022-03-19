﻿using Battleships.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Service.Interfaces
{
    public interface IGameService
    {
        bool StartGame();
        bool ProcessGuess(int guessX, int guessY);
    }
}
