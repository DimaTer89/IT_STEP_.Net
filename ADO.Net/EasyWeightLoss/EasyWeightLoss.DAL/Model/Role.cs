﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeightLoss.DAL.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string NameRole { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
