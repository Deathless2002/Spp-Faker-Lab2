namespace FakerLib
{
    public class RecursionKiller
    {
        private readonly int limit;
        private readonly Dictionary<Type, int> counters;

        public RecursionKiller(int max)
        {
            limit = max;
            counters = new Dictionary<Type, int>();
        }

        public bool Add(Type type)
        {
            if (counters.ContainsKey(type))
                counters[type]++;
            else
                counters.Add(type, 1);
            return counters[type] < limit;
        }

        public void Remove(Type type)
        {
            if (counters.ContainsKey(type))
                counters[type]--;
            if (counters[type] == 0)
                counters.Remove(type);
        }
    }
}
