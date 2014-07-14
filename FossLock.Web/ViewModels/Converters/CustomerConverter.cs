﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FossLock.Model;
using FossLock.Model.Component;

namespace FossLock.Web.ViewModels.Converters
{
    /// <summary>
    ///     Provides methods for convertering between our Customer domain model
    ///     objects, and their corresponding ViewModels.
    /// </summary>
    public class CustomerConverter : IEntityConverter<Customer, CustomerViewModel>
    {
        public Customer ViewmodelToEntity(CustomerViewModel vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");

            Customer entity = new Customer();

            return ViewmodelToEntity(vm, entity);
        }

        public Customer ViewmodelToEntity(CustomerViewModel vm, Customer entity)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            else if (entity == null)
                throw new ArgumentNullException("entity");

            entity.Id = vm.Id;
            entity.Name = vm.Name;
            entity.CanLicensePreReleaseVersions = vm.CanLicensePreReleaseVersions;

            entity.StreetAddress = vm.StreetAddress;
            if (vm.BillingMatchesStreetAddress)
            {
                entity.BillingAddress = new Address
                {
                    Address1 = vm.StreetAddress.Address1,
                    Address2 = vm.StreetAddress.Address2,
                    City = vm.StreetAddress.City,
                    State = vm.StreetAddress.State,
                    PostalCode = vm.StreetAddress.PostalCode,
                    Country = vm.StreetAddress.Country,
                };
            }
            else
            {
                entity.BillingAddress = vm.BillingAddress;
            }

            entity.OfficePhone1 = vm.OfficePhone1;
            entity.OfficePhone2 = vm.OfficePhone2;
            entity.OfficeFax = vm.OfficeFax;
            entity.Email = vm.Email;
            entity.Notes = vm.Notes;
            entity.PrimaryContact = vm.PrimaryContact;

            return entity;
        }

        public CustomerViewModel EntityToViewmodel(Customer entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var vm = new CustomerViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                CanLicensePreReleaseVersions = entity.CanLicensePreReleaseVersions,
                StreetAddress = entity.StreetAddress,
                BillingAddress = entity.BillingAddress,
                OfficePhone1 = entity.OfficePhone1,
                OfficePhone2 = entity.OfficePhone2,
                OfficeFax = entity.OfficeFax,
                Email = entity.Email,
                Notes = entity.Notes,
                PrimaryContact = entity.PrimaryContact
            };

            vm.BillingMatchesStreetAddress = vm.BillingAddress.Equals(vm.StreetAddress);

            return vm;
        }
    }
}