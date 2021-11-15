using System;
using System.Collections.Generic;
using System.Linq;
using AnimalHouse.Common.Models;
using AnimalHouse.Common.Models.Animals;

namespace AnimalHouse.DesignFirst.Server.Converters
{
    public static class AnimalsConverter
    {
        public static AnimalHouse.DesignFirst.Server.Controllers.Animal ToDto(this Animal model)
        {
            return model switch
            {
                Bird bird => ToDto(bird),
                Fish fish => ToDto(fish),
                Mammal mammal => ToDto(mammal),
                Reptile reptile => ToDto(reptile),
                _ => throw new ArgumentOutOfRangeException(nameof(model))
            };
        }
        
        private static AnimalHouse.DesignFirst.Server.Controllers.Bird ToDto(Bird model)
        {
            var dto = new AnimalHouse.DesignFirst.Server.Controllers.Bird {BirdType = MapBirdType(model.BirdType)};
            dto.MapAnimal(model);
            return dto;
        }
        
        private static AnimalHouse.DesignFirst.Server.Controllers.Mammal ToDto(Mammal model)
        {
            var dto = new AnimalHouse.DesignFirst.Server.Controllers.Mammal {MammalType = MapMammalType(model.MammalType)};
            dto.MapAnimal(model);
            return dto;
        }

        private static AnimalHouse.DesignFirst.Server.Controllers.Fish ToDto(Fish model)
        {
            var dto = new AnimalHouse.DesignFirst.Server.Controllers.Fish {FishType = MapFishType(model.FishType)};
            dto.MapAnimal(model);
            return dto;
        }

        private static AnimalHouse.DesignFirst.Server.Controllers.Reptile ToDto(Reptile model)
        {
            var dto = new AnimalHouse.DesignFirst.Server.Controllers.Reptile {ReptileType = MapReptileType(model.ReptileType)};
            dto.MapAnimal(model);
            return dto;
        }

        private static void MapAnimal(this Controllers.Animal dto, Animal model)
        {
            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.Tags = model.Tags?.ToList() ?? new List<string>();
            dto.CreatedAt = model.CreatedAt;
        } 

        private static AnimalHouse.DesignFirst.Server.Controllers.BirdType MapBirdType(BirdType birdType)
        {
            return birdType switch
            {
                BirdType.None => Controllers.BirdType._0,
                BirdType.Parrot => Controllers.BirdType._1,
                BirdType.Peacock => Controllers.BirdType._2,
                _ => throw new ArgumentOutOfRangeException(nameof(birdType), birdType, null)
            };
        }
        
        private static AnimalHouse.DesignFirst.Server.Controllers.MammalType MapMammalType(MammalType mammalType)
        {
            return mammalType switch
            {
                MammalType.None => Controllers.MammalType._0,
                MammalType.Cat => Controllers.MammalType._1,
                MammalType.Dog => Controllers.MammalType._2,
                _ => throw new ArgumentOutOfRangeException(nameof(mammalType), mammalType, null)
            };
        }
        
        private static AnimalHouse.DesignFirst.Server.Controllers.FishType MapFishType(FishType fishType)
        {
            return fishType switch
            {
                FishType.None => Controllers.FishType._0,
                FishType.SwordFish => Controllers.FishType._1,
                FishType.ClownFish => Controllers.FishType._2,
                _ => throw new ArgumentOutOfRangeException(nameof(fishType), fishType, null)
            };
        }
        
        private static AnimalHouse.DesignFirst.Server.Controllers.ReptileType MapReptileType(ReptileType reptileType)
        {
            return reptileType switch
            {
                ReptileType.None => Controllers.ReptileType._0,
                ReptileType.Lizard => Controllers.ReptileType._1,
                ReptileType.Turtle => Controllers.ReptileType._2,
                _ => throw new ArgumentOutOfRangeException(nameof(reptileType), reptileType, null)
            };
        }
    }
}