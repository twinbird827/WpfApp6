using StatefulModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    public  class Model : BindableBase
    {
        public Model()
        {
            Children = new ObservableSynchronizedCollection<Item>
            {
                new Item(){ Name = "AAA" },
                new Item(){ Name = "BBB", Children = new ObservableSynchronizedCollection<Item>
                {
                    new Item(){ Name = "B-1" },
                    new Item(){ Name = "B-2" },
                    new Item(){ Name = "B-3" },
                } },
                new Item(){ Name = "CCC" },
            };
        }

        /// <summary>
        /// 子ﾒﾆｭｰ
        /// </summary>
        public ObservableSynchronizedCollection<Item> Children
        {
            get { return _Children; }
            set { SetProperty(ref _Children, value); }
        }
        private ObservableSynchronizedCollection<Item> _Children = new ObservableSynchronizedCollection<Item>();

    }
}
