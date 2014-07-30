﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FossLock.Model;
using Summerset.SemanticVersion;

namespace FossLock.Web.ViewModels.Converters
{
    public class ProductVersionConverter : IEntityConverter<ProductVersion, ProductVersionViewModel>
    {
        public ProductVersionViewModel EntityToViewmodel(ProductVersion entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (entity.Product == null)
            {
                throw new ArgumentException("ProductVersion.Product cannot be null", "entity");
            }

            var version = Version.Parse(entity.Version);

            var vm = new ProductVersionViewModel
            {
                Id = entity.Id,
                ProductId = entity.Product.Id,
                Major = version.Major.ToString(),
                Minor = version.Minor.ToString(),
                Patch = version.Revision.ToString(),
                Build = version.Build.ToString(),
            };

            return vm;
        }

        public void ViewmodelToEntity(ProductVersionViewModel vm, ref ProductVersion entity)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            else if (entity == null)
                throw new ArgumentNullException("entity");

            throw new NotImplementedException();
        }
    }
}