namespace UseCase.Data
{
    public class User
    {
        public int ID { get; set; }
        public string? Name { get; set; }   
        public ICollection<Role>? Role { get; set; }
        //no fk for this class
    }
}
