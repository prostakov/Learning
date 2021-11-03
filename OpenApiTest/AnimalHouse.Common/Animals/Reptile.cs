namespace AnimalHouse.Common.Animals
{
    public class Reptile : Animal
    {
        public ReptileType ReptileType { get; set; }
    }
    
    public enum ReptileType
    {
        None = 0,
        Lizard,
        Turtle
    }
}