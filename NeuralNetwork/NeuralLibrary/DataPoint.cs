namespace NeuralLibrary
{
    public class DataPoint
    {
        public DataPoint(double[] input, double[] desired)
        {
            this.input = input;
            this.desired = desired;
        }

        #region Fields

        private double[] desired;
        private double[] input;

        #endregion Fields

        #region Properties

        public double[] Input { get { return input; } }

        public double[] Desired { get { return desired; } }

        #endregion Properties
    }
}