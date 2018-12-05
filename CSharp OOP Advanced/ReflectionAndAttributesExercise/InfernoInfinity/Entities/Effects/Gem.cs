namespace InfernoInfinity.Entities.Effects
{
    public abstract class Gem
    {
        public Gem(string quality, string name)
        {
            Quality = quality;
            Name = name;
        }
        public string Quality { get; }
        public string Name { get; }
    }
}
