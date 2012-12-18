
namespace Naskar.Architecture.Web.Models
{
    using System;

    using Naskar.Architecture.Domain;

    public class EntityModel<TEntity> 
        where TEntity : Entity, new()
    {
        public EntityModel()
        {
            Value = Activator.CreateInstance<TEntity>();
        }

        public int Index { get; set; }

        public TEntity Value { get; set; }

        public bool Selected { get; set; }

        public bool New
        {
            get
            {
                return Value.Id == null;
            }
        }
    }
}