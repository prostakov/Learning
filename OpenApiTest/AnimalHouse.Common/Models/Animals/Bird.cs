namespace AnimalHouse.Common.Models.Animals
{
    public class Bird : Animal
    {
        public BirdType BirdType { get; set; }
    }

    public enum BirdType
    {
        None = 0,
        Parrot = 1,
        Peacock = 2,
    }
}