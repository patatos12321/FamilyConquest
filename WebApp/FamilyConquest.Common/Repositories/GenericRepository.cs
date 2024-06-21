using LiteDB;
using System.Reflection;

namespace FamilyConquest.Common.Repositories
{
    public class GenericRepository<T>(IConfiguration config) : IRepository<T> where T : IDocument
    {
        protected readonly LiteDatabase _database = new(config["DatabasePath"]);

        public virtual IEnumerable<T> GetAll()
        {
            return GetLiteCollection().FindAll();
        }

        public virtual T GetById(int id)
        {
            return GetLiteCollection().FindOne(d => d.Id == id);
        }

        public virtual void Save(T document)
        {
            var collection = GetLiteCollection();

            var dbDocument = collection.FindOne(d => d.Id == document.Id);
            if (dbDocument == null)
            {
                collection.Insert(document);
                return;
            }

            document.Id = dbDocument.Id;
            collection.Update(document);
        }

        public virtual void Save(IEnumerable<T> documents)
        {
            foreach (var document in documents)
            {
                Save(document);
            }
        }

        public virtual void Delete(int id)
        {
            GetLiteCollection().Delete(id);
        }

        /// <summary>
        /// Fetch the CollectionNameAttribute to know the name of the collection.
        /// If there isn't any, the name of the collection will be the name of the class;
        /// </summary>
        /// <returns></returns>
        protected virtual ILiteCollection<T> GetLiteCollection()
        {
            var typeInfo = typeof(T).GetTypeInfo();
            var attrs = typeInfo.GetCustomAttributes();
            var collectionNameAttribute = attrs.FirstOrDefault(a => a.GetType() == typeof(CollectionNameAttribute)) as CollectionNameAttribute;

            if (collectionNameAttribute == null)
            {
                return _database.GetCollection<T>(typeof(T).Name);
            }

            return _database.GetCollection<T>(collectionNameAttribute.Name);
        }

        protected virtual ILiteCollection<R> GetLiteCollectionForType<R>()
        {
            var typeInfo = typeof(R).GetTypeInfo();
            var attrs = typeInfo.GetCustomAttributes();
            var collectionNameAttribute = attrs.FirstOrDefault(a => a.GetType() == typeof(CollectionNameAttribute)) as CollectionNameAttribute;

            if (collectionNameAttribute == null)
            {
                return _database.GetCollection<R>(typeof(T).Name);
            }

            return _database.GetCollection<R>(collectionNameAttribute.Name);
        }
    }
}
