using UtilitiesProject.Data;
using UtilitiesProject.Models;

namespace UtilitiesProject.Services
{
    public class UtilityService
    {
        private readonly UtilityContext _context = default!;
        public UtilityService(UtilityContext context)
        {
            _context = context;
        }

        public IList<Utility> GetUtilities()
        {
            if (_context.Utilities != null)
            {
                return _context.Utilities.ToList();
            }
            return new List<Utility>();
        }

        public void AddUtility(Utility utility)
        {
            if (_context.Utilities != null)
            {
                _context.Utilities.Add(utility);
                _context.SaveChanges();
            }
        }

        public void DeleteUtility(int id)
        {
            if (_context.Utilities != null)
            {
                var utility = _context.Utilities.Find(id);
                if (utility != null)
                {
                    _context.Utilities.Remove(utility);
                    _context.SaveChanges();
                }
            }
        }
    }
}
