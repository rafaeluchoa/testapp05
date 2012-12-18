namespace Naskar.Architecture.Data
{
    using System.Collections.Generic;

    public class PagedList<T> : List<T>
    {
        public PageContext PageContext { get; set; }
    }
}
