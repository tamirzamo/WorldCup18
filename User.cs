namespace WorldCup18
{
    public class User
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Department { get; set; }
 

        public override string ToString()
        {
            return Name + " " + Department;
        }
    }
}