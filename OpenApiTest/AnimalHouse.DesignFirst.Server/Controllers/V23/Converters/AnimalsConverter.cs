using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalHouse.DesignFirst.Server.Controllers.V23.Converters
{
    public static class AnimalsConverter
    {
        public static Animal ToDto(this Common.Models.Animal model)
        {
            return model switch
            {
                Common.Models.Animals.Bird bird => ToDto(bird),
                Common.Models.Animals.Fish fish => ToDto(fish),
                Common.Models.Animals.Mammal mammal => ToDto(mammal),
                Common.Models.Animals.Reptile reptile => ToDto(reptile),
                _ => throw new ArgumentOutOfRangeException(nameof(model))
            };
        }
        
        private static Bird ToDto(AnimalHouse.Common.Models.Animals.Bird model)
        {
            var dto = new Bird {BirdType = MapBirdType(model.BirdType)};
            dto.MapAnimal(model);
            return dto;
        }
        
        private static Mammal ToDto(Common.Models.Animals.Mammal model)
        {
            var dto = new Mammal {MammalType = MapMammalType(model.MammalType)};
            dto.MapAnimal(model);
            return dto;
        }

        private static Fish ToDto(Common.Models.Animals.Fish model)
        {
            var dto = new Fish {FishType = MapFishType(model.FishType)};
            dto.MapAnimal(model);
            return dto;
        }

        private static Reptile ToDto(Common.Models.Animals.Reptile model)
        {
            var dto = new Reptile {ReptileType = MapReptileType(model.ReptileType)};
            dto.MapAnimal(model);
            return dto;
        }

        private static void MapAnimal(this Animal dto, Common.Models.Animal model)
        {
            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.Tags = model.Tags?.ToList() ?? new List<string>();
            dto.CreatedAt = model.CreatedAt;
        } 

        private static BirdType MapBirdType(Common.Models.Animals.BirdType birdType)
        {
            return birdType switch
            {
                Common.Models.Animals.BirdType.None => BirdType._0,
                Common.Models.Animals.BirdType.Parrot => BirdType._1,
                Common.Models.Animals.BirdType.Peacock => BirdType._2,
                _ => throw new ArgumentOutOfRangeException(nameof(birdType), birdType, null)
            };
        }
        
        private static MammalType MapMammalType(Common.Models.Animals.MammalType mammalType)
        {
            return mammalType switch
            {
                Common.Models.Animals.MammalType.None => MammalType._0,
                Common.Models.Animals.MammalType.Cat => MammalType._1,
                Common.Models.Animals.MammalType.Dog => MammalType._2,
                _ => throw new ArgumentOutOfRangeException(nameof(mammalType), mammalType, null)
            };
        }
        
        private static FishType MapFishType(Common.Models.Animals.FishType fishType)
        {
            return fishType switch
            {
                Common.Models.Animals.FishType.None => FishType._0,
                Common.Models.Animals.FishType.SwordFish => FishType._1,
                Common.Models.Animals.FishType.ClownFish => FishType._2,
                _ => throw new ArgumentOutOfRangeException(nameof(fishType), fishType, null)
            };
        }
        
        private static ReptileType MapReptileType(Common.Models.Animals.ReptileType reptileType)
        {
            return reptileType switch
            {
                Common.Models.Animals.ReptileType.None => ReptileType._0,
                Common.Models.Animals.ReptileType.Lizard => ReptileType._1,
                Common.Models.Animals.ReptileType.Turtle => ReptileType._2,
                _ => throw new ArgumentOutOfRangeException(nameof(reptileType), reptileType, null)
            };
        }
    }
}