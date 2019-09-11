using Demo.DWS.Model;
using Demo.DWS.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.DWS.Test.Test
{
    public class FileServiceTest
    {
        [Fact]
        public void AddFileData_given_sanitized_input_insert_data_successfully()
        {
            //given
            IEnumerable<Input> input = new List<Input> { new Input { UnitID="ABC", Date=DateTime.Now, UnitPrice="1.22" } };
            var moqPriceServiceCtx = new Mock<IPriceServiceCtx>();
            var moqFileDataService = new Mock<IPriceDataService>();
            moqFileDataService.Setup(m => m.AddUnitPriceData(It.IsAny<IEnumerable<Input>>())).Verifiable();
            var sut = new UnitPriceService(moqPriceServiceCtx.Object, moqFileDataService.Object);

            //when
            sut.AddUnitPriceData(input);

            //then
            moqFileDataService.Verify(v => v.AddUnitPriceData(It.IsAny<IEnumerable<Input>>()), Times.Once);
        }

        [Fact]
        public void AddFileData_given_null_input_does_not_insert_data()
        {
            //given
            IEnumerable<Input> input = new List<Input> {};
            var moqPriceServiceCtx = new Mock<IPriceServiceCtx>();
            var moqFileDataService = new Mock<IPriceDataService>();
            moqFileDataService.Setup(m => m.AddUnitPriceData(It.IsAny<IEnumerable<Input>>())).Verifiable();
            var sut = new UnitPriceService(moqPriceServiceCtx.Object, moqFileDataService.Object);

            //when
            sut.AddUnitPriceData(input);

            //then
            moqFileDataService.Verify(v => v.AddUnitPriceData(It.IsAny<IEnumerable<Input>>()), Times.Never);
        }
    }
}
