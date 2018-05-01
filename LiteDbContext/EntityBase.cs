using LiteDB;

namespace LiteDbContext
{
    /// <summary>
    /// An entity base (optional) wich implements the Id by ObjectId
    /// </summary>
    public class EntityBase
    {
        public ObjectId Id { get; set; }

        public EntityBase()
        {
            Id = ObjectId.NewObjectId();
        }
    }
}
