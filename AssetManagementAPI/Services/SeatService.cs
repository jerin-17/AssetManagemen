using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using AssetManagementAPI.MyExceptions;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI.Services
{
    public class SeatService : ISeatService
    {
        private readonly IRepository<Seat> _seatRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public SeatService(IRepository<Seat> seatRepository,IRepository<Employee> employeeRepository)

        {
            this._seatRepository = seatRepository;
            this._employeeRepository = employeeRepository;
        }

         public List<Seat> GetSeats()
        {
            return _seatRepository.GetAll().ToList();
        }

        public int CreateSeat(SeatDTO seat)
        {
            if(seat.SeatNumber == null)
            {
                throw new ArgumentNullException("Seat Number cannot be Null");
            }

            var seatNew = new Seat
            {
                SeatNumber = seat.SeatNumber,
                FacilityId = seat.FacilityId
            };
            _seatRepository.Add(seatNew);
            _seatRepository.Save();
            return seatNew.SeatId;
        }

        public void AllocateSeat(int SeatId, int employeeId)
        {
           Seat seat = _seatRepository.GetById(SeatId);
           if(seat.EmployeeId != null)
            {
                throw new DataExistsException("Seat is already allocated");
            }
           seat.EmployeeId = employeeId;
            _employeeRepository.GetById(employeeId).IsAllocated = true;
            _seatRepository.Update(seat);
            _seatRepository.Save();
            _employeeRepository.Save();
        }

        public void DeallocateSeat(int SeatId)
        {
            Seat seat = _seatRepository.GetById(SeatId);
            if (seat.EmployeeId == null)
            {
                throw new ArgumentNullException("Seat is not allocated");
            }
            _employeeRepository.GetById((int)seat.EmployeeId).IsAllocated = false;
            seat.EmployeeId = null;
            _seatRepository.Update(seat);
            _seatRepository.Save();
            _employeeRepository.Save();
        }
    }
}
