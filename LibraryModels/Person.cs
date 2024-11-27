namespace Models
{
    public abstract class Person : Model
    {
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string personTableName = "person";
        public string[] personAttributes = new string[] { "id", "first_name", "last_name", "birth_date" };
    }
}
