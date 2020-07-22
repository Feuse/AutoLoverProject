using Interfaces;
using Microsoft.AspNetCore.Http;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;



namespace BotsImpl
{
    public class
        BadooBot : IBot
    {
        private readonly ICredentialDb CredentialDb;
        private int LikesLeft;
        private static IWebDriver Driver;
        private Random Random;
        private ServicePropertiesModel Model;
        

        private const string API_URL = "https://us1.badoo.com/api.phtml";

        private const string URL = "https://badoo.com/signin";

        public BadooBot(ICredentialDb db)
        {
            if (Driver == null)
            {
                Driver = GetSeleniumDriver();
            }
            Model = new ServicePropertiesModel();
            CredentialDb = db;
        }
        public async Task<List<PictureUrlModel>> GetImages(string sessionId, string userId)
        {
            userId = null;
            var jsonInput = ("{\"version\":1,\"message_type\":86,\"message_id\":56,\"body\":[{\"message_type\":86,\"server_get_album\":{\"person_id\":\"" + userId + "\",\"album_type\":2,\"preview_size\":{\"width\":180,\"height\":180}}}],\"is_background\":false}");
            List<PictureUrlModel> pictures = new List<PictureUrlModel>();
            var albumResult = await SendAndReturn(sessionId, jsonInput, userId);
            var albumModel = JsonConvert.DeserializeObject<AlbumResponseModel>(albumResult);

            var item = albumModel.Body[0];

            if (item.Album.Photos != null)
            {
                foreach (var photo in item.Album.Photos)
                {
                    PictureUrlModel url = new PictureUrlModel();
                    url.PreviewUrl = photo.PreviewUrl;
                    url.PhotoId = photo.Id.ToString();
                    pictures.Add(url); ;

                }
            }
            return pictures;
        }
        public async Task<LocalProjectionModel> LoginWithApi(string username, string password, string? sessionId)
        {
            LocalProjectionModel projectionModel = new LocalProjectionModel();

            var json = "{\"version\":1,\"message_type\":15,\"message_id\":2,\"body\":[{\"message_type\":15,\"server_login_by_password\":{\"remember_me\":true,\"user\":\"" + username + "\",\"password\":\"" + password + "\",\"stats_data\":\"JTE5dm5ybnNuc24lMTklMTlzdHBuenNxbnBxc3F6bHF6d3RxJTdCdndwcnF2JTFGbiUxOW8lN0JybnN1bm9zcyU3QnZyJTFGbiUxOW92em5wdnV6bnF0d3p3bHElN0J3c3p1c3dyenYlMUZuJTE5b3Z6bnN6d3pubyU3QnBzdGwlN0J0cHRwcXFxdXZ1cSUxRm4lMTlvdnVucHJxd25wenpzbHF3c3B2d3dyJTdCdHZ6JTFGbiUxOW93cG5wcHB0bnF2cnJsdHd6cXN6dHBycnp6JTFGbiUxOW93dm5wc3dzbm9zcCU3QnJscXZ6dSU3QnJyd3RxJTdCdiUxRm4lMTlvd3RucHB3cW5zenF6bHpxc3N3cnZ6dHRxdnYlMUZuJTE5b3clN0JucHN6dW5vc3N3dmx3cHp2dXdzdSU3QnF0JTdCdyUxRm4lMTlvdHNucHAlN0J3bnMlN0J6cGx0c3R2d3FydXZydHp2JTFGbiUxOW90cW5zJTdCd3Vub3dwJTdCcmx3cXR6cXZ1dHZ3cnElMUZuJTE5b3R3bnN1JTdCcm5vcHElN0JzbHJ1dHNzdXd0dXN3cyUxRm4lMTlvdHFuc3R1dW5vc3dzdGxyd3Zyenp1dnZ6d3V2JTFGbiUxOW90dG5zd3Nybm9wcnN1bHp0enR1dXclN0JycCU3QnF0JTFGbiUxOW90c25zc3Z1bm90dHRxbHUlN0J2c3olN0J2JTdCeiU3QndxJTFGbiUxOW93d256c3Zub3ZydHZsdXpxcnBycnElN0JxcHB6JTFGbiUxOW93cG52d3Rub3ZyenNsenB6cnBzend2JTdCc3YlMUZuJTE5c3d6bnN2dm5vd3J2cmx3c3ZwdyU3QnZ1dXolN0J3JTFGbiUxOXN2cm4lN0J1dG5zcCU3QiU3QnRscHd3dnRydXJ6dHVzJTFGbiUxOXN2c25zcHJzbnZxcHBsc3J6enRycHR1c3VwdyUxRm4lMTlzcXduc3Zzdm5wdnIlN0JsenMlN0IlN0JzcnB6cXV3dnElMUZuJTE5c3FwbnN1cHJucXR6dmx1cHUlN0J2c3NzcnZ2cHElMUZuJTE5c3FwbnN2JTdCd25vcXJwdWxydHd2c3J3JTdCc3d6dnQlMUZuJTE5c3AlN0Juc3V1dW52cnJ1bCU3QnVxcndxenJzdHF2cSUxRm4lMTlzcCU3Qm5zdXV1bnIlMUZuJTE5c3F3bnN1dHpub3NwdWxwdSU3QnBwcnRzcXd1end0JTFGbiUxOXNxcG5zdHpwbm9zc3d1bHJzc3R0enJ2enFxJTdCJTFGbiUxOXNxd25zdXR6bnNwc3RscHBxdHRxdHZyenRzeiUxRm4lMTlzcXpuc3Vwcm5vd3V1bCU3QiU3QnR3cSU3QnV6cHJxcnMlMUZuJTE5JTdCc250cG5vc3dwd3VwbHJxJTdCcHByenBzenYlMUZuJTE5b3F0bnN1cnJucHBwdSU3Qmxwcnp0JTdCcXFyenR3eiUxRm4lMTlvcXpucHJ3cm53dXZybHZwdHpzcXElN0IlN0J6d3clMUZuJTE5b3F6bnBwcHRucXNxcWx3JTdCciU3QnNzcSU3Qnp0c3clMUZuJTE5b3F1bnB0dXduJTdCdHIlN0JscnMlN0J0c3Vycnd0eiUxRm4lMTlvdnFucCU3QnN6bnd0dXBseiU3QnBzcyU3Qnd2d3F1cSUxRm4lMTlvdnducXN6cG50dXBybHF2cHp2enElN0J0JTdCdnUlMUZuJTE5b3Z0bnF0cHduc3B6dnUlMUZuJTE5b3Z6bnF1c3VucHVxd2xxd3R0diU3QndydHRydyUxRm4lMTlvd3JucSU3QnJ3bnd6dXFscXJ1dXd0cHpzenJxJTFGbiUxOW92JTdCbnF6c3Jub3B6JTdCd2x3d3B0cHZwenZxd3B3JTFGbiUxOW93cm5xJTdCcnducCU3QnR1bHolN0J2enV0enZ2d3B6diUxRm4lMTlvdiU3Qm5xdHF2bm91enV1bHR0dXZ6dnVxc3V3JTdCJTFGbiUxOW92em5xcXRxbm91cCU3QnNsenR2cHFxd3NxJTdCd3MlMUZuJTE5b3Z3bnFzenBub3Z0cnVsd3J1dXp0cHNzd3ZxJTFGbiUxOW92cW5wJTdCc3pub3RzdHFsc3Zwcnd3enJwcXpzJTFGbiUxOW92c25wdnpzbm96dHV2bHBycHFwdHZxJTdCcnN2JTFGbiUxOW92d25wc3Bzbm90c3IlN0JsdnJwd3olN0J2d3N1dSUxRm4lMTlvdnBuc3R6cG5vdyU3QnJ0bHN2ciU3Qnd0dHR3cXd6JTFGbiUxOW92cG5zd3J3bm9wc3FzbHF0cHB2cnZ2dHBxdHAlMUZuJTE5b3ZxbnNzcnRub3VydyU3QmxycXJ3JTdCJTdCc3R6dCU3QnolMUZuJTE5b3Z3bnVydW5vdndzdmxzdCU3QnQlN0JzciU3QnYlN0JzJTdCdyUxRm4lMTlvdXducXd0bm92cnJwbHJzd3V2cHIlN0J1JTdCdXYlMUZuJTE5b3Nyd25wcXpub3NxdndsdnJ1cnJzdHN0JTdCenB6JTFGbiUxOW91cW5zcXZub3NyendsdSU3QnN6dXQlN0JwdHQlN0J1cSUxRm4lMTlzd3RucHRub3NxcnZsJTdCdHolN0J0d3N2enBzcXolMUZuJTE5c3YlN0Juc3N0dG5zJTdCJTdCdnNsend3dnpycXVyJTdCcHUlMUZuJTE5c3Z6bnN2diU3Qm5xdHolN0JsenR6d3RzcXZ2dCU3QiU3QnQlMUZuJTE5c3Z1bnBxdXpuc3d2dHNsdHZzdnVzdXMlN0J0c3olMUZuJTE5c3dybnMlN0J1cG5venJydWx3dXN0dHR6dHRxcnYlMUZuJTE5c3YlN0JucXFxcG5xc3VwcmxxdXpxcnUlN0J3enZxdyUxRm4lMTlzdiU3Qm5wd3d3bm9zJTdCend3bHF3cHp3d3J6dHVzcCUxRm4lMTlzd3JudnRxc253dXR6c2x2cHV2dnZzJTdCd3d6dCUxRm4lMTlzdiU3Qm5xdHZ2bm9wenV1d2x1dnV0cnNydHN3d3UlMUZuJTE5c3Z6bnF6c3Rud3B3cmwlN0JxcHNydXVxciU3QnQlN0IlMUZuJTE5c3Z0bnZyd3RudXV6dWwlN0IlN0JydXd3cnJwcHN1JTFGbiUxOXN2cW52cHJybnZ6cXpsdnp3dXNxd3B0diU3QnQlMUZuJTE5c3ZxbnElN0Jwd25venRxd2xzdXdzd3V2dyU3QnN1JTFGbiUxOXN2c252cnJwbnB2dHdscHJwenFzdnNzdHZ1JTFGbiUxOXN2cm5xdXAlN0Jub3pzdnZscXVwJTdCcnZycXRwdyU3QiUxRm4lMTlzcSU3Qm5xdnd1bm91d3BxbHN2enB1dXN3ciU3QiU3QnclMUZuJTE5JTdCc251dW5vcHd0JTdCcnBscHF3enUlN0J1cHNxdyUxRm4lMTlvdHFucHdzdG52JTdCcnpxbCU3QnB6c3V2ciU3QnV6enYlMUZuJTE5b3RxbnB3c3RuciUxRm4lMTlvdyU3Qm5wdHF1bnB3d3BsdiU3QnV1JTdCdHB1dXBydXUlMUZuJTE5b3d0bnB6dXpud3d2emxwcXR0d3R6c3B0enZ3JTFGbiUxOW93cW5wdHV3bm92cXZ2bHF6JTdCdXN3dnpxdHF1JTFGbiUxOW93dm5xc3VwbnNzcnF3bHMlN0JyenZ3dHdxdXF3JTFGbiUxOW93cW5wcXV6bm9zdCU3QiU3QnBscXZwcnElN0J6dXMlN0J0JTFGbiUxOW93d25wdHJzbnZ0dnJscXAlN0J2cnR2c3J1c3ElMUZuJTE5b3d3bnB2cHVub3FxdXpsdnR6enpxJTdCdXR6enB2JTFGbiUxOW93JTdCbnBzenVub3ZzJTdCemxwendxdHZwenp0c3QlMUZuJTE5b3RwbnBzcHdub3Nyd3YlMUZuJTE5b3d6bnMlN0Jyem5vcXFzcGxxdHNwdnBxdXR6cnElMUZuJTE5b3d6bnN0cXJub3F0cHZsdHV0d3F1cCU3QnB0dXElMUZuJTE5b3clN0Juc3Z3em5vcHJyd2x6dnV2d3N6cHR1enF3JTFGbiUxOW93dW5zcnZybm90JTdCd3RsJTdCcnR2JTdCdHZwdiU3QnV2JTFGbiUxOW93dG4lN0Jyc25vcHJydmx0enR3ciU3QnN3dSU3QnV6JTFGbiUxOW93c24lN0J2em50dHVsJTdCJTdCd3dyeiU3QnR0JTdCcSU3QiUxRm4lMTlvdnpudXJ6bm9wenolN0JsJTdCenB0JTdCeiU3QnNyc3dzJTFGbiUxOW92em53dHNub3MlN0J1dWx0enB1cXYlN0JzJTdCenF3diUxRm4lMTlvcXZucHVybm9xc3Z1bHR2dHB0cXZ6cnJ0cHolMUZuJTE5b3BybnF0dG5zc3BxbHR3c3MlN0JzdnAlN0JyenYlMUZuJTE5b3FzbnZ6dG5zcSU3QiU3Qmx2cHp2d3Z1dHB6dXBwJTFGbiUxOW9wdW5wcXFub3B6cHpsdHB3JTdCJTdCc3dxdXBxdnElMUYlMUZucCU3Qm5wJTdCbnZudm5ybnJucm5ybiUyQzcuLm5ybnJucm5ybnNuJTJDNy4ubiUyQzcuLm4lMkM3Li5uJTJDNy4ubnNuJTJDNy4ubiUyQzcuLm4lMTklNjAlMjQtITcxLTc2JTYwbiU2MCUyNC0hNzElMkIlMkMlNjBuJTYwJTJCJTJDMjc2JTYwbiU2MCEqJTIzJTJDJTI1JyU2MG4lNjAlMjQtITcxLTc2JTYwbiU2MCUyNC0hNzElMkIlMkMlNjBuJTYwMTclMjAlMkYlMkI2JTYwJTFGbnNucm5ybnJucm5ybnJucm5ybnJucm5ybnBuc25ybnBuc25ybnNucm53bnduc24lMTklMTlzd3p3dHJzcHMlN0IlN0Jwem5zcm4lMTl6JTdCem56eiUxRiUxRm4lMTl6JTdCdW5zcm4lMTklN0Jwd24lN0J2JTFGJTFGbiUxOXNzcHVuc3JuJTE5dSU3QnVucCU3QnElMUYlMUZuJTE5cHV3c25zcm4lMTklN0JwcW56ciUxRiUxRm4lMTlwJTdCdyU3Qm5zcm4lMTl3JTdCc252c3UlMUYlMUZuJTE5cXdzJTdCbnNybiUxOXclN0JybnZ2diUxRiUxRm4lMTl2dHUlN0Juc3JuJTE5JTdCcHduc3ZyJTFGJTFGbiUxOXZ6enVuc3JuJTE5dXF6bnZwciUxRiUxRm4lMTl3c3Z2bnBzbiUxOXQlN0J1bnZ2c24lNjAlMjA3NjYtJTJDbCUyMDYlMkNsJTIwNiUyQ29vJTIwLi0hKSU2MCUxRiUxRiUxRm56dG4lNjAlMEYtOCUyQi4uJTIzbXdscmJqJTE1JTJCJTJDJTI2LTUxYiUwQyUxNmJzcmxyeWIlMTUlMkIlMkN0dnliJTNBdHZrYiUwMzIyLiclMTUnJTIwJTA5JTJCNm13cXVscXRiaiUwOSUwQSUxNiUwRiUwRW5iLiUyQiknYiUwNSchKS1rYiUwMSowLSUyRidtenJscmxxJTdCenVsc3YlN0JiJTExJTIzJTI0JTIzMCUyQm13cXVscXQlNjBuJTYwKidvJTBCJTBFJTYwbnB2bnpudm5vc3pybnNuc25zbnNucm5ybiU2MCUxNSUyQiUyQ3FwJTYwbjYwNyduJTI0JTIzLjEnbiUyQzcuLm42MDcnbiUyNCUyMy4xJ24lMjQlMjMuMSduJTI0JTIzLjEnbiUxOXJuJTI0JTIzLjEnbiUyNCUyMy4xJyUxRm4lMjQlMjMuMSduJTE5cyU3QnBybnNyenIlMUZuJTE5cyU3QnBybnNydnIlMUZuc24lMTklNjAlMDEqMC0lMkYnYiUxMiUwNiUwNGIlMTIuNyUyNSUyQiUyQ3h4JTEyLTA2JTIzJTIwLidiJTA2LSE3JTJGJyUyQzZiJTA0LTAlMkYlMjM2eHglMjMyMi4lMkIhJTIzNiUyQi0lMkNtJTNBbyUyNS0tJTI1LidvISowLSUyRidvMiUyNiUyNCUzQzIlMjYlMjQlNjBuJTYwJTAxKjAtJTJGJ2IlMTIlMDYlMDRiJTE0JTJCJzUnMHh4eHglMjMyMi4lMkIhJTIzNiUyQi0lMkNtMiUyNiUyNCUzQzIlMjYlMjQlNjBuJTYwJTBDJTIzNiUyQjQnYiUwMS4lMkInJTJDNnh4eHglMjMyMi4lMkIhJTIzNiUyQi0lMkNtJTNBbyUyQyUyMyEuJTNDbiUyMzIyLiUyQiElMjM2JTJCLSUyQ20lM0FvMiUyQyUyMyEuJTNDJTYwJTFGbiUxOSUxRm4lMjQlMjMuMSduJTE5NjA3J24lMjQlMjMuMSclMUYlMUY=\"}}],\"is_background\":false}";
            var loginResult = await SendAndReturn(sessionId, json);
            try
            {
                var objRes = JsonConvert.DeserializeObject<LoginResponseModel>(loginResult);


                // The body33 list always only has 1 item
                projectionModel.Projections = objRes.Body33.First().ClientLoginSuccess.UserInfo.Projection;
                projectionModel.UserId = objRes.Body33.First().ClientLoginSuccess.UserInfo.UserId.ToString();
                var serialized = JsonConvert.SerializeObject(projectionModel.Projections);
                var jsonReq = "{\"version\":1,\"message_type\":81,\"message_id\":14,\"body\":[{\"message_type\":81,\"server_get_encounters\":{\"number\":20,\"context\":1,\"user_field_filter\":{\"projection\":" + serialized + ",\"request_albums\":[{\"album_type\":7}],\"united_friends_filter\":[{\"count\":5,\"section_type\":3},{\"count\":5,\"section_type\":1},{\"count\":5,\"section_type\":2}]}}}],\"is_background\":false}";
                var getUsersResult = await SendAndReturn(sessionId, jsonReq);
                var usersRes = JsonConvert.DeserializeObject<UsersResponseModel>(getUsersResult);
                projectionModel.UsersIds = usersRes.Body.First().ClientEncounters.Results.Select(i => i.User.UserId).ToList();

            }
            catch (Exception)
            {

                throw;
            }


            projectionModel.time = DateTime.Now;
            return projectionModel;
        }

        public CookieModel Login(string username, string password, string? userId)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            // _driver = GetSeleniumDriver();
            CookieModel badooCookie = new CookieModel(); 
            Random = new Random();
            if (Driver.Url == "https://badoo.com/encounters")
            {
                return getBadooSiteCookie(userId, badooCookie, wait);
            }
            else
            {
                try
                {
                    Driver.Navigate().GoToUrl(URL);
                    Driver.FindElement(By.ClassName("js-signin-login")).Clear();
                    Driver.FindElement(By.ClassName("js-signin-login")).SendKeys(username);
                    Driver.FindElement(By.ClassName("js-signin-password")).SendKeys(password);
                    Driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                    //wait
                    //check if password correct
                    
                    wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
                    
                   
                    wait.Until(driver => Driver.Url.Contains("encounters"));
                    badooCookie = getBadooSiteCookie(userId, badooCookie, wait);

                    if (Driver.Url == "https://badoo.com/promo/spp")
                    {
                        Driver.FindElement(By.ClassName("js-spp-close")).Click();
                    }
                    else if (Driver.Url == URL)
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return badooCookie;
        }

        private CookieModel getBadooSiteCookie(string userId, CookieModel badooCookie, WebDriverWait wait)
        {
            OpenQA.Selenium.Cookie cookie = wait.Until(driver1 => GetCookie(Driver));
            badooCookie.SessionId = cookie.Value.ToString().Replace("%3A", ":");
            badooCookie.Expiry = cookie.Expiry;
            badooCookie.UserId = userId;
            return badooCookie;
        }

        public OpenQA.Selenium.Cookie GetCookie(IWebDriver driver)
        {
            OpenQA.Selenium.Cookie cookie = null;
            while (cookie == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        var test = $"s{i}";
                        cookie = Driver.Manage().Cookies.GetCookieNamed($"s{i}");
                        if (cookie != null)
                        {
                            return cookie;
                        }


                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            return cookie;
        }

        public async Task<List<string>> GetCities(string input, string sessionId)
        {
            var jsonInput = "{\"version\":1,\"message_type\":29,\"message_id\":92,\"body\":[{\"message_type\":29,\"server_search_locations\":{\"with_countries\":false,\"query\":\"" + input + "\"}}],\"is_background\":false}";

            var locationResultModel = await SendAndReturn(sessionId, jsonInput, input);

            var objRes = JsonConvert.DeserializeObject<LocationResultModel>(locationResultModel);
            List<string> locationModel = new List<string>();
            var reponseBody = objRes.BodyResultModel.First();

            if (reponseBody.ClientLocations.Locations != null)
            {
                foreach (var singleLocation in reponseBody.ClientLocations.Locations)
                {
                    string newLocation = $"{singleLocation.City.Name}, {singleLocation.Region.Name}, {singleLocation.Country.Name}";
                    locationModel.Add(newLocation);
                }
            }
            else
            {
                // WRITE LOG HERE NIGRO
            }

            return locationModel;
        }
        public async Task GetCountryId(string sessionId, string input)
        {
            var jsonInput = "{\"version\":1,\"message_type\":29,\"message_id\":92,\"body\":[{\"message_type\":29,\"server_search_locations\":{\"with_countries\":false,\"query\":\"" + input + "\"}}],\"is_background\":false}";
            var locationResultModel = await SendAndReturn(sessionId, jsonInput, input);
            var objRes = JsonConvert.DeserializeObject<LocationResultModel>(locationResultModel);

            var locationList = objRes.BodyResultModel.First().ClientLocations.Locations;
            if (locationList != null)
            {
                foreach (var singleLocation in locationList)
                {
                    await SaveLocation(sessionId, singleLocation.City.Id.ToString());
                }
            }
            else
            {
                //log
            }
        }

        public async Task SaveLocation(string sessionId, string location)
        {
            var jsonInput = "{\"version\":1,\"message_type\":32,\"message_id\":23,\"body\":[{\"message_type\":32,\"p_integer\":{\"value\":" + location + "}}],\"is_background\":false}";
            await SendAndReturn(sessionId, jsonInput);
        }

        public async Task ChangeDescription(string sessionId, string proffesion, string companyName, string school)
        {
            //if user changes description 2nd time right after fist time session id == null.

            string jsonInput = "{\"version\":1,\"message_type\":616,\"message_id\":26,\"body\":[{\"message_type\":616,\"server_experience_action\":{\"context\":130,\"action\":2,\"experiences\":[{\"$gpb\":\"badoo.bma.Experience\",\"id\":\"keep_only_one\",\"type\":1,\"name\":\"" + proffesion + "\",\"organization_name\":\"" + companyName + "\",\"selected\":true,\"source\":1,\"moderation_failed\":false,\"name_length_limit\":250,\"organization_name_length_limit\":30},{\"$gpb\":\"badoo.bma.Experience\",\"id\":\"keep_only_one\",\"type\":2,\"name\":\"\",\"organization_name\":\"" + school + "\",\"selected\":true,\"source\":1,\"moderation_failed\":false,\"name_length_limit\":0,\"organization_name_length_limit\":250}]}}],\"is_background\":false}";
            await SendAndReturn(sessionId, jsonInput);
        }



        public async Task<string> SendAndReturn(string sessionId, string jsonInput, string input = "")
        {
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(jsonInput);
            content.Headers.Add("X-Session-Id", sessionId);
            var res = await client.PostAsync("https://eu1.badoo.com/webapi.phtml", content);
            var ss = await res.Content.ReadAsStringAsync();
            return await res.Content.ReadAsStringAsync();
        }
        private static ChromeDriver GetSeleniumDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            return new ChromeDriver(options);
        }

        public void ShutDown()
        {
            Driver.Dispose();

        }

        public async Task<LocalProjectionModel> GetLast(LocalProjectionModel projList, string sessionId)
        {
            LocalProjectionModel model = new LocalProjectionModel();
            var last = projList.UsersIds[projList.UsersIds.Count - 1];
            var replaced = last.Replace("]", "");
            replaced = replaced.Replace("\"", "");
            var parsed = JsonConvert.SerializeObject(projList.Projections);
            var encountersReq = "{\"version\":1,\"message_type\":81,\"message_id\":41,\"body\":[{\"message_type\":81,\"server_get_encounters\":{\"number\":20,\"context\":1,\"last_person_id\":\"" + replaced + "\",\"user_field_filter\":{\"projection\":" + parsed + ",\"request_albums\":[{\"album_type\":7}],\"united_friends_filter\":[{\"count\":5,\"section_type\":3},{\"count\":5,\"section_type\":1},{\"count\":5,\"section_type\":2}]}}}],\"is_background\":false}";

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(encountersReq);
            content.Headers.Add("X-Session-Id", sessionId);
            var res = await client.PostAsync("https://badoo.com/webapi.phtml?SERVER_GET_ENCOUNTERS", content);
            var strRes = await res.Content.ReadAsStringAsync();
            var objRes = JsonConvert.DeserializeObject<UsersResponseModel>(strRes);
            model.UsersIds = new List<string>();
            model.Projections = new List<long>();
            model.SessionId = sessionId;
            model.UsersIds = projList.UsersIds;
            model.UserId = projList.UserId;
            foreach (var item in objRes.Body)
            {
                foreach (var itemRes in item.ClientEncounters.Results)
                {
                    model.UsersIds.Add(itemRes.User.UserId);
                    model.Projections = itemRes.User.Projection;
                }
            }
            return model;
        }


        public async Task<int> ExecuteLikes(int likes)
        {
            var likesLeft = likes;
            List<string> userIds = ExtractUserIdsFromList(Model.UsersIds);
            var result = JsonConvert.SerializeObject(Model.UsersIds);

            for (int i = 0; i < likes; i++)
            {
                var id = userIds[i];
                var json = "{\"version\":1,\"message_type\":80,\"message_id\":16,\"body\":[{\"message_type\":80,\"server_encounters_vote\":{\"person_id\":\"" + id + "\",\"vote\":2,\"photo_id\":\"\",\"vote_source\":1}}],\"is_background\":false}";
                try
                {
                    var res = await SendAndReturn(Model.SessionId, json);
                    //could get error of reached likes limit, need to handle.
                    //send email to user.
                    Console.WriteLine("liked - "  + id + " likes left - " + likesLeft);

                    likesLeft--;
                }
                catch (Exception)
                {
                    return likesLeft;
                }
            }
            return likesLeft;
        }

        private List<string> ExtractUserIdsFromList(string userIds)
        {
            var leftRemoved = userIds.Replace("[", "");
            var rightRemoved = leftRemoved.Replace("]", "");
            var allRemovd = rightRemoved.Replace("\"", "");
            var slashRemoved = allRemovd.Replace("\\", "");
            var li = slashRemoved.Split(",").ToList();
            return li;
        }

        public async Task InitializeBot(ServiceCredentialsModel user, MessageWithoutUser message)
        {
            var users = CredentialDb.GetUsersModel(user.UserId);
            var userIdsFromList = ExtractUserIdsFromList(users.UsersIds);

            //if (users == null || userIdsFromList.Count <= message.Likes)
            //{
                //Need to get last from db, if no last, get from api, then save last at db for next time.   

                LocalProjectionModel projModel = new LocalProjectionModel();
                var cookie = Login(user.Username, user.Password, message.UserId);
                var projList = await LoginWithApi(user.Username, user.Password, cookie.SessionId);
                

                for (int i = 1; i < message.Likes / 20; i++)
                {
                    if (projList.UsersIds.Count < message.Likes)
                    {
                        projList = await GetLast(projList, cookie.SessionId);
                    }

                }


                var serialized = JsonConvert.SerializeObject(projList.UsersIds);
                var serializedProjections = JsonConvert.SerializeObject(projList.Projections);
                Model.SessionId = cookie.SessionId;
                Model.UserId = user.UserId;
                Model.UsersIds = serialized;
                Model.Projections = serializedProjections;

                ProjectionModel projectionModel = new ProjectionModel()
                {
                    Projections = serializedProjections,
                    UsersIds = serialized,
                    SessionId = cookie.SessionId,
                    time = projList.time,
                    UserId = projList.UserId
                };
                CredentialDb.SaveProjections(projectionModel);

            //}
            //else
            //{
                //Model.SessionId = users.SessionId;
                //Model.UserId = users.UserId;
                //Model.UsersIds = users.UsersIds;
                //Model.Projections = users.Projections;
            //}
        }

        public async Task ChangeDescriptions(string description, Service services, string sessionId)
        {
            var jsonInput = "{\"version\":1,\"message_type\":405,\"message_id\":22,\"body\":[{\"message_type\":405,\"server_save_user\":{\"user\":{\"user_id\":\"777595735\",\"profile_fields\":[{\"type\":2,\"value\":\"Test\",\"display_value\":\"\"},{\"type\":3,\"value\":\"None\",\"display_value\":\"\"},{\"type\":4,\"value\":\"None\",\"display_value\":\"\"},{\"type\":6,\"value\":\"None\",\"display_value\":\"\"},{\"type\":7,\"value\":\"None\",\"display_value\":\"\"},{\"type\":8,\"value\":\"None\",\"display_value\":\"\"},{\"type\":9,\"value\":\"None\",\"display_value\":\"\"},{\"type\":13,\"value\":\"0\",\"display_value\":\"\"},{\"type\":14,\"value\":\"0\",\"display_value\":\"\"},{\"type\":15,\"value\":\"None\",\"display_value\":\"\"},{\"type\":16,\"value\":\"None\",\"display_value\":\"\"},{\"type\":17,\"value\":\"None\",\"display_value\":\"\"}]},\"save_field_filter\":{\"projection\":[490]},\"return_field_filter\":{\"projection\":[490,50]}}}],\"is_background\":false}";
            var locationResultModel = await SendAndReturn(sessionId, jsonInput, "");
            var objRes = JsonConvert.DeserializeObject<LocationResultModel>(locationResultModel);
        }
        //}
    }
}
