
namespace Naskar.Architecture.Domain
{
    using System;

    using Naskar.QueryOverSpec;

    public class Entity : IIdAccessor
    {
        public virtual long? Id { get; set; }

        public virtual long? Version { get; set; }

        public virtual DateTime? Created { get; set; }

        public virtual DateTime? Changed { get; set; }
    }
}
