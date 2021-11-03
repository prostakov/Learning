namespace AnimalHouse.Common.Animals
{
    public class Mammal : Animal
    {
        public MammalType MammalType { get; set; }
    }

    public enum MammalType
    {
        None = 0,
        Cat = 1,
        Dog = 2
    }
}