using Interfaces;
using Models;
using System;
using UtilModels;

namespace Factories
{
    public class JsonFactory : IJsonFactory
    {
        
        public IJsonMessage GetJson(JsonTypes types)
        {
            switch (types)
            {
                case JsonTypes.Login:
                    return new LoginJsonModel();
                case JsonTypes.SaveLocation:
                    return new SaveLocationModel();
                case JsonTypes.GetLast:
                    return new LoginJsonModel();
                case JsonTypes.GetImages:
                    return new GetImagesModel();
                case JsonTypes.GetCountryById:
                    return new GetCountryByIdModel();
                case JsonTypes.GetCities:
                    return new GetCitiesModel();
                case JsonTypes.ExecuteLikes:
                    return new ExecuteLikesModel();
                case JsonTypes.ChangeDescription:
                    return new ChangeDescriptionModel();
                case JsonTypes.GetEncounters:
                    return new GetEncountersModel();
                case JsonTypes.ChangeAboutMe:
                    return new AboutMeModel();
                case JsonTypes.GetLastEncounter:
                    return new GetLastEncountersModel();
                case JsonTypes.AppStartupModel:
                    return new AppStartupModel();
                case JsonTypes.RemoveImage:
                    return new RemoveImageModel();
                case JsonTypes.GetSearchSettings:
                    return new GetSearchSettingModel();
                case JsonTypes.UpdateUserSearchSettings:
                    return new UpdateUserSearchSettings();
                case JsonTypes.UploadImage:
                    return new UploadImageModel();
                case JsonTypes.StartExternalProviderImport:
                    return new StartExternalProviderImport();
                case JsonTypes.GetExternalProviderPhotos:
                    return new GetExternalProviderPhotos();
                default:
                    break;
            }
            throw new Exception("Service error");
        }
    }
}
