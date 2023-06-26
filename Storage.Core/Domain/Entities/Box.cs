namespace Core.Domain.Entities
{
    public class Box : BaseEntity
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public double Capacity { get; set; }

        public DateTimeOffset? ProductionDate { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }

        public Box() { }

        public Box(double height, double width, double depth, double weight,
                   DateTimeOffset? productionDate = null, DateTimeOffset? expirationDate = null)
        {
            if (productionDate == null && expirationDate == null)
                throw new Exception("Date not specified");
            Id = Guid.NewGuid();
            Height = height;
            Width = width;
            Depth = depth;
            Weight = weight;
            Capacity = height * width * depth;
            ProductionDate = productionDate;
            ExpirationDate = (DateTimeOffset)(expirationDate != null ? expirationDate :
               ((DateTimeOffset)ProductionDate!).AddDays(100));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            Box other = (Box)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
