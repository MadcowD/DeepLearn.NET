namespace NeuralNetwork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(Sigmoid.HyperbolicTangent, 2, 2, 2);
        }
    }
}