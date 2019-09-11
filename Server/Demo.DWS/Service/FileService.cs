using Demo.DWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DWS.Service
{
    public interface IFileService
    {
        IEnumerable<Output> GetUnitPrices(string unitPriceType);
        void AddFileData(IEnumerable<Input> fileData);
    }
    public class FileService : IFileService
    {
        IPriceServiceCtx _priceServiceCtx;
        IFileDataService _fileDataService;
        public FileService(IPriceServiceCtx priceServiceCtx, IFileDataService fileDataService)
        {
            _priceServiceCtx = priceServiceCtx;
            _fileDataService = fileDataService;
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
        public void AddFileData(IEnumerable<Input> fileData)
        {
            if (fileData == null || fileData.Count() == 0)
                return;
            try
            {
                _fileDataService.AddFileData(fileData);
            }
            catch (Exception)
            {
                //shout/catch/throw/log
            }
        }
    }
}
