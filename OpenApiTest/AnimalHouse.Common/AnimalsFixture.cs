using System;
using AnimalHouse.Common.Animals;

namespace AnimalHouse.Common
{
    public static class AnimalsFixture
    {
        public static Animal[] List => new Animal[]
        {
            new Bird
            {
                BirdType = BirdType.Parrot,
                Id = Guid.Parse("2314e5b3-74eb-4a74-a05a-2c808f0919da"),
                Name = "Parrot Johnny",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag1" }
            },
            new Bird
            {
                BirdType = BirdType.Peacock,
                Id = Guid.Parse("74eb6b55-cfca-4bae-846b-5907f18bd4d6"),
                Name = "Peacock Johnny",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag2" }
            },
            new Bird
            {
                BirdType = BirdType.Parrot,
                Id = Guid.Parse("b1a170cb-af45-4a41-9ce3-ba2e058c4d73"),
                Name = "Parrot James",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag3" }
            },
            new Fish
            {
                FishType = FishType.ClownFish,
                Id = Guid.Parse("cc9439b9-0f25-4a0e-88e3-776fc0da12c5"),
                Name = "Clown Fish Harry",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag1" }
            },
            new Fish
            {
                FishType = FishType.SwordFish,
                Id = Guid.Parse("be473c14-4671-4382-9203-ca9df448a124"),
                Name = "Sword Fish Jerry",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag2" }
            },
            new Fish
            {
                FishType = FishType.ClownFish,
                Id = Guid.Parse("dd6443c3-3880-4cbe-b5e3-bae56213466d"),
                Name = "Clown Fish Perry",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag3" }
            },
            new Mammal
            {
                MammalType = MammalType.Cat,
                Id = Guid.Parse("eae73a9b-dfd5-4798-a0f6-c6311821951b"),
                Name = "Cat Bob",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag1" }
            },
            new Mammal
            {
                MammalType = MammalType.Dog,
                Id = Guid.Parse("34e5c20a-252e-42c6-803b-4b0ac93bceb2"),
                Name = "Dog Chappie",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag2" }
            },
            new Mammal
            {
                MammalType = MammalType.Cat,
                Id = Guid.Parse("8bd11e50-9731-4ead-81fe-14ecfaa80566"),
                Name = "Bob Cat",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag3" }
            },
            new Reptile
            {
                ReptileType = ReptileType.Lizard,
                Id = Guid.Parse("061f60dd-7a01-4801-a7a6-ec42a93757ae"),
                Name = "Lizard Tutsie",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag1" }
            },
            new Reptile
            {
                ReptileType = ReptileType.Turtle,
                Id = Guid.Parse("56eacf0c-7fbd-4d25-a46d-c5e8b095824b"),
                Name = "Turtle Earl",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag2" }
            },
            new Reptile
            {
                ReptileType = ReptileType.Lizard,
                Id = Guid.Parse("117beb15-9717-4bb6-85e3-846a06785dc1"),
                Name = "Lizard Genie",
                CreatedAt = DateTime.UtcNow,
                Tags = new []{ "tag3" }
            }
        };
    }
}