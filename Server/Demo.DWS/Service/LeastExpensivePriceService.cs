using Demo.DWS.Data;
using Demo.DWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DWS.Service
{
    public interface ILeastExpensivePriceService : IPriceService
    {
    }
    public class LeastExpensivePriceService : PriceService, ILeastExpensivePriceService
    {
        public LeastExpensivePriceService(DataContext context) : base(context)
        {
        }

        public IEnumerable<Output> GetUnitPrices()
        {
            IEnumerable<Output> result = default(IEnumerable<Output>);

            try
            {
                var unitPrices = _context.Input.AsEnumerable().OrderBy(p => decimal.Parse(p.UnitPrice)).Take(5);
                result= unitPrices.Select(i => new Output { UnitPrice = i.UnitPrice });
            }
            catch (Exception)
            {
                //shout/catch/throw/log
            }
            return result;
        }
    }
}
