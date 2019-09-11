using Demo.DWS.Model;
using System.Collections.Generic;

namespace Demo.DWS.Service
{
    public interface IPriceServiceCtx
    {
        IEnumerable<Output> GetUnitPrices(string unitPriceType);
    }
    public class PriceServiceCtx : IPriceServiceCtx
    {
        const string mostExpensive = "mostexpensive";
        const string leastExpensive = "leastexpensive";
        Dictionary<string, IPriceService> dict = new Dictionary<string, IPriceService>();

        public PriceServiceCtx(IAllPriceService allPriceService, IMostExpensivePriceService mostExpensivePriceService,ILeastExpensivePriceService leastExpensivePriceService)
        {
            dict.Add(string.Empty, allPriceService);
            dict.Add(mostExpensive, mostExpensivePriceService);
            dict.Add(leastExpensive, leastExpensivePriceService);
        }
        public IEnumerable<Output> GetUnitPrices(string unitPriceType)
        {
            IEnumerable<Output> result = default(IEnumerable<Output>);
            try
            {
                result= dict[unitPriceType].GetUnitPrices();
            }
            catch (System.Exception)
            {
                //shout/catch/throw/log
            }
            return result;
        }
    }
}
