using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSFly_Business.Models;

namespace VSFly_Business.Repository
{
    public class StubFlightRepository : IFlightRepository
    {
        private List<Flight> _flights;

        public StubFlightRepository(List<Flight> f)
        {
            _flights = f;
        }

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
