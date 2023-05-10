namespace Models.DbEntities.Notification
{

    public class Notification : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Channel { get; set; }

    }

}