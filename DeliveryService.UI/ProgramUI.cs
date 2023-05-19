using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.Data;
using DeliveryService.Repository;

namespace DeliveryService.UI
{
    public class ProgramUI
    {
        private DeliveryRepository _dRepo = new DeliveryRepository();
        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Welcome to the DeliveryApp\n" +
                "1. Add new Delivery\n" +
                "2. All en route deliveries\n" +
                "3. All completed deliveries\n" +
                "4. Update the status of a delivery\n" +
                "5. Cancel a delivery\n" +
                "6. Close Application\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddDelivery();
                        break;
                    case "2":
                        EnRouteDeliveries();
                        break;
                    case "3":
                        CompletedDeliveries();
                        break;
                    case "4":
                        UpdateTheStatusOfADelivery();
                        break;
                    case "5":
                        CancelADelivery();
                        break;
                    case "6":
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("invalid selection");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private bool CloseApplication()
        {
            Console.Clear();
            System.Console.WriteLine("Thanks, Press Any Key To Continue");
            Console.ReadKey();
            return false;
        }

        private void CancelADelivery()
        {

            Console.Clear();
            Console.WriteLine("Enter the ID of the delivery to cancel: ");
            int deliveryId = int.Parse(Console.ReadLine());
            Delivery delivery = _dRepo.GetDelivery(deliveryId);

            if (delivery != null)
            {
                if (_dRepo.CancelDelivery(delivery.Id))
                {
                    Console.WriteLine("Delivery canceled successfully.");
                }
                else
                {
                    Console.WriteLine("Delivery canceled Unsuccessfully.");
                }

            }
            else
            {
                Console.WriteLine("Delivery not found!");
            }

            Console.ReadKey();
        }


        private void UpdateTheStatusOfADelivery()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the delivery to update: ");
            int deliveryId = int.Parse(Console.ReadLine());

            Delivery delivery = _dRepo.GetDelivery(deliveryId);
            if (delivery != null)
            {
                Console.WriteLine("Enter the new status of the delivery: \n" +
             "0. Scheduled\n" +
             "1. EnRoute\n" +
             "2. Complete\n" +
             "3. Canceled");
                int newStatusInt = int.Parse(Console.ReadLine());
                OrderStatus newStatus = (OrderStatus)newStatusInt;
                if(_dRepo.UpdateStatusOfDelivery(delivery.Id, newStatus))
                {
                    System.Console.WriteLine("Success");
                }
                else
                {
                    System.Console.WriteLine("fail");
                }

                Console.WriteLine("Delivery status updated successfully.");
            }
            else
            {
                Console.WriteLine("Delivery not found!");
            }

            Console.ReadKey();
        }

        private void CompletedDeliveries()
        {
            Console.Clear();
            List<Delivery> completedDeliveries = _dRepo.CompletedDeliveries();

            Console.WriteLine("Completed Deliveries:");
            foreach (var delivery in completedDeliveries)
            {
                Console.WriteLine($"ID: {delivery.Id}, OrderDate: {delivery.OrderDate}, Receiver: {delivery.CustomerId}, Status: {delivery.OrderStatus}, DeliveryDate: {delivery.DeliveryDate}\n");

            }

            Console.ReadKey();
        }


        private void EnRouteDeliveries()
        {
            Console.Clear();
            List<Delivery> enRouteDeliveries = _dRepo.DeliveriesEnRoute();

            Console.WriteLine("En Route Deliveries:");
            foreach (var delivery in enRouteDeliveries)
            {
                Console.WriteLine($"ID: {delivery.Id}, OrderDate: {delivery.OrderDate}, Receiver: {delivery.CustomerId}, Status: {delivery.OrderStatus}, DeliveryDate: {delivery.DeliveryDate}\n");

            }

            Console.ReadKey();
        }

        private void AddDelivery()
        {
            Console.Clear();

            Console.WriteLine("Please enter an item number");
            int itemNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the item quantity: ");
            int itemQuantity = int.Parse(Console.ReadLine());
             Console.WriteLine("Please enter the customerId ");
            int customerId = int.Parse(Console.ReadLine());
            
            Delivery delivery = new Delivery(itemNumber, itemQuantity, customerId);

            if(_dRepo.AddDelivery(delivery))
            {
                System.Console.WriteLine("success");
            }
            else
            {
                System.Console.WriteLine("fail");
            }
            
            Console.WriteLine("Delivery added successfully.");

            Console.ReadKey();
        }
    }
}