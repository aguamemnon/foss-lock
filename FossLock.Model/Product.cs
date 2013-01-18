﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FossLock.Model
{

    /// <summary>
    /// Description of Product.
    /// </summary>
    public class Product
    {
        public Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public DateTime ReleaseDate { get; set; }
        public LockProperties DefaultLockProperties { get; set; }
        public string Notes { get; set; }
        public int TrialDays { get; set; }
        public virtual ICollection<ProductFeature> AvailableFeatures { get; set; }
        public virtual ICollection<ProductVersion> Versions { get; set; }

    }
}