import { Injectable } from "@angular/core"

@Injectable({
    providedIn: 'root'
})
export class SettingClaims {
    public module = 'Settings'
    settings: Permissions = {
        view: 'Settings.Settings.View',
        update: 'Settings.Settings.Update',
    }
    companies: Permissions = {
        view: 'Settings.Companies.View',
        viewDetails: 'Settings.Companies.ViewDetails',
        create: 'Settings.Companies.Create',
        update: 'Settings.Companies.Update',
        print: 'Settings.Companies.Print',
        delete: 'Settings.Companies.Delete',
        activate: 'Settings.Companies.Activate',
        deactivate: 'Settings.Companies.Deactivate',
        export: 'Settings.Companies.Export',
        import: 'Settings.Companies.Import',
    }
    branches: Permissions = {
        view: 'Settings.Branches.View',
        viewDetails: 'Settings.Branches.ViewDetails',
        create: 'Settings.Branches.Create',
        update: 'Settings.Branches.Update',
        print: 'Settings.Branches.Print',
        delete: 'Settings.Branches.Delete',
        activate: 'Settings.Branches.Activate',
        deactivate: 'Settings.Branches.Deactivate',
        export: 'Settings.Branches.Export',
        import: 'Settings.Branches.Import',
    }
    accessRights: Permissions = {
        view: 'Settings.AccessRights.View',
        viewDetails: 'Settings.AccessRights.ViewDetails',
        create: 'Settings.AccessRights.Create',
        update: 'Settings.AccessRights.Update',
        print: 'Settings.AccessRights.Print',
        delete: 'Settings.AccessRights.Delete',
        activate: 'Settings.AccessRights.Activate',
        deactivate: 'Settings.AccessRights.Deactivate',
        export: 'Settings.AccessRights.Export',
        import: 'Settings.AccessRights.Import',
    }
    roles: Permissions = {
        view: 'Settings.Roles.View',
        viewDetails: 'Settings.Roles.ViewDetails',
        create: 'Settings.Roles.Create',
        update: 'Settings.Roles.Update',
        print: 'Settings.Roles.Print',
        delete: 'Settings.Roles.Delete',
        activate: 'Settings.Roles.Activate',
        deactivate: 'Settings.Roles.Deactivate',
        export: 'Settings.Roles.Export',
        import: 'Settings.Roles.Import',
    }
    users: Permissions = {
        view: 'Settings.Users.View',
        viewDetails: 'Settings.Users.ViewDetails',
        create: 'Settings.Users.Create',
        update: 'Settings.Users.Update',
        print: 'Settings.Users.Print',
        delete: 'Settings.Users.Delete',
        activate: 'Settings.Users.Activate',
        deactivate: 'Settings.Users.Deactivate',
        export: 'Settings.Users.Export',
        import: 'Settings.Users.Import',
    }
    userRoles: Permissions = {
        view: 'Settings.UserRoles.View',
        viewDetails: 'Settings.UserRoles.ViewDetails',
        create: 'Settings.UserRoles.Create',
        update: 'Settings.UserRoles.Update',
        print: 'Settings.UserRoles.Print',
        delete: 'Settings.UserRoles.Delete',
        activate: 'Settings.UserRoles.Activate',
        deactivate: 'Settings.UserRoles.Deactivate',
        export: 'Settings.UserRoles.Export',
        import: 'Settings.UserRoles.Import',
    }
    countries: Permissions = {
        view: 'Settings.Countries.View',
        viewDetails: 'Settings.Countries.ViewDetails',
        create: 'Settings.Countries.Create',
        update: 'Settings.Countries.Update',
        print: 'Settings.Countries.Print',
        delete: 'Settings.Countries.Delete',
        activate: 'Settings.Countries.Activate',
        deactivate: 'Settings.Countries.Deactivate',
        export: 'Settings.Countries.Export',
        import: 'Settings.Countries.Import',
    }
    cities: Permissions = {
        view: 'Settings.Cities.View',
        viewDetails: 'Settings.Cities.ViewDetails',
        create: 'Settings.Cities.Create',
        update: 'Settings.Cities.Update',
        print: 'Settings.Cities.Print',
        delete: 'Settings.Cities.Delete',
        activate: 'Settings.Cities.Activate',
        deactivate: 'Settings.Cities.Deactivate',
        export: 'Settings.Cities.Export',
        import: 'Settings.Cities.Import',
    }
    nationalities: Permissions = {
        view: 'Settings.Nationalities.View',
        viewDetails: 'Settings.Nationalities.ViewDetails',
        create: 'Settings.Nationalities.Create',
        update: 'Settings.Nationalities.Update',
        print: 'Settings.Nationalities.Print',
        delete: 'Settings.Nationalities.Delete',
        activate: 'Settings.Nationalities.Activate',
        deactivate: 'Settings.Nationalities.Deactivate',
        export: 'Settings.Nationalities.Export',
        import: 'Settings.Nationalities.Import',
    }
    paymentTerms: Permissions = {
        view: 'Settings.PaymentTerms.View',
        viewDetails: 'Settings.PaymentTerms.ViewDetails',
        create: 'Settings.PaymentTerms.Create',
        update: 'Settings.PaymentTerms.Update',
        print: 'Settings.PaymentTerms.Print',
        delete: 'Settings.PaymentTerms.Delete',
        activate: 'Settings.PaymentTerms.Activate',
        deactivate: 'Settings.PaymentTerms.Deactivate',
        export: 'Settings.PaymentTerms.Export',
        import: 'Settings.PaymentTerms.Import',
    }
    contactTypes: Permissions = {
        view: 'Settings.ContactTypes.View',
        viewDetails: 'Settings.ContactTypes.ViewDetails',
        create: 'Settings.ContactTypes.Create',
        update: 'Settings.ContactTypes.Update',
        print: 'Settings.ContactTypes.Print',
        delete: 'Settings.ContactTypes.Delete',
        activate: 'Settings.ContactTypes.Activate',
        deactivate: 'Settings.ContactTypes.Deactivate',
        export: 'Settings.ContactTypes.Export',
        import: 'Settings.ContactTypes.Import',
    }
    documentTypes: Permissions = {
        view: 'Settings.DocumentTypes.View',
        viewDetails: 'Settings.DocumentTypes.ViewDetails',
        create: 'Settings.DocumentTypes.Create',
        update: 'Settings.DocumentTypes.Update',
        print: 'Settings.DocumentTypes.Print',
        delete: 'Settings.DocumentTypes.Delete',
        activate: 'Settings.DocumentTypes.Activate',
        deactivate: 'Settings.DocumentTypes.Deactivate',
        export: 'Settings.DocumentTypes.Export',
        import: 'Settings.DocumentTypes.Import',
    }
}

@Injectable({
    providedIn: 'root'
})
export class VehicleRentalClaims {
    public module = 'VehicleRental'
    dashboard: Permissions = {
        view: 'VehicleRental.Dashboard.View'
    }
    vehicles: Permissions = {
        view: 'VehicleRental.Vehicles.View',
        viewDetails: 'VehicleRental.Vehicles.ViewDetails',
        create: 'VehicleRental.Vehicles.Create',
        update: 'VehicleRental.Vehicles.Update',
        print: 'VehicleRental.Vehicles.Print',
        delete: 'VehicleRental.Vehicles.Delete',
        activate: 'VehicleRental.Vehicles.Activate',
        deactivate: 'VehicleRental.Vehicles.Deactivate',
        export: 'VehicleRental.Vehicles.Export',
        import: 'VehicleRental.Vehicles.Import',
    }
    tenants: Permissions = {
        view: 'VehicleRental.Tenants.View',
        viewDetails: 'VehicleRental.Tenants.ViewDetails',
        create: 'VehicleRental.Tenants.Create',
        update: 'VehicleRental.Tenants.Update',
        print: 'VehicleRental.Tenants.Print',
        delete: 'VehicleRental.Tenants.Delete',
        activate: 'VehicleRental.Tenants.Activate',
        deactivate: 'VehicleRental.Tenants.Deactivate',
        export: 'VehicleRental.Tenants.Export',
        import: 'VehicleRental.Tenants.Import',
    }
    drivers: Permissions = {
        view: 'VehicleRental.Drivers.View',
        viewDetails: 'VehicleRental.Drivers.ViewDetails',
        create: 'VehicleRental.Drivers.Create',
        update: 'VehicleRental.Drivers.Update',
        print: 'VehicleRental.Drivers.Print',
        delete: 'VehicleRental.Drivers.Delete',
        activate: 'VehicleRental.Drivers.Activate',
        deactivate: 'VehicleRental.Drivers.Deactivate',
        export: 'VehicleRental.Drivers.Export',
        import: 'VehicleRental.Drivers.Import',
    }
    vehicleGroups: Permissions = {
        view: 'VehicleRental.VehicleGroups.View',
        viewDetails: 'VehicleRental.VehicleGroups.ViewDetails',
        create: 'VehicleRental.VehicleGroups.Create',
        update: 'VehicleRental.VehicleGroups.Update',
        print: 'VehicleRental.VehicleGroups.Print',
        delete: 'VehicleRental.VehicleGroups.Delete',
        activate: 'VehicleRental.VehicleGroups.Activate',
        deactivate: 'VehicleRental.VehicleGroups.Deactivate',
        export: 'VehicleRental.VehicleGroups.Export',
        import: 'VehicleRental.VehicleGroups.Import',
    }
    vehicleShapes: Permissions = {
        view: 'VehicleRental.VehicleShapes.View',
        viewDetails: 'VehicleRental.VehicleShapes.ViewDetails',
        create: 'VehicleRental.VehicleShapes.Create',
        update: 'VehicleRental.VehicleShapes.Update',
        print: 'VehicleRental.VehicleShapes.Print',
        delete: 'VehicleRental.VehicleShapes.Delete',
        activate: 'VehicleRental.VehicleShapes.Activate',
        deactivate: 'VehicleRental.VehicleShapes.Deactivate',
        export: 'VehicleRental.VehicleShapes.Export',
        import: 'VehicleRental.VehicleShapes.Import',
    }
    vehicleColors: Permissions = {
        view: 'VehicleRental.VehicleColors.View',
        viewDetails: 'VehicleRental.VehicleColors.ViewDetails',
        create: 'VehicleRental.VehicleColors.Create',
        update: 'VehicleRental.VehicleColors.Update',
        print: 'VehicleRental.VehicleColors.Print',
        delete: 'VehicleRental.VehicleColors.Delete',
        activate: 'VehicleRental.VehicleColors.Activate',
        deactivate: 'VehicleRental.VehicleColors.Deactivate',
        export: 'VehicleRental.VehicleColors.Export',
        import: 'VehicleRental.VehicleColors.Import',
    }
    vehicleReceivingStatus: Permissions = {
        view: 'VehicleRental.VehicleReceivingStatus.View',
        viewDetails: 'VehicleRental.VehicleReceivingStatus.ViewDetails',
        create: 'VehicleRental.VehicleReceivingStatus.Create',
        update: 'VehicleRental.VehicleReceivingStatus.Update',
        print: 'VehicleRental.VehicleReceivingStatus.Print',
        delete: 'VehicleRental.VehicleReceivingStatus.Delete',
        activate: 'VehicleRental.VehicleReceivingStatus.Activate',
        deactivate: 'VehicleRental.VehicleReceivingStatus.Deactivate',
        export: 'VehicleRental.VehicleReceivingStatus.Export',
        import: 'VehicleRental.VehicleReceivingStatus.Import',
    }
    followUpTypes: Permissions = {
        view: 'VehicleRental.FollowUpTypes.View',
        viewDetails: 'VehicleRental.FollowUpTypes.ViewDetails',
        create: 'VehicleRental.FollowUpTypes.Create',
        update: 'VehicleRental.FollowUpTypes.Update',
        print: 'VehicleRental.FollowUpTypes.Print',
        delete: 'VehicleRental.FollowUpTypes.Delete',
        activate: 'VehicleRental.FollowUpTypes.Activate',
        deactivate: 'VehicleRental.FollowUpTypes.Deactivate',
        export: 'VehicleRental.FollowUpTypes.Export',
        import: 'VehicleRental.FollowUpTypes.Import',
    }
    trafficViolationTypes: Permissions = {
        view: 'VehicleRental.TrafficViolationTypes.View',
        viewDetails: 'VehicleRental.TrafficViolationTypes.ViewDetails',
        create: 'VehicleRental.TrafficViolationTypes.Create',
        update: 'VehicleRental.TrafficViolationTypes.Update',
        print: 'VehicleRental.TrafficViolationTypes.Print',
        delete: 'VehicleRental.TrafficViolationTypes.Delete',
        activate: 'VehicleRental.TrafficViolationTypes.Activate',
        deactivate: 'VehicleRental.TrafficViolationTypes.Deactivate',
        export: 'VehicleRental.TrafficViolationTypes.Export',
        import: 'VehicleRental.TrafficViolationTypes.Import',
    }
    tenantRanking: Permissions = {
        view: 'VehicleRental.TenantRanking.View',
        viewDetails: 'VehicleRental.TenantRanking.ViewDetails',
        create: 'VehicleRental.TenantRanking.Create',
        update: 'VehicleRental.TenantRanking.Update',
        print: 'VehicleRental.TenantRanking.Print',
        delete: 'VehicleRental.TenantRanking.Delete',
        activate: 'VehicleRental.TenantRanking.Activate',
        deactivate: 'VehicleRental.TenantRanking.Deactivate',
        export: 'VehicleRental.TenantRanking.Export',
        import: 'VehicleRental.TenantRanking.Import',
    }
    contracts: Permissions = {
        view: ''
    }
    rentInvoices: Permissions = {
        view: ''
    }
    rentPurchases: Permissions = {
        view: ''
    }
    followUps: Permissions = {
        view: ''
    }
    exitance: Permissions = {
        view: ''
    }
    trafficViolations: Permissions = {
        view: ''
    }
    issues: Permissions = {
        view: ''
    }
    thirdPartyInsurance: Permissions = {
        view: ''
    }
    fullInsurance: Permissions = {
        view: ''
    }
    warranty: Permissions = {
        view: ''
    }
    periodicMaintenance: Permissions = {
        view: ''
    }
    structureDiagram: Permissions = {
        view: ''
    }
}

export class Permissions {
    public view?: string;
    public viewDetails?: string;
    public create?: string;
    public update?: string;
    public print?: string;
    public delete?: string;
    public undelete?: string;
    public activate?: string;
    public deactivate?: string;
    public confirm?: string;
    public unconfirm?: string;
    public export?: string;
    public import?: string;
    public changePassword?: string;
}
