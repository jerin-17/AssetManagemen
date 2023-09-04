using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using AssetManagementAPI.MyExceptions;
using AssetManagementAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> _facilityRepository;

        public FacilityService(IRepository<Facility> facilityRepository)
        {
            this._facilityRepository = facilityRepository;
        }
        public List<Model.Facility> GetFacilities()
        {
            return _facilityRepository.GetAll().ToList();
        }

       
        public int CreateFacility(FacilityDTO facility)
        {
            if(facility.FacilityName == null)
            {
                throw new ArgumentNullException ("Facility Name should not be null");
            }
            if(facility.FacilityAbbr == null)
            {
                throw new ArgumentNullException("Facility Abbreviation should not be null");
            }

            var validator = new AbbrValidator<Model.Facility>(GetFacilities());
            validator.ValidateAbbr(facility.FacilityAbbr, Facility => Facility.FacilityAbbr);

            var facilityNew = new Facility()
            {
                FacilityName = facility.FacilityName,
                FacilityAbbr = facility.FacilityAbbr,
                FloorNumber = facility.FloorNumber,
                BuildingId = facility.BuildingId,
                CityId = facility.CityId,
            };
            _facilityRepository.Add(facilityNew);

            _facilityRepository.Save();

            return facilityNew.FacilityId;
        }
    }

}
