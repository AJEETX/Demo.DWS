using Demo.DWS.Data;
using Demo.DWS.Model;
using System.Collections.Generic;
using System.Linq;
using System;
namespace Demo.DWS.Service
{
    public interface IAllPriceService : IPriceService
    {
    }
    public class AllPriceService : PriceServiceBase, IAllPriceService
    {
        public AllPriceService(DataContext context) : base(context)
        {
        }

        public IEnumerable<Output> GetUnitPrices()
        {
            IEnumerable<Output> result = default(IEnumerable<Output>);
            try
            {
                var unitPrices = _context.Input.AsEnumerable().OrderByDescending(p => p.Date);
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
