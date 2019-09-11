using Demo.DWS.Data;
using Demo.DWS.Model;
using System.Collections.Generic;
using System.Linq;
using System;
namespace Demo.DWS.Service
{
    public interface IMostExpensivePriceService : IPriceService
    {
    }
    public class MostExpensivePriceService : PriceService, IMostExpensivePriceService
    {
        public MostExpensivePriceService(DataContext context) : base(context)
        {
        }

        public IEnumerable<Output> GetUnitPrices()
        {
            IEnumerable<Output> result = default(IEnumerable<Output>);

            try
            {
                var unitPrices = _context.Input.AsEnumerable().OrderByDescending(p => decimal.Parse(p.UnitPrice)).Take(5);
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
