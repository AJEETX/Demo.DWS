using Demo.DWS.Data;
using Demo.DWS.Model;
using System.Collections.Generic;

namespace Demo.DWS.Service
{
    public interface IPriceService
    {
        IEnumerable<Output> GetUnitPrices();
    }
    public abstract class PriceService
    {
        protected DataContext _context;
        public PriceService(DataContext context)
        {
            _context = context;
        }
    }
}
