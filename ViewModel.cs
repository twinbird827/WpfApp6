using StatefulModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp6
{
    public  class ViewModel : BindableBase
    {
        public Model Model { get; set; }

        /// <summary>
        /// ﾒﾆｭｰﾂﾘｰﾋﾞｭｰ構成
        /// </summary>
        public SynchronizationContextCollection<ItemViewModel> Children
        {
            get { return _Children; }
            set { SetProperty(ref _Children, value); }
        }
        private SynchronizationContextCollection<ItemViewModel> _Children;


        public ViewModel()
        {
            Model = new Model();
            Children = Model.Children.ToSyncedSynchronizationContextCollection(
                m => new ItemViewModel(m, null),
                SynchronizationContext.Current
            );

        }
    }
}
