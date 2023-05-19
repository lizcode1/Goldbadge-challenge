using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.Data;

namespace DeliveryService.Repository
{
    public class DeliveryRepository
    {
        private List<Delivery> _deliveryDataBase = new List<Delivery>();

        private int _count = 0;

        //Create

        public bool AddDelivery(Delivery deliveryData)
        {
            if (deliveryData == null)
            {
                return false;
            }
            else
            {
                _count++;
                deliveryData.Id = _count;
                _deliveryDataBase.Add(deliveryData);
                return true;
            }
        }
        
        //Read All Delivery Enroute
        public List<Delivery> DeliveriesEnRoute()
        {
             //1. we need an empty list
             List<Delivery> deliveriesEnRoute = new List<Delivery>();

             //2. need to loop thru the database
             foreach(Delivery delivery in _deliveryDataBase)
             {
                 //3. check tosee if the delivery is Enroute 
                 if (delivery.OrderStatus == OrderStatus.EnRoute)
                 {
                   //4. if true we will add the delivery to the deliveriesEnRoute list
                   deliveriesEnRoute.Add(delivery); 
                 }
             }
             return deliveriesEnRoute;
        }
        
        //Read All Completed Deliveries
        public List<Delivery> CompletedDeliveries()
        {
             //1. we need an empty list
             List<Delivery> completedDeliveries = new List<Delivery>();

             //2. need to loop thru the database
             foreach(Delivery delivery in _deliveryDataBase)
             {
                 //3. check tosee if the delivery is Enroute 
                 if (delivery.OrderStatus == OrderStatus.Complete)
                 {
                   //4. if true we will add the delivery to the deliveriesEnRoute list
                   completedDeliveries.Add(delivery); 
                 }
             }
             return completedDeliveries;
        }
        //Update The Status Of A Delivery
        public bool UpdateStatusOfDelivery(int Id,OrderStatus status)
        {
            Delivery deliveryInDatabase = _deliveryDataBase.SingleOrDefault(d => d.Id == Id)!;
            if(deliveryInDatabase != null)
            {
                deliveryInDatabase.OrderStatus = status;
                return true;
            }
            return false;
        }

        public Delivery GetDelivery(int Id)
        {
            return _deliveryDataBase.SingleOrDefault(d => d.Id == Id)!;
        }
       //Cancel Delivery
       public bool CancelDelivery(int deliveryId)
       {
        return _deliveryDataBase.Remove(GetDelivery(deliveryId));
       }
        
    }
}