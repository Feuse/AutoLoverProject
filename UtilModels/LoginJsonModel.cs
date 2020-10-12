using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilModels
{
    public class LoginJsonModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 15;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 2;

        [JsonProperty("body")]
        public BodyLoginJsonModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;

        public LoginJsonModel()
        {
            Body = new BodyLoginJsonModel[] { new BodyLoginJsonModel()};
        }

        public void SetProperties(string s1, string s2)
        {
            Body.First().ServerLoginByPassword.User = s1;
            Body.First().ServerLoginByPassword.Password = s2;
        }

        public void SetProperty(List<long> projections)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(string s1, List<long> l1)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string query)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(string proffesion, string companyName, string school)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(long s1, long s2, long s3, long[] s4)
        {
            throw new NotImplementedException();
        }
    }

    public class BodyLoginJsonModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 15;

        [JsonProperty("server_login_by_password")]
        public ServerLoginByPasswordLoginJsonModel ServerLoginByPassword { get; set; }

        public BodyLoginJsonModel()
        {
            ServerLoginByPassword = new ServerLoginByPasswordLoginJsonModel();
        }
    }

    public class ServerLoginByPasswordLoginJsonModel
    {
        [JsonProperty("remember_me")]
        public bool RememberMe { get; set; } = true;

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("stats_data")]
        public string StatsData { get; set; } = "JTE5dm5ybnNuc24lMTklMTlzdHBuenNxbnBxc3F6bHF6d3RxJTdCdndwcnF2JTFGbiUxOW8lN0JybnN1bm9zcyU3QnZyJTFGbiUxOW92em5wdnV6bnF0d3p3bHElN0J3c3p1c3dyenYlMUZuJTE5b3Z6bnN6d3pubyU3QnBzdGwlN0J0cHRwcXFxdXZ1cSUxRm4lMTlvdnVucHJxd25wenpzbHF3c3B2d3dyJTdCdHZ6JTFGbiUxOW93cG5wcHB0bnF2cnJsdHd6cXN6dHBycnp6JTFGbiUxOW93dm5wc3dzbm9zcCU3QnJscXZ6dSU3QnJyd3RxJTdCdiUxRm4lMTlvd3RucHB3cW5zenF6bHpxc3N3cnZ6dHRxdnYlMUZuJTE5b3clN0JucHN6dW5vc3N3dmx3cHp2dXdzdSU3QnF0JTdCdyUxRm4lMTlvdHNucHAlN0J3bnMlN0J6cGx0c3R2d3FydXZydHp2JTFGbiUxOW90cW5zJTdCd3Vub3dwJTdCcmx3cXR6cXZ1dHZ3cnElMUZuJTE5b3R3bnN1JTdCcm5vcHElN0JzbHJ1dHNzdXd0dXN3cyUxRm4lMTlvdHFuc3R1dW5vc3dzdGxyd3Zyenp1dnZ6d3V2JTFGbiUxOW90dG5zd3Nybm9wcnN1bHp0enR1dXclN0JycCU3QnF0JTFGbiUxOW90c25zc3Z1bm90dHRxbHUlN0J2c3olN0J2JTdCeiU3QndxJTFGbiUxOW93d256c3Zub3ZydHZsdXpxcnBycnElN0JxcHB6JTFGbiUxOW93cG52d3Rub3ZyenNsenB6cnBzend2JTdCc3YlMUZuJTE5c3d6bnN2dm5vd3J2cmx3c3ZwdyU3QnZ1dXolN0J3JTFGbiUxOXN2cm4lN0J1dG5zcCU3QiU3QnRscHd3dnRydXJ6dHVzJTFGbiUxOXN2c25zcHJzbnZxcHBsc3J6enRycHR1c3VwdyUxRm4lMTlzcXduc3Zzdm5wdnIlN0JsenMlN0IlN0JzcnB6cXV3dnElMUZuJTE5c3FwbnN1cHJucXR6dmx1cHUlN0J2c3NzcnZ2cHElMUZuJTE5c3FwbnN2JTdCd25vcXJwdWxydHd2c3J3JTdCc3d6dnQlMUZuJTE5c3AlN0Juc3V1dW52cnJ1bCU3QnVxcndxenJzdHF2cSUxRm4lMTlzcCU3Qm5zdXV1bnIlMUZuJTE5c3F3bnN1dHpub3NwdWxwdSU3QnBwcnRzcXd1end0JTFGbiUxOXNxcG5zdHpwbm9zc3d1bHJzc3R0enJ2enFxJTdCJTFGbiUxOXNxd25zdXR6bnNwc3RscHBxdHRxdHZyenRzeiUxRm4lMTlzcXpuc3Vwcm5vd3V1bCU3QiU3QnR3cSU3QnV6cHJxcnMlMUZuJTE5JTdCc250cG5vc3dwd3VwbHJxJTdCcHByenBzenYlMUZuJTE5b3F0bnN1cnJucHBwdSU3Qmxwcnp0JTdCcXFyenR3eiUxRm4lMTlvcXpucHJ3cm53dXZybHZwdHpzcXElN0IlN0J6d3clMUZuJTE5b3F6bnBwcHRucXNxcWx3JTdCciU3QnNzcSU3Qnp0c3clMUZuJTE5b3F1bnB0dXduJTdCdHIlN0JscnMlN0J0c3Vycnd0eiUxRm4lMTlvdnFucCU3QnN6bnd0dXBseiU3QnBzcyU3Qnd2d3F1cSUxRm4lMTlvdnducXN6cG50dXBybHF2cHp2enElN0J0JTdCdnUlMUZuJTE5b3Z0bnF0cHduc3B6dnUlMUZuJTE5b3Z6bnF1c3VucHVxd2xxd3R0diU3QndydHRydyUxRm4lMTlvd3JucSU3QnJ3bnd6dXFscXJ1dXd0cHpzenJxJTFGbiUxOW92JTdCbnF6c3Jub3B6JTdCd2x3d3B0cHZwenZxd3B3JTFGbiUxOW93cm5xJTdCcnducCU3QnR1bHolN0J2enV0enZ2d3B6diUxRm4lMTlvdiU3Qm5xdHF2bm91enV1bHR0dXZ6dnVxc3V3JTdCJTFGbiUxOW92em5xcXRxbm91cCU3QnNsenR2cHFxd3NxJTdCd3MlMUZuJTE5b3Z3bnFzenBub3Z0cnVsd3J1dXp0cHNzd3ZxJTFGbiUxOW92cW5wJTdCc3pub3RzdHFsc3Zwcnd3enJwcXpzJTFGbiUxOW92c25wdnpzbm96dHV2bHBycHFwdHZxJTdCcnN2JTFGbiUxOW92d25wc3Bzbm90c3IlN0JsdnJwd3olN0J2d3N1dSUxRm4lMTlvdnBuc3R6cG5vdyU3QnJ0bHN2ciU3Qnd0dHR3cXd6JTFGbiUxOW92cG5zd3J3bm9wc3FzbHF0cHB2cnZ2dHBxdHAlMUZuJTE5b3ZxbnNzcnRub3VydyU3QmxycXJ3JTdCJTdCc3R6dCU3QnolMUZuJTE5b3Z3bnVydW5vdndzdmxzdCU3QnQlN0JzciU3QnYlN0JzJTdCdyUxRm4lMTlvdXducXd0bm92cnJwbHJzd3V2cHIlN0J1JTdCdXYlMUZuJTE5b3Nyd25wcXpub3NxdndsdnJ1cnJzdHN0JTdCenB6JTFGbiUxOW91cW5zcXZub3NyendsdSU3QnN6dXQlN0JwdHQlN0J1cSUxRm4lMTlzd3RucHRub3NxcnZsJTdCdHolN0J0d3N2enBzcXolMUZuJTE5c3YlN0Juc3N0dG5zJTdCJTdCdnNsend3dnpycXVyJTdCcHUlMUZuJTE5c3Z6bnN2diU3Qm5xdHolN0JsenR6d3RzcXZ2dCU3QiU3QnQlMUZuJTE5c3Z1bnBxdXpuc3d2dHNsdHZzdnVzdXMlN0J0c3olMUZuJTE5c3dybnMlN0J1cG5venJydWx3dXN0dHR6dHRxcnYlMUZuJTE5c3YlN0JucXFxcG5xc3VwcmxxdXpxcnUlN0J3enZxdyUxRm4lMTlzdiU3Qm5wd3d3bm9zJTdCend3bHF3cHp3d3J6dHVzcCUxRm4lMTlzd3JudnRxc253dXR6c2x2cHV2dnZzJTdCd3d6dCUxRm4lMTlzdiU3Qm5xdHZ2bm9wenV1d2x1dnV0cnNydHN3d3UlMUZuJTE5c3Z6bnF6c3Rud3B3cmwlN0JxcHNydXVxciU3QnQlN0IlMUZuJTE5c3Z0bnZyd3RudXV6dWwlN0IlN0JydXd3cnJwcHN1JTFGbiUxOXN2cW52cHJybnZ6cXpsdnp3dXNxd3B0diU3QnQlMUZuJTE5c3ZxbnElN0Jwd25venRxd2xzdXdzd3V2dyU3QnN1JTFGbiUxOXN2c252cnJwbnB2dHdscHJwenFzdnNzdHZ1JTFGbiUxOXN2cm5xdXAlN0Jub3pzdnZscXVwJTdCcnZycXRwdyU3QiUxRm4lMTlzcSU3Qm5xdnd1bm91d3BxbHN2enB1dXN3ciU3QiU3QnclMUZuJTE5JTdCc251dW5vcHd0JTdCcnBscHF3enUlN0J1cHNxdyUxRm4lMTlvdHFucHdzdG52JTdCcnpxbCU3QnB6c3V2ciU3QnV6enYlMUZuJTE5b3RxbnB3c3RuciUxRm4lMTlvdyU3Qm5wdHF1bnB3d3BsdiU3QnV1JTdCdHB1dXBydXUlMUZuJTE5b3d0bnB6dXpud3d2emxwcXR0d3R6c3B0enZ3JTFGbiUxOW93cW5wdHV3bm92cXZ2bHF6JTdCdXN3dnpxdHF1JTFGbiUxOW93dm5xc3VwbnNzcnF3bHMlN0JyenZ3dHdxdXF3JTFGbiUxOW93cW5wcXV6bm9zdCU3QiU3QnBscXZwcnElN0J6dXMlN0J0JTFGbiUxOW93d25wdHJzbnZ0dnJscXAlN0J2cnR2c3J1c3ElMUZuJTE5b3d3bnB2cHVub3FxdXpsdnR6enpxJTdCdXR6enB2JTFGbiUxOW93JTdCbnBzenVub3ZzJTdCemxwendxdHZwenp0c3QlMUZuJTE5b3RwbnBzcHdub3Nyd3YlMUZuJTE5b3d6bnMlN0Jyem5vcXFzcGxxdHNwdnBxdXR6cnElMUZuJTE5b3d6bnN0cXJub3F0cHZsdHV0d3F1cCU3QnB0dXElMUZuJTE5b3clN0Juc3Z3em5vcHJyd2x6dnV2d3N6cHR1enF3JTFGbiUxOW93dW5zcnZybm90JTdCd3RsJTdCcnR2JTdCdHZwdiU3QnV2JTFGbiUxOW93dG4lN0Jyc25vcHJydmx0enR3ciU3QnN3dSU3QnV6JTFGbiUxOW93c24lN0J2em50dHVsJTdCJTdCd3dyeiU3QnR0JTdCcSU3QiUxRm4lMTlvdnpudXJ6bm9wenolN0JsJTdCenB0JTdCeiU3QnNyc3dzJTFGbiUxOW92em53dHNub3MlN0J1dWx0enB1cXYlN0JzJTdCenF3diUxRm4lMTlvcXZucHVybm9xc3Z1bHR2dHB0cXZ6cnJ0cHolMUZuJTE5b3BybnF0dG5zc3BxbHR3c3MlN0JzdnAlN0JyenYlMUZuJTE5b3FzbnZ6dG5zcSU3QiU3Qmx2cHp2d3Z1dHB6dXBwJTFGbiUxOW9wdW5wcXFub3B6cHpsdHB3JTdCJTdCc3dxdXBxdnElMUYlMUZucCU3Qm5wJTdCbnZudm5ybnJucm5ybiUyQzcuLm5ybnJucm5ybnNuJTJDNy4ubiUyQzcuLm4lMkM3Li5uJTJDNy4ubnNuJTJDNy4ubiUyQzcuLm4lMTklNjAlMjQtITcxLTc2JTYwbiU2MCUyNC0hNzElMkIlMkMlNjBuJTYwJTJCJTJDMjc2JTYwbiU2MCEqJTIzJTJDJTI1JyU2MG4lNjAlMjQtITcxLTc2JTYwbiU2MCUyNC0hNzElMkIlMkMlNjBuJTYwMTclMjAlMkYlMkI2JTYwJTFGbnNucm5ybnJucm5ybnJucm5ybnJucm5ybnBuc25ybnBuc25ybnNucm53bnduc24lMTklMTlzd3p3dHJzcHMlN0IlN0Jwem5zcm4lMTl6JTdCem56eiUxRiUxRm4lMTl6JTdCdW5zcm4lMTklN0Jwd24lN0J2JTFGJTFGbiUxOXNzcHVuc3JuJTE5dSU3QnVucCU3QnElMUYlMUZuJTE5cHV3c25zcm4lMTklN0JwcW56ciUxRiUxRm4lMTlwJTdCdyU3Qm5zcm4lMTl3JTdCc252c3UlMUYlMUZuJTE5cXdzJTdCbnNybiUxOXclN0JybnZ2diUxRiUxRm4lMTl2dHUlN0Juc3JuJTE5JTdCcHduc3ZyJTFGJTFGbiUxOXZ6enVuc3JuJTE5dXF6bnZwciUxRiUxRm4lMTl3c3Z2bnBzbiUxOXQlN0J1bnZ2c24lNjAlMjA3NjYtJTJDbCUyMDYlMkNsJTIwNiUyQ29vJTIwLi0hKSU2MCUxRiUxRiUxRm56dG4lNjAlMEYtOCUyQi4uJTIzbXdscmJqJTE1JTJCJTJDJTI2LTUxYiUwQyUxNmJzcmxyeWIlMTUlMkIlMkN0dnliJTNBdHZrYiUwMzIyLiclMTUnJTIwJTA5JTJCNm13cXVscXRiaiUwOSUwQSUxNiUwRiUwRW5iLiUyQiknYiUwNSchKS1rYiUwMSowLSUyRidtenJscmxxJTdCenVsc3YlN0JiJTExJTIzJTI0JTIzMCUyQm13cXVscXQlNjBuJTYwKidvJTBCJTBFJTYwbnB2bnpudm5vc3pybnNuc25zbnNucm5ybiU2MCUxNSUyQiUyQ3FwJTYwbjYwNyduJTI0JTIzLjEnbiUyQzcuLm42MDcnbiUyNCUyMy4xJ24lMjQlMjMuMSduJTI0JTIzLjEnbiUxOXJuJTI0JTIzLjEnbiUyNCUyMy4xJyUxRm4lMjQlMjMuMSduJTE5cyU3QnBybnNyenIlMUZuJTE5cyU3QnBybnNydnIlMUZuc24lMTklNjAlMDEqMC0lMkYnYiUxMiUwNiUwNGIlMTIuNyUyNSUyQiUyQ3h4JTEyLTA2JTIzJTIwLidiJTA2LSE3JTJGJyUyQzZiJTA0LTAlMkYlMjM2eHglMjMyMi4lMkIhJTIzNiUyQi0lMkNtJTNBbyUyNS0tJTI1LidvISowLSUyRidvMiUyNiUyNCUzQzIlMjYlMjQlNjBuJTYwJTAxKjAtJTJGJ2IlMTIlMDYlMDRiJTE0JTJCJzUnMHh4eHglMjMyMi4lMkIhJTIzNiUyQi0lMkNtMiUyNiUyNCUzQzIlMjYlMjQlNjBuJTYwJTBDJTIzNiUyQjQnYiUwMS4lMkInJTJDNnh4eHglMjMyMi4lMkIhJTIzNiUyQi0lMkNtJTNBbyUyQyUyMyEuJTNDbiUyMzIyLiUyQiElMjM2JTJCLSUyQ20lM0FvMiUyQyUyMyEuJTNDJTYwJTFGbiUxOSUxRm4lMjQlMjMuMSduJTE5NjA3J24lMjQlMjMuMSclMUYlMUY=";
    }
}
