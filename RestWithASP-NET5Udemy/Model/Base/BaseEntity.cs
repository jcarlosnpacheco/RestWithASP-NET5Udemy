﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET5Udemy.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
