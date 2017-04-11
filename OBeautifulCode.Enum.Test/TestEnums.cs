﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEnums.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace OBeautifulCode.Enum.Test
{
    using System;

#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "this is for testing purposes.")]
    public enum Empty
    {
    }

    [Flags]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "this is for testing purposes.")]
    public enum EmptyFlags
    {
    }

    public enum GoodStuff
    {
        WorkingFromHome,

        Chocolate,

        Vacation,

        Bulldogs
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

        MassTransit = Train | Bus
    }

#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}

// ReSharper restore CheckNamespace