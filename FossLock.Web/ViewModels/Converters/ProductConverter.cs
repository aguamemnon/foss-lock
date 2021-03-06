﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FossLock.Core;
using FossLock.Model;

namespace FossLock.Web.ViewModels.Converters
{
    public class ProductConverter : IEntityConverter<Product, ProductViewModel>
    {
        public ProductViewModel EntityToViewmodel(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var vm = new ProductViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ReleaseDate = entity.ReleaseDate,
                FailOnNullHardwareIdentifier = entity.FailOnNullHardwareIdentifier,
                Notes = entity.Notes,
                LicenseEncryptionType = entity.LicenseEncryptionType,
                PrivateKey = entity.PrivateKey,
                PublicKey = entity.PublicKey,
                VersionLeeway = ((int)entity.VersionLeeway).ToString(),
                PermittedActivationTypes = new List<string>(),
                SelectedDefaultLockProperties = new List<string>(),
                Versions = entity.Versions,
                Features = entity.Features
            };

            var allActivationTypes = Enum.GetValues(typeof(ActivationMethodType));
            foreach (ActivationMethodType activationType in allActivationTypes)
            {
                // skip this, we don't want to display it.
                if (activationType == ActivationMethodType.None)
                    continue;

                // figure out which activation types have already been selected.
                if (entity.PermittedActivationTypes.HasFlag(activationType))
                {
                    vm.PermittedActivationTypes.Add(((int)activationType).ToString());
                }
            }

            var allLockProperties = Enum.GetValues(typeof(LockPropertyType));
            foreach (LockPropertyType lockType in allLockProperties)
            {
                // skip this, we don't want to display it.
                if (lockType == LockPropertyType.None)
                    continue;

                if (entity.DefaultLockProperties.HasFlag(lockType))
                {
                    vm.SelectedDefaultLockProperties.Add(((int)lockType).ToString());
                }
            }

            return vm;
        }

        public void ViewmodelToEntity(ProductViewModel vm, ref Product entity)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            if (entity == null)
                throw new ArgumentNullException("entity");

            // TODO: make sure priv + pub keys have been previously-set.

            entity.Id = vm.Id;
            entity.Name = vm.Name;
            entity.ReleaseDate = vm.ReleaseDate;
            entity.FailOnNullHardwareIdentifier = vm.FailOnNullHardwareIdentifier;
            entity.LicenseEncryptionType = vm.LicenseEncryptionType;
            entity.PublicKey = vm.PublicKey;
            entity.PrivateKey = vm.PrivateKey;
            entity.Notes = vm.Notes;
            entity.VersionLeeway = (VersionLeewayType)Enum.Parse(typeof(VersionLeewayType), vm.VersionLeeway);

            entity.PermittedActivationTypes = ActivationMethodType.None;
            foreach (var activationType in vm.PermittedActivationTypes)
            {
                entity.PermittedActivationTypes |= (ActivationMethodType)Enum.Parse(typeof(ActivationMethodType), activationType);
            }

            entity.DefaultLockProperties = LockPropertyType.None;
            foreach (var lockProperty in vm.SelectedDefaultLockProperties)
            {
                entity.DefaultLockProperties |= (LockPropertyType)Enum.Parse(typeof(LockPropertyType), lockProperty);
            }

            // we skip both versions and features.  Those are handled by independent controllers.
        }
    }
}