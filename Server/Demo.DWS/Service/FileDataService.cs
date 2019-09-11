using Demo.DWS.Data;
using Demo.DWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DWS.Service
{
    public interface IFileDataService
    {
        void AddFileData(IEnumerable<Input> model);
    }
    public class FileDataService : PriceService, IFileDataService
    {
        public FileDataService(DataContext context) : base(context)
        {

        }
        public void AddFileData(IEnumerable<Input> model)
        {
            try
            {
                _context.AddRange(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                //shout/catch/throw/log
            }
        }
    }
}
