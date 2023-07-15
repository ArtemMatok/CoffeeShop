using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace Coffee.Models
{
    public class Order
    {
      
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Number { get; set; }
        public string Description { get; set; }
       
    }
}
