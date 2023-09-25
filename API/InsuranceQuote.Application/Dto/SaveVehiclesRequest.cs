using System.ComponentModel.DataAnnotations;

namespace InsuranceQuote.Application.Dto
{
    public class SaveVehiclesRequest
    {
        [Required(ErrorMessage = "Vehicle Price is required")]
        public decimal VehiclePrice { get; set; }

        [Required(ErrorMessage = "Vehicle Make is required")]
        public string VehicleMake { get; set; }

        [Required(ErrorMessage = "Vehicle Model is required")]
        public string VehicleModel { get; set; }
    }

    public class VehiclesDTO
    {
        public VehiclesDTO() {}

        public VehiclesDTO(SaveVehiclesRequest saveVehicle)
        {
            Price = saveVehicle.VehiclePrice;
            Make = saveVehicle.VehicleMake;
            Model = saveVehicle.VehicleModel;
        }

        public decimal Price { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}