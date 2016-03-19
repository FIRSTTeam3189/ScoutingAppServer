using ScoutingServer.ClientData;
using ScoutingServer.SQLDataObjects;

namespace FlipitServer.ClientData {
    public class LoginInfo {
        public string UserId { get; set; }
        public string MobileServiceAuthenticationToken { get; set; }
        public ClientAccount AccountInfo { get; set; }
    }
}
