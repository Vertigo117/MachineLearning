using Microsoft.ML.Data;

namespace ImageClassification.Models
{
    public class Input
    {
        [ColumnName(@"Label")]
        public string Label { get; set; }

        [ColumnName(@"ImageSource")]
        public string ImageSource { get; set; }
    }
}
