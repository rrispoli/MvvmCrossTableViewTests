using MvvmCross.Core.ViewModels;
using MvvmCrossTableViewTests.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvmCrossTableViewTests.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public override async Task Initialize()
        {
            await Reload();
        }

        private List<Item> _items;
        public List<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        private async Task Reload()
        {
            await Task.Delay(3000);

            Items = new List<Item>()
            {
                new Item() { Name = "Test 1", Observations = "Observations 1" },
                new Item() { Name = "Test 2", Observations = "Observations 2 Observations 2 Observations 2 Observations 2 Observations 2 Observations 2 Observations 2 Observations 2" },
                new Item() { Name = "Test 3", Observations = "Observations 3" },
                new Item() { Name = "Test 4", Observations = "Observations 4 Observations 4 Observations 4 Observations 4 Observations 4 Observations 4 Observations 4 Observations 4 Observations 4 Observations 4 Observations 4 Observations 4 Observations 4" },
                new Item() { Name = "Test 5", Observations = "Observations 5" }
            };
        }
    }
}