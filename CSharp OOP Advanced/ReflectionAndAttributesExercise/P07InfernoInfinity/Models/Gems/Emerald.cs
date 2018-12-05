namespace P07InfernoInfinity.Models.Gems
{
    using P07InfernoInfinity.Models.Enums;

    public class Emerald : Gem
    {
        public Emerald(GemClarity clarity)
            : base(clarity, 1, 4, 9)
        {
        }
    }
}
