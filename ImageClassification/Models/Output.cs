using Microsoft.ML.Data;

namespace ImageClassification.Models
{
    public class Output
    {
        [ColumnName("PredictedLabel")]
        public string Prediction { get; set; }

        public float[] Score { get; set; }
    }
}
