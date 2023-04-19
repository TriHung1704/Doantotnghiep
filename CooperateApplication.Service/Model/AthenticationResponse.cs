using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Model
{
    public class AthenticationResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public AthenticationResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
