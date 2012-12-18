
namespace Naskar.Architecture.Web.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Naskar.Architecture.Domain;

    public class ListModel<T> : List<EntityModel<T>>
        where T : Entity, new()
    {
        public ListModel()
        {
        }

        public ListModel(IEnumerable<T> lista)
        {
            foreach (var item in lista)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            var index = this.Count == 0 ? 0 : this.Max(x => x.Index) + 1;

            Add(new EntityModel<T>
            {
                Value = item,
                Index = index
            });
        }

        public IList<T> ToList()
        {
            var lista = new List<T>();
            foreach (var item in this)
            {
                lista.Add(item.Value);
            }

            return lista;
        }

        public IList<T> GetSelected()
        {
            var lista = new List<T>();
            foreach (var item in this)
            {
                if (item.Selected)
                {
                    lista.Add(item.Value);
                }
            }

            return lista;
        }

        public IList<T> GetNonSelected()
        {
            var lista = new List<T>();
            foreach (var item in this)
            {
                if (!item.Selected)
                {
                    lista.Add(item.Value);
                }
            }

            return lista;
        }
    }
}