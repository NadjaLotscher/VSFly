using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSFly_Business.Models;
using VSFly_Business.Repository;

namespace VSFly_Business
{
    public class FlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public IEnumerable<Flight> GetAllAvailableFlights()
        {
            return _flightRepository.GetAll().Where(f => (double)f.Bookings / (double)f.Capacity < 1.0);
        }
    }
}
