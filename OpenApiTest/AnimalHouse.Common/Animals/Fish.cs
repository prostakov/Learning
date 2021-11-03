namespace AnimalHouse.Common.Animals
{
    public class Fish : Animal
    {
        public FishType FishType { get; set; }
    }

    public enum FishType
    {
        None = 0,
        SwordFish = 1,
        ClownFish = 2
    }
}