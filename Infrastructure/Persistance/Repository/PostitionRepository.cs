using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models
{
    public class PositionRepository : IPositionRepository
    {
        private readonly EFContext context;
        public PositionRepository(EFContext context)
        {
            this.context = context;
        }

        public void createPosition(Position Position)
        {
            context.Positions.Add(Position);
            context.SaveChanges();
        }

        public void editPosition(Position Position)
        {
            context.Positions.Update(Position);
            context.SaveChanges();
        }

        public Position findByID(int id)
        {
            return context.Positions.Find(id);
        }

        // =========================================================

        public IEnumerable<Position> Positions()
        {
            return context.Positions.ToList();
        }

        public void removePosition(int id)
        {
            var Position = context.Positions.Find(id);
            context.Positions.Remove(Position);
            context.SaveChanges();
        }
    }
}
