namespace Api.ViewModel
{
    using System;
    using System.Runtime.Serialization;


    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class ChartViewModel
    {
        public ChartViewModel(int evaluation, int year)
        {
            this.Evaluation = evaluation;
            this.EvaluationDate = year;
        }


        public ChartViewModel()
        {
        }


        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "Evaluation")]
        public int Evaluation { get; set; }

        //Explicitly setting the Date to be used while serializing to JSON.
        [DataMember(Name = "EvaluationDate")]
        public int EvaluationDate { get; set; }


    }// End Class 
}
