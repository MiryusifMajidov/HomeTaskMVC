﻿namespace KlinicProject.Model.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
