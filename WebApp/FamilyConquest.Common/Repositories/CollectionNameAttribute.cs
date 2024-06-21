namespace FamilyConquest.Common.Repositories
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionNameAttribute(string name) : Attribute
    {
        public string Name { get; private set; } = name;
    }
}
