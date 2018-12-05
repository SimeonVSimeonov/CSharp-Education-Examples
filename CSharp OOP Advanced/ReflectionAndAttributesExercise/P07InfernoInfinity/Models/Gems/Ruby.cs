namespace P07InfernoInfinity.Models.Gems
{
    using P07InfernoInfinity.Models.Enums;

    public class Ruby : Gem
    {
        public Ruby(GemClarity clarity)
            : base(clarity, 7, 2, 5)
        {
        }
    }
}
