namespace Api.ViewModel
{
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


        // _______________________________________________________________
        // APPRECIATIONS 
        // _______________________________________________________________

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "Evaluation")]
        public int Evaluation { get; set; }

        //Explicitly setting the Date to be used while serializing to JSON.
        [DataMember(Name = "EvaluationDate")]
        public int EvaluationDate { get; set; }


        // _______________________________________________________________
        // CUSTOMERS / CLIENTS  
        // _______________________________________________________________

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "NbClients")]
        public int Clients { get; set; }

        //Explicitly setting the Date to be used while serializing to JSON.
        [DataMember(Name = "City")]
        public string City { get; set; }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "NbTotalClients")]
        public int CountCustomers { get; set; }

    }// End Class 
}
