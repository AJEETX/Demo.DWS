using Demo.DWS.Data;
using Demo.DWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DWS.Service
{
    public interface IPriceDataService
    {
        void AddUnitPriceData(IEnumerable<Input> unitPriceDataList);
    }
    public class PriceDataService : PriceServiceBase, IPriceDataService
    {
        public PriceDataService(DataContext context) : base(context)
        {

        }
        public void AddUnitPriceData(IEnumerable<Input> unitPriceDataList)
        {
            try
            {
                _context.AddRange(unitPriceDataList);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                //shout/catch/throw/log
            }
        }
    }
}
