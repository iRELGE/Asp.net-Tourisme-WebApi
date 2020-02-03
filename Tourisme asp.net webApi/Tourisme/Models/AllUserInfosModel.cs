using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class AllUserInfosModel
    {

        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IsDeleted { get; set; }
    }
}