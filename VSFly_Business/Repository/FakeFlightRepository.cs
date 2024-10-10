using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSFly_Business.Models;

namespace VSFly_Business.Repository
{
    public class FakeFlightRepository : IFlightRepository
    {

        private List<Flight> _flights = new List<Flight>(); // this is the Fake

        public void Add(Flight flight)
        {
            _flights.Add(flight);
        }

        public IEnumerable<Flight> GetAll()
        {
            return _flights;
        }
    }
}
