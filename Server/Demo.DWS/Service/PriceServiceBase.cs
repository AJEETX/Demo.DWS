using Demo.DWS.Data;
using Demo.DWS.Model;
using System.Collections.Generic;

namespace Demo.DWS.Service
{
    public interface IPriceService
    {
        IEnumerable<Output> GetUnitPrices();
    }
    public abstract class PriceServiceBase
    {
        protected DataContext _context;
        public PriceServiceBase(DataContext context)
        {
            _context = context;
        }
    }
}
