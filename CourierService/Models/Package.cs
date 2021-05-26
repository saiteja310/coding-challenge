
namespace CourierService.Models
{
    public class Package
    {
        public string PackageName { get; }
        public double Weight { get; }
        public double DistanceInKm { get; }

        public Package(string packageName, double weight, double distanceInKm)
        {
            this.PackageName = packageName;
            this.Weight = weight;
            this.DistanceInKm = distanceInKm;
        }
    }
}
