using Core.Domain.Entities;
using Storage.Core.Helpers.Compares;
using Storage.MainConsole.Data;
using Storage.MainConsole.Repositories;
using Storage.MainConsole.Services;

namespace Storage.Test
{
    public class Test
    {
        private readonly IEnumerable<Pallet> _data = InMemoryDatas.Pallets;

        [Fact]
        public void SerializedAndDeserializadJsonTest()
        {
            string path = ".\\data.json";

            IOService.WriteToJson(path, _data);
            IOService.ReadFromJson(path, out List<Pallet> pallets);

            Assert.True(pallets.SequenceEqual(_data.ToList(), new PalletCompare()));
        }

        [Fact]
        public void SerializedAndDeserializadXmlTest()
        {
            string path = ".\\data.xml";

            IOService.WriteToXml(path, _data.ToList());
            IOService.ReadFromXml(path, out List<Pallet> pallets);

            Assert.True(pallets.SequenceEqual(_data.ToList(), new PalletCompare()));
        }

        [Fact]
        public async Task GetGroupedPalletsTest()
        {
            var keys = new List<DateTimeOffset>()
            {
                new DateTimeOffset(new DateTime(2020, 12, 1),new TimeSpan(0)),
                new DateTimeOffset(new DateTime(2022, 12, 1),new TimeSpan(0)),
                new DateTimeOffset(new DateTime(2023, 3, 11),new TimeSpan(0)),
                new DateTimeOffset(new DateTime(2023, 12, 1),new TimeSpan(0)),
            };
            List<Pallet> data = _data.ToList();
            var pallets = new List<Pallet>()
            {
                data[3],
                data[1],
                data[4],
                data[2],
                data[0],
            };

            ConsoleService service = new(new LocalRepository<Pallet>(_data));
            var groupedData = await service.GetGroupedPallets();
            var groupedDataList = groupedData.SelectMany(x => x).ToList();

            Assert.Equal(keys, groupedData.Select(x => x.Key));
            Assert.True(pallets.SequenceEqual(groupedDataList, new PalletCompare()));
        }

        [Fact]
        public async Task GetPalletsWithMaxExpDate()
        {
            List<Pallet> data = _data.ToList();
            var pallets = new List<Pallet>()
            {
                data[4],
                data[0],
                data[2],
            };

            ConsoleService service = new(new LocalRepository<Pallet>(_data));
            var sortedData = await service.GetPalletsWithMaxExpDate();

            Assert.Equal(pallets, sortedData.ToList());
        }
    }
}