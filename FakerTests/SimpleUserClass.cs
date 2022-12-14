namespace FakerTests
{
    public class SimpleUserClass
    {
        public int field;
        public int nullField;
        private int PrivField;

        public int property { get; set; }
        public int nullProperty { get; set; }
        private int PrivProperty { get; set; }  

        public SimpleUserClass()
        {
            field = -1;
            property = -2;
        }

        public int GetPrivField()
        {
            return PrivField;
        }

        public int GetPrivProperty()
        {
            return PrivProperty;
        }
    }
}
