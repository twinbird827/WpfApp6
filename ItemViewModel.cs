using StatefulModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp6
{
    public class ItemViewModel : BindableBase
    {
        public Item Source { get; set; }

        public ItemViewModel Parent { get; set; }

        public ItemViewModel(Item item, ItemViewModel parent)
        {
            Source = item;
            Parent = parent;
            Name = Source.Name;
            Children = Source.Children.ToSyncedSynchronizationContextCollection(
                m => new ItemViewModel(m, this),
                SynchronizationContext.Current
            );
        }

        /// <summary>
        /// ｱｲﾃﾑ名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        private string _Name = null;

        /// <summary>
        /// 子ﾒﾆｭｰ
        /// </summary>
        public SynchronizationContextCollection<ItemViewModel> Children
        {
            get { return _Children; }
            set { SetProperty(ref _Children, value); }
        }
        private SynchronizationContextCollection<ItemViewModel> _Children;

        public ICommand OnAdd
        {
            get
            {
                return _OnAdd = _OnAdd ?? new RelayCommand(
              _ =>
              {
                  // ﾛｸﾞｲﾝ実行
                  var name = this.Name + "-" + Source.Children.Count();
                  Source.Children.Add(new Item() { Name = name });
              },
              _ =>
              {
                  return true;
              });
            }
        }
        public ICommand _OnAdd;

        public ICommand OnRemove
        {
            get
            {
                return _OnRemove = _OnRemove ?? new RelayCommand(
              _ =>
              {
                  // ﾛｸﾞｲﾝ実行
                  Parent.Source.Children.Remove(this.Source);

                  Console.WriteLine(Parent.Children.Count());
                  Console.WriteLine(Parent.Source.Children.Count());
              },
              _ =>
              {
                  return true;
              });
            }
        }
        public ICommand _OnRemove;

    }
}
