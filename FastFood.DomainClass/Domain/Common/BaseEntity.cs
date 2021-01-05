using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DomainClass.Domain.Common
{
    public interface IEntity
    {
    }

    public abstract class BaseEntity<TKey> : IEntity
    {
        [Key]
        public TKey Id { get; set; }
        //public DateTime? CreateDate { get; set; }
        //public DateTime? UpdateDate { get; set; }
        //public DateTime? DeleteDate { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
