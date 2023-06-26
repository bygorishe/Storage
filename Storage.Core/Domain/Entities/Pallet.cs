namespace Core.Domain.Entities
{
    public class Pallet : BaseEntity
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; } = 30;
        public double Capacity { get; set; }

        public DateTimeOffset ExpirationDate { get; set; } = DateTimeOffset.MaxValue;

        public List<Box>? Boxes { get; set; }

        public Pallet() { }

        public Pallet(double height, double width, double depth, IEnumerable<Box>? boxes = null)
        {
            Id = Guid.NewGuid();
            Height = height;
            Width = width;
            Depth = depth;
            Capacity = height * width * depth;

            if (boxes is not null)
            {
                AddBoxes(boxes.ToArray());
            }
        }

        public void AddBoxes(params Box[] boxes)
        {
            foreach (var box in boxes)
            {
                double boxWidth = box.Width;
                double boxHeight = box.Height;
                if (boxWidth > Width && boxHeight > Height &&
                    boxWidth > Height && boxHeight > Width) //предполагаem, что коробку можно повернуть, но не переворачивать
                    throw new Exception("Box is oversized");

                Weight += box.Weight;
                Capacity += box.Capacity;

                if (box.ExpirationDate < ExpirationDate)
                    ExpirationDate = box.ExpirationDate;

                Boxes ??= new List<Box>();
                Boxes.Add(box);
            }
        }
    }
}
