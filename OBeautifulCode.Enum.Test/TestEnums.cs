// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEnums.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace OBeautifulCode.Enum.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "this is for testing purposes.")]
    public enum Empty
    {
    }

    [Flags]
    [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "this is for testing purposes.")]
    public enum EmptyFlags
    {
    }

    public enum GoodStuff
    {
        WorkingFromHome,

        Chocolate,

        Vacation,

        Bulldogs,

        Sunflowers,
    }

    [Flags]
    public enum TravelOptions
    {
        None = 0,

        Speedboat = 1,

        Train = 2,

        PropellerPlane = 4,

        RentalCar = 8,

        Bus = 16,

        Taxi = 32,

        CommercialPlane = 64,

        Air = PropellerPlane | CommercialPlane,

        Wheeled = RentalCar | Bus | Taxi,

        MassTransit = Train | Bus,
    }

#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}

// ReSharper restore CheckNamespace