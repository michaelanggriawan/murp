using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MURP.Core.Base
{
    public abstract class DataSource<T> where T : Model
    {
        protected string TableName;
        protected ItemsControl DGTable = null;

        public ObservableCollection<T> Collection;
        public List<string> data = new List<string>();

        public abstract void Load();
        public abstract bool Add(T t);
        public abstract void Update(T t);
        public abstract void Delete(T t);



        public void AssignTable(ItemsControl d)
        {
            DGTable = d;
            Collection = new ObservableCollection<T>();
            DGTable.DataContext = Collection;
        }


        public void Empty()
        {
            DGTable = null;
            Collection = null;
        }
    }
}
