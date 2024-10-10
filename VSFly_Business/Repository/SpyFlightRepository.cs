using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSFly_Business.Models;

namespace VSFly_Business.Repository
{
    public class SpyFlightRepository : IFlightRepository
    {
        private readonly List<Flight> _flightList = new List<Flight>();
        public List<Flight> FlightsCalled = new List<Flight>();
        public void Add(Flight flight)
        {
            _flightList.Add(flight);
        }

        public IEnumerable<Flight> GetAll()
        {
            FlightsCalled.AddRange(_flightList); // add the flights to the flightsCalled list, so I can later check that list
            return _flightList;
        }
    }
}
