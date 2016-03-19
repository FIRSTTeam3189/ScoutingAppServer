using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoutingServer.SQLDataObjects {
    public class Role : EntityData {
        public const int ROLE_LEVEL_USER = 0;
        public const int ROLE_LEVEL_MOD = 1;
        public const int ROLE_LEVEL_ADMIN = 2;
        public const int ROLE_LEVEL_DEV = 3;

        public int AuthLevel { get; set; }

        public Role(string Id, int level) {
            this.Id = Id;
            AuthLevel = level;
        }

        public bool IsModLevel() {
            return AuthLevel >= ROLE_LEVEL_MOD;
        }

        public bool IsAdminLevel() {
            return AuthLevel >= ROLE_LEVEL_ADMIN;
        }

        public bool IsDevLevel() {
            return AuthLevel >= ROLE_LEVEL_DEV;
        }
    }
}