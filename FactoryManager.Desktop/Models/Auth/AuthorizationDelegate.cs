using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationDelegate
    {
        public int Id { get; set; }
        public int DelegatorId { get; set; }
        public int DelegateId { get; set; }
        public List<string> DelegatedPermissions { get; set; }
        public List<string> DelegatedRoles { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
