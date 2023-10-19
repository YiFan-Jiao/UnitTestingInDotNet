using UnitTestingInDotNet.Data;

namespace UnitTestingInDotNet.Models.BuinessLogicLayer;

public class VehicleBuisnessLogic
{
    // INVERSION OF CONTROL
    private readonly IRepository<Vehicle> _vehicleRepo;
    private readonly IRepository<Pass> _passRepo;
    private readonly IRepository<ParkingSpot> _PakingSpotRepo;
    private readonly IRepository<Reservation> _ResvervationRepo;


    public VehicleBuisnessLogic(IRepository<Vehicle> vehicleRepo, IRepository<Pass> passRepo, IRepository<ParkingSpot> pakingSpotRepo, IRepository<Reservation> resvervationRepo)
    {
        _vehicleRepo = vehicleRepo;
        _passRepo = passRepo;
        _PakingSpotRepo = pakingSpotRepo;
        _ResvervationRepo  = resvervationRepo;
    }

    public Pass CreatePass(int capacity, string purchaser, bool premium)
    {
        Pass newPass = new Pass { Capacity = capacity, Purchaser = purchaser, Premium = premium };
        _passRepo.Create(newPass);
        return newPass;
    }

    public Vehicle AddVehicleToPass(Vehicle vehicle, Pass pass)
    {
        int VehiclesOnPass = _vehicleRepo.GetAll().Where(v => v.PassID == pass.ID).Count();

        if (VehiclesOnPass < pass.Capacity && vehicle.PassID != pass.ID)
        {
            vehicle.PassID = pass.ID;
            _vehicleRepo.Update(vehicle);
            return vehicle;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public Reservation BookParkingSpace(ParkingSpot parkingSpot, Vehicle vehicle)
    {
        if (IsParkingSpaceAvailable(parkingSpot))
        {
            Reservation reservation = new Reservation
            {
                ParkingSpotID = parkingSpot.ID,
                VehicleID = (int)vehicle.ID,
                IsCurrent = true
            };

            _ResvervationRepo.Create(reservation);

            parkingSpot.Occupied = true;
            _PakingSpotRepo.Update(parkingSpot);

            return reservation;
        }
        else
        {
            throw new InvalidOperationException("The parking spot is not available.");
        }
    }

    private bool IsParkingSpaceAvailable(ParkingSpot parkingSpot)
    {
        return !_ResvervationRepo.GetAll().Any(r => r.ParkingSpotID == parkingSpot.ID && r.IsCurrent);
    }

    public void LeaveParkingSpace(ParkingSpot parkingSpot, Vehicle vehicle)
    {
        Reservation currentReservation = GetCurrentReservation(parkingSpot, vehicle);

        if (currentReservation != null)
        {
            currentReservation.IsCurrent = false;
            _ResvervationRepo.Update(currentReservation);

            parkingSpot.Occupied = false;
            _PakingSpotRepo.Update(parkingSpot);

            vehicle.Parked = false;
            _vehicleRepo.Update(vehicle);
        }
        else
        {
            throw new InvalidOperationException("No current reservation found for the specified parking spot and vehicle.");
        }
    }

    private Reservation GetCurrentReservation(ParkingSpot parkingSpot, Vehicle vehicle)
    {
        return _ResvervationRepo.GetAll()
            .FirstOrDefault(r => r.ParkingSpotID == parkingSpot.ID && r.VehicleID == vehicle.ID && r.IsCurrent);
    }

}


