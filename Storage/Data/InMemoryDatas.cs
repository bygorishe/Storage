using Core.Domain.Entities;

namespace Storage.MainConsole.Data
{
    public static class InMemoryDatas
    {
        public static IEnumerable<Pallet> Pallets => new List<Pallet>()
        {
            new Pallet(40,30,30, new List<Box>()
            {
                new Box(10,10,10,5.7, expirationDate: new DateTimeOffset(new DateTime(2023, 12, 1),new TimeSpan(0))),
                new Box(30,40,10,50, expirationDate: new DateTimeOffset(new DateTime(2023, 12, 1),new TimeSpan(0))),
                new Box(10,10,10,5, expirationDate: new DateTimeOffset(new DateTime(2023, 12, 1),new TimeSpan(0))),
                new Box(10,10,10,1.1, expirationDate : new DateTimeOffset(new DateTime(2023, 12, 1),new TimeSpan(0))),
            }),
            new Pallet(50,50,30, new List<Box>()
            {
                new Box(10,10,5,5.7, productionDate: new DateTimeOffset(new DateTime(2022, 12, 1),new TimeSpan(0))),
                new Box(30,40,5,500, productionDate: new DateTimeOffset(new DateTime(2022, 12, 1),new TimeSpan(0))),
                new Box(10,10,5,5, expirationDate: new DateTimeOffset(new DateTime(2022, 12, 1),new TimeSpan(0))),
                new Box(10,10,5,1.1, productionDate: new DateTimeOffset(new DateTime(2022, 12, 1),new TimeSpan(0))),
            }),
            new Pallet(60,20,50, new List<Box>()
            {
                new Box(5,10,10,5.7, productionDate : new DateTimeOffset(new DateTime(2022, 12, 1), new TimeSpan(0))),
                new Box(5,40,10,50, productionDate : new DateTimeOffset(new DateTime(2022, 12, 1), new TimeSpan(0))),
                new Box(5,10,10,5, expirationDate: new DateTimeOffset(new DateTime(2023, 12, 1),new TimeSpan(0))),
                new Box(5,10,10,1.1, productionDate : new DateTimeOffset(new DateTime(2022, 12, 1), new TimeSpan(0))),
            }),
            new Pallet(50,50,30, new List<Box>()
            {
                new Box(10,10,5,5.7, productionDate: new DateTimeOffset(new DateTime(2020, 12, 1),new TimeSpan(0))),
                new Box(30,40,5,500, productionDate: new DateTimeOffset(new DateTime(2020, 12, 1),new TimeSpan(0))),
                new Box(10,10,5,5, expirationDate: new DateTimeOffset(new DateTime(2020, 12, 1),new TimeSpan(0))),
                new Box(10,10,5,1.1, productionDate: new DateTimeOffset(new DateTime(2020, 12, 1),new TimeSpan(0))),
            }),
            new Pallet(60,20,50, new List<Box>()
            {
                new Box(5,10,10,5.7, expirationDate : new DateTimeOffset(new DateTime(2023, 12, 15), new TimeSpan(0))),
                new Box(5,40,10,5, productionDate : new DateTimeOffset(new DateTime(2022, 12, 1), new TimeSpan(0))),
                new Box(5,10,10,5, expirationDate: new DateTimeOffset(new DateTime(2023, 12, 1),new TimeSpan(0))),
                new Box(5,10,10,1.1, productionDate : new DateTimeOffset(new DateTime(2022, 12, 1), new TimeSpan(0))),
            }),
            //new Pallet(60,20,50),
        };
    }
}
