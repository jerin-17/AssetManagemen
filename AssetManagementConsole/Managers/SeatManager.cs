using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class SeatManager
    {
        private readonly IInputProvider<Seat> _seatInput;
        private readonly IEntityManager<Seat> _entityManager;
        public SeatManager(IInputProvider<Seat> seatInput, IEntityManager<Seat> entityManager)
        {
            this._seatInput = seatInput;
            this._entityManager = entityManager;
        }

        public List<Seat> GetSeats()
        {
            return _entityManager.GetAll();
        }

        public int OnboardSeat()
        {
            Seat seat = _seatInput.GetInput();
            return _entityManager.Create(seat);

        }

    }
}
