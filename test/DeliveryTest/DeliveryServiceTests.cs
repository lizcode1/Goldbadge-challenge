using DeliveryService.Repository;
using  DeliveryService.Data;


namespace DeliveryTest;

public class DeliveryServiceTests
{
    private DeliveryRepository _dRepo;
    public DeliveryServiceTests()
    {
       _dRepo = new DeliveryRepository();

       Delivery delivery = new Delivery(1,2,1);
       delivery.OrderStatus = OrderStatus.EnRoute;

       Delivery deliveryB = new Delivery(1,2,4);
       deliveryB.OrderStatus = OrderStatus.Complete;

       _dRepo.AddDelivery(delivery); 
       _dRepo.AddDelivery(deliveryB); 

    }
    [Fact]
    public void AddDelivery_ShouldReturnTrue()
    {
        //Arrange
        Delivery delivery = new Delivery(1,2,3); 
        //Act
        bool isSuccess = _dRepo.AddDelivery(delivery);
        //Assert
        Assert.True(isSuccess);
    }
    [Fact]
    public void deliveriesEnRoute_ShouldReturnCorrectCount()
    {
        //Arrange
        
        //Act
        int expectedCount = 1;
        int actualCount = _dRepo.DeliveriesEnRoute().Count;
        //Assert
        Assert.Equal(expectedCount,actualCount);
    }

    [Fact]
    public void deliveriesCompleted_ShouldReturnCorrectCount()
    {
        //Arrange
        
        //Act
        int expectedCount = 1;
        int actualCount = _dRepo.CompletedDeliveries().Count;
        //Assert
        Assert.Equal(expectedCount,actualCount);
    }
    [Fact]
    public void UpdateStatusOfDelivery_ShouldReturnTrue()
    {
         //Arrange
        Delivery newDelivery = new Delivery(1,1,1); 
        OrderStatus status = OrderStatus.Complete;
        //Act
        bool isSuccess = _dRepo.UpdateStatusOfDelivery(1, status);
        //Assert
        Assert.True(isSuccess);
    }
    [Fact]
    public void CancelDelivery_ShouldReturnTrue()
    {
         //Arrange
        
        //Act
        bool isSuccess = _dRepo.CancelDelivery(1);
        //Assert
        Assert.True(isSuccess);
    }
}
