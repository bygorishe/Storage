using Core.Abstractions;
using Core.Domain.Entities;
using System.Data;

namespace Storage.MainConsole.Services
{
    public class ConsoleService
    {
        private readonly IRepository<Pallet> _palletRepository;

        public ConsoleService(IRepository<Pallet> palletRepository)
        {
            _palletRepository = palletRepository;
        }

        public async Task<IEnumerable<Pallet>> GetAll()
        {
            return await _palletRepository.GetAll();
        }

        private async Task WritePalletsToConsole(Pallet pallet, bool showBoxes = false)
        {
            Console.WriteLine($"Id {pallet.Id}, Height {pallet.Height:f3}, Width {pallet.Width:f3}, Depth {pallet.Depth:f3}, " +
                              $"Weight {pallet.Weight:f3}, Capacite {pallet.Capacity:f3}, ExpirationDate {pallet.ExpirationDate:g}");
            if (showBoxes)
                foreach (var box in pallet.Boxes)
                    Console.WriteLine($"\tId {box.Id}, Height {box.Height:f3}, Width {box.Width:f3}, Depth {box.Depth:f3}, " +
                                      $"Weight {box.Weight:f3}, Capacite {box.Capacity:f3}, ProductionDate {box.ProductionDate:g}, " +
                                      $"ExpirationDate {box.ExpirationDate:g}");
        }

        /// <summary>
        /// Сгруппировать все паллеты по сроку годности, 
        /// отсортировать по возрастанию срока годности, 
        /// в каждой группе отсортировать паллеты по весу.
        /// </summary>
        /// <param name="pallets"></param>
        public async Task Task1()
        {
            IEnumerable<IGrouping<DateTimeOffset, Pallet>> palletGroups = await GetGroupedPallets();

            foreach (var palletGroup in palletGroups)
            {
                Console.WriteLine(palletGroup.Key.ToString("g"));
                foreach (var pallet in palletGroup)
                    await WritePalletsToConsole(pallet);
            }
        }

        public async Task<IEnumerable<IGrouping<DateTimeOffset, Pallet>>> GetGroupedPallets()
        {
            var pallets = await _palletRepository.GetAll();
            //var palletGroups = pallets.GroupBy(x => x.ExpirationDate).Select(x => new
            //{
            //    key = x.Key,
            //    pallet = x.OrderBy(x => x.Weight)
            //}).OrderBy(x => x.key); //к такому сложно обращаться и тесты писать
            pallets = pallets.OrderBy(x => x.Weight);
            var palletGroups = pallets.GroupBy(x => x.ExpirationDate);
            palletGroups = palletGroups.OrderBy(x => x.Key);
            return palletGroups;
        }

        /// <summary>
        /// 3 паллеты, которые содержат коробки с наибольшим сроком годности, 
        /// отсортированные по возрастанию объема.
        /// </summary>
        /// <param name="pallets"></param>
        public async Task Task2()
        {
            IEnumerable<Pallet> firstItems = await GetPalletsWithMaxExpDate();

            foreach (var item in firstItems)
                await WritePalletsToConsole(item);
        }

        public async Task<IEnumerable<Pallet>> GetPalletsWithMaxExpDate(int count = 3)
        {
            var pallets = await _palletRepository.GetAll();
            var dateList = new List<KeyValuePair<DateTimeOffset, Pallet>>();

            foreach (var pallet in pallets)
            {
                if (pallet.Boxes is not null && pallet.Boxes.Count > 0)
                {
                    var max = pallet.Boxes.Aggregate((i1, i2) => i1.ExpirationDate > i2.ExpirationDate ? i1 : i2).ExpirationDate;
                    dateList.Add(new KeyValuePair<DateTimeOffset, Pallet>(max, pallet));
                }
            }
            dateList = dateList.OrderByDescending(x => x.Key).ToList();

            var firstItems = dateList.Take(count).Select(x => x.Value);
            return firstItems;
        }
    }
}
