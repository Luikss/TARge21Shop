﻿using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Dto;

namespace TARge21Shop.Core.ServiceInterface
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
        Task<FileToApi> RemoveImage(FileToApiDto dto);
        Task<List<FileToApi>> RemoveImages(FileToApiDto[] dtos);
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabase[] dtos);
        void FilesToApi(RealEstateDto dto, RealEstate realEstate);
    }
}
