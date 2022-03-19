using Battleships.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Service.Interfaces
{
    public interface IBoardBuilder
    {
        List<List<BoardCell>> BuildBoard(int xAmount, int yAmount);
    }
}
