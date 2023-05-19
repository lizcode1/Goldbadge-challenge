using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.Data
{
    public class Delivery
    {

        public Delivery()
        {
            OrderStatus = OrderStatus.Scheduled;
        }
        public Delivery(int itemNumber, int itemQuantity, int customerId)
        {
            OrderStatus = OrderStatus.Scheduled;
            ItemNumber = itemNumber;
            ItemQuantity = itemQuantity;
            CustomerId = customerId;
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DeliveryDate 
        {
             get
             {
                return OrderDate.AddDays(7);
             } 
             
        } 
        public int ItemNumber { get; set; }
        public int ItemQuantity { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}