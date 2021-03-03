using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;
using YMCAProject.Models;
using YMCAProject.WebAPI.Data;

namespace YMCAProject.Services
{

    public class LocationService
    {

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    LocationID = model.LocationID,                   
                    LocationName = model.LocationName,
                    LocationAddress = model.LocationAddress,
                    LocationPhoneNumber = model.LocationPhoneNumber,
                    LocationEmail = model.LocationEmail,                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public LocationDetail GetLocationByID(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations

                    .Single(e => e.LocationID == locationID);

                return
                   new LocationDetail
                   {
                       LocationID = entity.LocationID,
                       LocationName = entity.LocationName,
                       LocationAddress = entity.LocationAddress,
                       LocationPhoneNumber = entity.LocationPhoneNumber,
                       LocationEmail = entity.LocationEmail,                       
                   };
            }
        }

        public IEnumerable<LocationListItem> GetAllLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Locations
                    .Select(
                        e => new LocationListItem

                        {
                            LocationID = e.LocationID,
                            LocationName = e.LocationName,
                            LocationAddress = e.LocationAddress,
                            LocationPhoneNumber = e.LocationPhoneNumber,
                            LocationEmail = e.LocationEmail,
                        }
                    );

                return query.ToArray();
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationID == model.LocationID);

                entity.LocationName = model.LocationName;
                entity.LocationPhoneNumber = model.LocationPhoneNumber;
                entity.LocationEmail = model.LocationEmail;                

                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteLocation(int locationID)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                      .Locations
                      .Single(e => e.LocationID == locationID);


                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
