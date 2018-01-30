using SimpleApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleApp.Models
{
    public class BaseModel : ObservableObjects
    {
        public BaseModel()
        {
            CreatedAt = DateTimeOffset.Now;
        }

        /// <summary>
        /// Id for item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Created at time stamp
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// UpdateAt timestamp
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }

    }
}
