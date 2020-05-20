namespace AppWebClient.ViewModel
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
        // APPRECIATIONS TRENDS 
        // _______________________________________________________________

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "Evaluation")]
        public int Evaluation { get; set; }

        //Explicitly setting the Date to be used while serializing to JSON.
        [DataMember(Name = "EvaluationDate")]
        public int EvaluationDate { get; set; }


        // _______________________________________________________________
        // TOP CITIES   
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


        // _______________________________________________________________
        // TOP BYERS (CUSTOMERS)
        // _______________________________________________________________

        //Explicitly setting the Date to be used while serializing to JSON.
        [DataMember(Name = "Firstname")]
        public string Firstname { get; set; }

        //Explicitly setting the Date to be used while serializing to JSON.
        [DataMember(Name = "Lastname")]
        public string Lastname { get; set; }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "Email")]
        public string Email { get; set; }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "NbOrders")]
        public int CountOrders { get; set; }


        //Explicitly setting the Date to be used while serializing to JSON.
        [DataMember(Name = "OrderDate")]
        public int OrderDate { get; set; }



    }// End Class 
}
