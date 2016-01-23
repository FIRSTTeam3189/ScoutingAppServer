using System.Collections.Generic;
using FlipitServer.ClientData;
using Microsoft.Azure.Mobile.Server;
using flipyserverService.SQLDataObjects;

namespace FlipitServer.SQLDataObjects {
    public class Account : EntityData {

        public Account(string Id) : base() {
            this.Id = Id;
            Role = new Role(Id, Role.ROLE_LEVEL_DEV);
        }

        public ClientAccount GetClientAccount() {
            return new ClientAccount {
                Email = Email,
                Username = Username,
                TeamNumber = TeamNumber
            };
        }
        
        public string Username { get; set; }
        public string Email { get; set; }
        public string TeamNumber { get; set; }
        public Role Role { get; set; }

        public static bool operator ==(Account a, Account b) {
            return a.Id == b.Id;
        }

        public static bool operator !=(Account a, Account b) {
            return a.Id != b.Id;
        }

        public override bool Equals(object obj) {
            if(obj is Account)
                return (obj as Account).Id == Id;
            return false;
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }
    }
}