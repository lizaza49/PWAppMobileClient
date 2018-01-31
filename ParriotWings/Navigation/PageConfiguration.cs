using System;
namespace ParriotWings.Navigation
{
    public class PageConfiguration
    {
        public Page Page { get; set; }
        public Type Type { get; set; }
        public bool RequireAuth { get; set; }
        public bool IsRoot { get; set; }
    }
}
