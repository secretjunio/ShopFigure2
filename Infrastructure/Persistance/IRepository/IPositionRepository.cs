using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public interface IPositionRepository
    {
        IEnumerable<Position> Positions();
        Position findByID(int id);
        void createPosition(Position Position);
        void editPosition(Position Position);
        void removePosition(int id);
    }
}
