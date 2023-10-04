using Moq;
using ProvaPub.Interfaces;
using ProvaPub.Services;
using ProvaPub.Tests.Fixtures;

namespace ProvaPub.Tests.Services
{
    public class CustomerServiceTests
    {
        private readonly ICustomerService _sut;

        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;

        public CustomerServiceTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _orderRepositoryMock = new Mock<IOrderRepository>();

            _sut = new CustomerService(
                _customerRepositoryMock.Object,
                _orderRepositoryMock.Object);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public async Task CanPurchase_CustomerIdLessOrEqualsZero_ReturnsThrowArgumentOutOfRangeException(int customerId)
        {
            //
            var purchaseValue = 10;

            //
            var act = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                () => _sut.CanPurchase(customerId, purchaseValue)
            );

            //            
            Assert.IsType<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public async Task CanPurchase_PurchaseValueLessOrEqualsZero_ReturnsThrowArgumentOutOfRangeException(int purchaseValue)
        {
            //
            var customerId = 1;

            //
            var act = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                () => _sut.CanPurchase(customerId, purchaseValue)
            );

            //            
            Assert.IsType<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public async Task CanPurchase_CustomerReturnsNull_ReturnsInvalidOperationException()
        {
            //
            var customerId = 1;
            var purchaseValue = 10;
            _customerRepositoryMock.Setup(x => x.FindAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //
            var act = await Assert.ThrowsAsync<InvalidOperationException>(
                () => _sut.CanPurchase(customerId, purchaseValue)
            );

            //            
            Assert.IsType<InvalidOperationException>(act);
            Assert.Equal($"Customer Id {customerId} does not exists", act.Message);
        }

        [Fact]
        public async Task CanPurchase_OrdersInThisMonthIsGreaterThanZero_ReturnsFalse()
        {
            //            
            var purchaseValue = 10;
            var customer = CustomerFixture.CreateValidCustomer();
            _customerRepositoryMock.Setup(x => x.FindAsync(It.IsAny<int>()))
                .ReturnsAsync(() => customer);
            _orderRepositoryMock.Setup(x => x.CountAsync(customer.Id, It.IsAny<DateTime>()))
                .ReturnsAsync(() => 1);

            //
            var act = await _sut.CanPurchase(customer.Id, purchaseValue);

            //            
            Assert.False(act);
        }

        [Fact]
        public async Task CanPurchase_HaveBoughtBeforeEqualZeroAndPurchaseValueGreaterThan100_ReturnsFalse()
        {
            //            
            var purchaseValue = 150;
            var haveBoughtBefore = 0;
            var customer = CustomerFixture.CreateValidCustomer();
            _customerRepositoryMock.Setup(x => x.FindAsync(It.IsAny<int>()))
                .ReturnsAsync(() => customer);
            _orderRepositoryMock.Setup(x => x.CountAsync(customer.Id, It.IsAny<DateTime>()))
                .ReturnsAsync(() => 0);
            _customerRepositoryMock.Setup(x => x.CountAsync(customer.Id))
                .ReturnsAsync(() => haveBoughtBefore);

            //
            var act = await _sut.CanPurchase(customer.Id, purchaseValue);

            //            
            Assert.False(act);
        }

        [Fact]
        public async Task CanPurchase_HaveBoughtBeforeEqualZeroAndPurchaseValueLowerThan100_ReturnsTrue()
        {
            //            
            var purchaseValue = 99;
            var haveBoughtBefore = 0;
            var customer = CustomerFixture.CreateValidCustomer();
            _customerRepositoryMock.Setup(x => x.FindAsync(It.IsAny<int>()))
                .ReturnsAsync(() => customer);
            _orderRepositoryMock.Setup(x => x.CountAsync(customer.Id, It.IsAny<DateTime>()))
                .ReturnsAsync(() => 0);
            _customerRepositoryMock.Setup(x => x.CountAsync(customer.Id))
                .ReturnsAsync(() => haveBoughtBefore);

            //
            var act = await _sut.CanPurchase(customer.Id, purchaseValue);

            //            
            Assert.True(act);
        }
    }
}
