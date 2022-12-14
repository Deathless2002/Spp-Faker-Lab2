namespace FakerTests
{
    public class Сodependency
    {
        public Dependened? b { get; set; }
    }

    public class Dependened
    { 
        public Сodependency? a { get; set; }
    }

}
