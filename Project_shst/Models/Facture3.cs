using System.ComponentModel.DataAnnotations.Schema;

namespace Project_shst.Models
{
    public class Facture3
    {
        //internal object shipBody;

        public IEnumerable<ELShoppingCart2> LstCart { get; set; }
        public double GroundTotal { get; set; }
        public int GroundCount { get; set; }
        public ShipBody? ShipBody { get; set; }
        public Payment payment { get; set; }
        public PaymentUser? paymentUser { get; set; }
        public decimal totalPrice { get; set; }
        public double weight { get; set; }
        
        public decimal SendPrice { get; set; }
        //public object PaymentUser { get; internal set; }
    }
}
