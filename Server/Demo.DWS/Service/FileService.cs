using Demo.DWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DWS.Service
{
    public interface IUnitPriceService
    {
        void AddUnitPriceData(IEnumerable<Input> unitPriceDataList);
        IEnumerable<Output> GetUnitPrices(string unitPriceType);
    }
    public class UnitPriceService : IUnitPriceService
    {
        IPriceServiceCtx _priceServiceCtx;
        IPriceDataService _priceDataService;
        public UnitPriceService(IPriceServiceCtx priceServiceCtx, IPriceDataService priceDataService)
        {
            _priceServiceCtx = priceServiceCtx;
            _priceDataService = priceDataService;
        }
        public void AddUnitPriceData(IEnumerable<Input> unitPriceDataList)
        {
            if (unitPriceDataList == null || unitPriceDataList.Count() == 0)
                return;
            try
            {
                _priceDataService.AddUnitPriceData(unitPriceDataList);
            }
            catch (Exception)
            {
                //shout/catch/throw/log
            }
        }
        public IEnumerable<Output> GetUnitPrices(string unitPriceType)
        {
            try
            {
                return _priceServiceCtx.GetUnitPrices(unitPriceType);
            }
            catch (Exception)
            {
                return null; //shout/catch/throw/log
            }
        }
    }
}
