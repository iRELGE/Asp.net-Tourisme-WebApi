using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourisme.Models
{
    public class PostTraitemenrInfo
    {
        public int nombrePosts { get; set; }
        public int nombreActivites { get; set; }
        public List<PostsUserApiModel> posts { get; set; }
    }
}