using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using AssetManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AssetDbContext>(options =>
             options.UseSqlServer("name=ConnectionStrings:DefaultConnection"),ServiceLifetime.Singleton);
            builder.Services.AddSingleton<IRepository<City>,EFRepository<City>>();
            builder.Services.AddSingleton<IRepository<Building>, EFRepository<Building>>();
            builder.Services.AddSingleton<IRepository<Department>, EFRepository<Department>>();
            builder.Services.AddSingleton<IRepository<Asset>, EFRepository<Asset>>();
            builder.Services.AddSingleton<IRepository<Facility>, EFRepository<Facility>>();
            builder.Services.AddSingleton<IRepository<Employee>, EFRepository<Employee>>();
            builder.Services.AddSingleton<IRepository<Seat>, EFRepository<Seat>>();
            builder.Services.AddSingleton<IRepository<MeetingRoom>, EFRepository<MeetingRoom>>();
            builder.Services.AddSingleton<IRepository<MeetingRoomAsset>, EFRepository<MeetingRoomAsset>>();
            builder.Services.AddSingleton<IRepository<Cabin>, EFRepository<Cabin>>();
            builder.Services.AddSingleton<IRepository<VAllocatedSeat>, EFRepository<VAllocatedSeat>>();
            builder.Services.AddSingleton<IRepository<VUnAllocatedSeat>, EFRepository<VUnAllocatedSeat>>();

            builder.Services.AddSingleton<ICityService, CityService>();
            builder.Services.AddSingleton<IBuildingService, BuildingService>();
            builder.Services.AddSingleton<IFacilityService, FacilityService>();
            builder.Services.AddSingleton<ISeatService, SeatService>();
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
            builder.Services.AddSingleton<IMeetingRoomService, MeetingRoomService>();
            builder.Services.AddSingleton<IMeetingRoomAssetService, MeetingRoomAssetService>();
            builder.Services.AddSingleton<ICabinService, CabinService>();
            builder.Services.AddSingleton<IReportService, ReportService>();
            builder.Services.AddSingleton<IDepartmentService, DepartmentService>();







            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}