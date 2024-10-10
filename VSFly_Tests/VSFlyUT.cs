
using Moq;
using System.Collections.Generic;
using VSFly_Business;
using VSFly_Business.Models;
using VSFly_Business.Repository;

namespace VSFly_Tests
{
    public class VSFlyUT
    {

        // we didn't do the Dummy as an example

        // example of a Fake
        [Fact]
        public void GetAllAvailableFlights_ShouldReturnNotFullFlights_Fake()
        {
            // Arrange - setup data with a flight that is 80% full and another that is 100% full
            var fakeFlightRepository = new FakeFlightRepository();
            var flight1 = new Flight { Id = 1, Capacity = 100, Bookings = 80 };
            var flight2 = new Flight { Id = 2, Capacity = 100, Bookings = 100 };

            fakeFlightRepository.Add(flight1); // add the flights to the fake repository
            fakeFlightRepository.Add(flight2);

            var flightService = new FlightService(fakeFlightRepository); // inject the fake repository into the service

            // Act - get all available flights
            var flights = flightService.GetAllAvailableFlights();

            // Assert - check that only the first flight is returned
            Assert.Single(flights);

        }

        // example of a Stub
        [Fact]
        public void GetAllAvailableFlights_ShouldReturnNotFullFlights_Stub()
        {
            // Arrange - setup data with a flight that is 80% full and another that is 100% full
            var flights = new List<Flight>()
            {
                new Flight { Id = 1, Capacity = 100, Bookings = 80 },
                new Flight { Id = 2, Capacity = 100, Bookings = 100 }
            };

            var stubFlightRepo = new StubFlightRepository(flights);
            var flightService = new FlightService(stubFlightRepo); // inject the stub repository into the service

            // Act - get all available flights
            var returnedFlights = flightService.GetAllAvailableFlights();

            // Assert - check that only the first flight is returned
            Assert.Single(returnedFlights);
        }

        // example of a Mock
        [Fact]
        public void GetAllAvailableFlights_ShouldReturnNotFullFlights_Mock()
        {
            // Arrange - setup data with a flight that is 80% full and another that is 100% full
            var mockFlightRepo = new Mock<IFlightRepository>(); // Mocks need an interface to know what to mock/do
            mockFlightRepo.Setup(repo => repo.GetAll()).Returns(new List<Flight>
            {
                new Flight { Id = 1, Capacity = 100, Bookings = 80 },
                new Flight { Id = 2, Capacity = 100, Bookings = 100 }
            });

            var flightService = new FlightService(mockFlightRepo.Object); // inject the mock repository into the service

            // Act - get all available flights
            var returnedFlights = flightService.GetAllAvailableFlights();

            // Assert - check that only the first flight is returned
            Assert.Single(returnedFlights);
            Assert.Equal(1, returnedFlights.First().Id);
        }

        // example of a Spy
        [Fact]
        public void GetAllAvailableFlights_ShouldReturnNotFullFlights_Spy()
        {
            // Arrange - setup data with a flight that is 80% full and another that is 100% full
            var SpyFlightRepo = new SpyFlightRepository();
            var flight1 = new Flight { Id = 1, Capacity = 100, Bookings = 80 };
            var flight2 = new Flight { Id = 2, Capacity = 100, Bookings = 100 };

            SpyFlightRepo.Add(flight1);
            SpyFlightRepo.Add(flight2);

            var flightService = new FlightService(SpyFlightRepo);

            // Act - get all available flights
            var returnedFlights = flightService.GetAllAvailableFlights();

            // Assert - check that only the first flight is returned
            // you can have more than one asserts here
            Assert.Single(returnedFlights);
            Assert.Equal(1, returnedFlights.First().Id);
            Assert.Equal(2, SpyFlightRepo.FlightsCalled.Count);
        }
    }
}