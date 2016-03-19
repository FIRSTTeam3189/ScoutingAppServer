using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Azure.Mobile.Server;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScoutingServer.SQLDataObjects {
    public class AccountSecurity : EntityData {

        public byte[] Salt { get; set; }
        public byte[] SaltedAndHashedPassword { get; set; }

    }
}