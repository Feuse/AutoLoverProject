using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum JsonTypes
    {
        Login = 0,
        GetImages = 1,
        GetCities = 2,
        GetCountryById = 3,
        SaveLocation = 4,
        GetLast = 5,
        ExecuteLikes = 6,
        ChangeDescription = 7,
        GetEncounters = 8,
        ChangeAboutMe = 9,
        GetLastEncounter = 10,
        AppStartupModel=11,
        UploadImage = 12,
        RemoveImage = 13,
        GetSearchSettings = 14,
        UpdateUserSearchSettings = 15,
        StartExternalProviderImport = 16,
        ExternalProviderImportResponse = 17,
        GetExternalProviderPhotos = 18
    }
}
