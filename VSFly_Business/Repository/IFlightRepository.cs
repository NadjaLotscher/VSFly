using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSFly_Business.Models;

namespace VSFly_Business.Repository
{
    public interface IFlightRepository
    {
        public void Add(Flight flight);
        public IEnumerable<Flight> GetAll();
    }
}
