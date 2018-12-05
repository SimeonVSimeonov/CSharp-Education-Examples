namespace P07InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string clarity, string gemType);
    }
}
