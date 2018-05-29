// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensionsTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Enum.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using FluentAssertions;

    using OBeautifulCode.Enum.Recipes;

    using Xunit;

    public static class EnumExtensionsTest
    {
        // ReSharper disable InconsistentNaming
        [Fact]
        public static void GetEnumValues_TEnum___Should_throw_ArgumentException___When_generic_type_parameter_is_not_of_type_Enum()
        {
            // Arrange, Act
            var ex1 = Record.Exception(() => EnumExtensions.GetEnumValues<int>());
            var ex2 = Record.Exception(() => EnumExtensions.GetEnumValues<bool>());
            var ex3 = Record.Exception(() => EnumExtensions.GetEnumValues<byte>());
            var ex4 = Record.Exception(() => EnumExtensions.GetEnumValues<char>());

            // Assert
            ex1.Should().BeOfType<ArgumentException>();
            ex2.Should().BeOfType<ArgumentException>();
            ex3.Should().BeOfType<ArgumentException>();
            ex4.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetEnumValues_TEnum___Should_return_enum_values_in_order___When_called()
        {
            // Arrange, Act
            var enumValues1 = EnumExtensions.GetEnumValues<Empty>();
            var enumValues2 = EnumExtensions.GetEnumValues<GoodStuff>();
            var enumValues3 = EnumExtensions.GetEnumValues<TravelOptions>();

            // Assert
            enumValues1.Should().BeEmpty();
            enumValues2.Should().Equal(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers);
            enumValues3.Should().Equal(TravelOptions.None, TravelOptions.Speedboat, TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.MassTransit, TravelOptions.Taxi, TravelOptions.Wheeled, TravelOptions.CommercialPlane, TravelOptions.Air);
        }

        [Fact]
        public static void GetEnumValues_Type___Should_throw_ArgumentNullException___When_parameter_enumType_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => EnumExtensions.GetEnumValues(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
            ex.Message.Should().Contain("enumType");
        }

        [Fact]
        public static void GetEnumValues_Type___Should_throw_ArgumentException___When_parameter_enumType_is_not_of_type_Enum()
        {
            // Arrange, Act
            var ex1 = Record.Exception(() => typeof(int).GetEnumValues());
            var ex2 = Record.Exception(() => typeof(bool).GetEnumValues());
            var ex3 = Record.Exception(() => typeof(byte).GetEnumValues());
            var ex4 = Record.Exception(() => typeof(char).GetEnumValues());

            // Assert
            ex1.Should().BeOfType<ArgumentException>();
            ex2.Should().BeOfType<ArgumentException>();
            ex3.Should().BeOfType<ArgumentException>();
            ex4.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetEnumValues_Type___Should_return_enum_values_in_order___When_called()
        {
            // Arrange, Act
            var enumValues1 = typeof(Empty).GetEnumValues();
            var enumValues2 = typeof(GoodStuff).GetEnumValues();
            var enumValues3 = typeof(TravelOptions).GetEnumValues();

            // Assert
            enumValues1.Should().BeEmpty();
            enumValues2.Should().Equal(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers);
            enumValues3.Should().Equal(TravelOptions.None, TravelOptions.Speedboat, TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.MassTransit, TravelOptions.Taxi, TravelOptions.Wheeled, TravelOptions.CommercialPlane, TravelOptions.Air);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_TEnum___Should_throw_ArgumentException___When_generic_type_parameter_is_not_of_type_Enum()
        {
            // Arrange, Act
            var ex1 = Record.Exception(() => EnumExtensions.IsFlagsEnum<int>());
            var ex2 = Record.Exception(() => EnumExtensions.IsFlagsEnum<bool>());
            var ex3 = Record.Exception(() => EnumExtensions.IsFlagsEnum<byte>());
            var ex4 = Record.Exception(() => EnumExtensions.IsFlagsEnum<char>());

            // Assert
            ex1.Should().BeOfType<ArgumentException>();
            ex2.Should().BeOfType<ArgumentException>();
            ex3.Should().BeOfType<ArgumentException>();
            ex4.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_TEnum___Should_return_false___When_generic_type_parameter_is_not_a_flags_enum()
        {
            // Arrange, Act
            var actual1 = EnumExtensions.IsFlagsEnum<Empty>();
            var actual2 = EnumExtensions.IsFlagsEnum<GoodStuff>();

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_TEnum___Should_return_true___When_generic_type_parameter_is_a_flags_enum()
        {
            // Arrange, Act
            var actual1 = EnumExtensions.IsFlagsEnum<EmptyFlags>();
            var actual2 = EnumExtensions.IsFlagsEnum<TravelOptions>();

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_Type___Should_throw_ArgumentNullException___When_parameter_enumType_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => EnumExtensions.IsFlagsEnum(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
            ex.Message.Should().Contain("enumType");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_Type___Should_throw_ArgumentException___When_parameter_enumType_is_not_of_type_Enum()
        {
            // Arrange, Act
            var ex1 = Record.Exception(() => typeof(int).IsFlagsEnum());
            var ex2 = Record.Exception(() => typeof(bool).IsFlagsEnum());
            var ex3 = Record.Exception(() => typeof(byte).IsFlagsEnum());
            var ex4 = Record.Exception(() => typeof(char).IsFlagsEnum());

            // Assert
            ex1.Should().BeOfType<ArgumentException>();
            ex2.Should().BeOfType<ArgumentException>();
            ex3.Should().BeOfType<ArgumentException>();
            ex4.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_Type___Should_return_false___When_parameter_enumType_is_not_a_flags_enum()
        {
            // Arrange, Act
            var actual1 = typeof(Empty).IsFlagsEnum();
            var actual2 = typeof(GoodStuff).IsFlagsEnum();

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_Type___Should_return_true___When_parameter_enumType_is_a_flags_enum()
        {
            // Arrange, Act
            var actual1 = typeof(EmptyFlags).IsFlagsEnum();
            var actual2 = typeof(TravelOptions).IsFlagsEnum();

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible___Should_throw_ArgumentNullException___When_parameter_value_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).GetFlagsCombinedWherePossible());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible___Should_return_enum_value___When_enum_is_not_a_flags_enum()
        {
            // Arrange
            var value1 = GoodStuff.Chocolate;
            var value2 = GoodStuff.WorkingFromHome;

            // Act
            var actual1 = value1.GetFlagsCombinedWherePossible();
            var actual2 = value2.GetFlagsCombinedWherePossible();

            // Assert
            actual1.Should().Equal(GoodStuff.Chocolate);
            actual2.Should().Equal(GoodStuff.WorkingFromHome);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible___Should_return_all_individual_flags___When_no_combined_flags_are_used()
        {
            // Arrange
            var value1 = TravelOptions.None;
            var value2 = TravelOptions.Speedboat | TravelOptions.Bus | TravelOptions.Taxi | TravelOptions.PropellerPlane;

            // Act
            var actual1 = value1.GetFlagsCombinedWherePossible();
            var actual2 = value2.GetFlagsCombinedWherePossible();

            // Assert
            actual1.Should().Equal(TravelOptions.None);
            actual2.Should().Equal(TravelOptions.Speedboat, TravelOptions.PropellerPlane, TravelOptions.Bus, TravelOptions.Taxi);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible___Should_return_all_combined_flags___When_only_combined_flags_are_used_and_they_have_no_overlapping_flags()
        {
            // Arrange
            var value1 = TravelOptions.Wheeled;
            var value2 = TravelOptions.Air | TravelOptions.MassTransit;

            // Act
            var actual1 = value1.GetFlagsCombinedWherePossible();
            var actual2 = value2.GetFlagsCombinedWherePossible();

            // Assert
            actual1.Should().Equal(TravelOptions.Wheeled);
            actual2.Should().Equal(TravelOptions.MassTransit, TravelOptions.Air);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible___Should_return_mix_of_combined_flags_and_individual_flags___When_only_combined_flags_are_used_but_they_have_an_overlapping_flag()
        {
            // Arrange
            var value = TravelOptions.Wheeled | TravelOptions.MassTransit;

            // Act
            var actual = value.GetFlagsCombinedWherePossible();

            // Assert
            actual.Should().Equal(TravelOptions.Train, TravelOptions.Wheeled);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_TEnum___Should_throw_ArgumentNullException___When_parameter_value_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).GetFlagsCombinedWherePossible<TravelOptions>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_TEnum___Should_throw_ArgumentException___When_TEnum_is_not_an_enum()
        {
            // Arrange
            var value = TravelOptions.PropellerPlane;

            // Act
            var ex = Record.Exception(() => value.GetFlagsCombinedWherePossible<int>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
            ex.Message.Should().Contain("typeof TEnum is not an Enum");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_TEnum___Should_return_enum_value___When_enum_is_not_a_flags_enum()
        {
            // Arrange
            var value1 = GoodStuff.Chocolate;
            var value2 = GoodStuff.WorkingFromHome;

            // Act
            var actual1 = value1.GetFlagsCombinedWherePossible<GoodStuff>();
            var actual2 = value2.GetFlagsCombinedWherePossible<GoodStuff>();

            // Assert
            actual1.Should().Equal(GoodStuff.Chocolate);
            actual2.Should().Equal(GoodStuff.WorkingFromHome);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_TEnum___Should_return_all_individual_flags___When_no_combined_flags_are_used()
        {
            // Arrange
            var value1 = TravelOptions.None;
            var value2 = TravelOptions.Speedboat | TravelOptions.Bus | TravelOptions.Taxi | TravelOptions.PropellerPlane;

            // Act
            var actual1 = value1.GetFlagsCombinedWherePossible<TravelOptions>();
            var actual2 = value2.GetFlagsCombinedWherePossible<TravelOptions>();

            // Assert
            actual1.Should().Equal(TravelOptions.None);
            actual2.Should().Equal(TravelOptions.Speedboat, TravelOptions.PropellerPlane, TravelOptions.Bus, TravelOptions.Taxi);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_TEnum___Should_return_all_combined_flags___When_only_combined_flags_are_used_and_they_have_no_overlapping_flags()
        {
            // Arrange
            var value1 = TravelOptions.Wheeled;
            var value2 = TravelOptions.Air | TravelOptions.MassTransit;

            // Act
            var actual1 = value1.GetFlagsCombinedWherePossible<TravelOptions>();
            var actual2 = value2.GetFlagsCombinedWherePossible<TravelOptions>();

            // Assert
            actual1.Should().Equal(TravelOptions.Wheeled);
            actual2.Should().Equal(TravelOptions.MassTransit, TravelOptions.Air);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_TEnum___Should_return_mix_of_combined_flags_and_individual_flags___When_only_combined_flags_are_used_but_they_have_an_overlapping_flag()
        {
            // Arrange
            var value = TravelOptions.Wheeled | TravelOptions.MassTransit;

            // Act
            var actual = value.GetFlagsCombinedWherePossible<TravelOptions>();

            // Assert
            actual.Should().Equal(TravelOptions.Train, TravelOptions.Wheeled);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void HasFlagOverlap___Should_return_true___With_overlap()
        {
            // Arrange
            var first = TravelOptions.Air | TravelOptions.Bus;
            var second = TravelOptions.Air | TravelOptions.CommercialPlane;

            // Act
            var actual = first.HasFlagOverlap(second);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void HasFlagOverlap___Should_return_false___Without_overlap()
        {
            // Arrange
            var first = TravelOptions.RentalCar | TravelOptions.Bus;
            var second = TravelOptions.PropellerPlane | TravelOptions.CommercialPlane;

            // Act
            var actual = first.HasFlagOverlap(second);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags___Should_throw_ArgumentNullException___When_parameter_value_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).GetIndividualFlags());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags___Should_return_enum_value___When_enum_is_not_a_flags_enum()
        {
            // Arrange
            var value1 = GoodStuff.Bulldogs;
            var value2 = GoodStuff.WorkingFromHome;

            // Act
            var actual1 = value1.GetIndividualFlags();
            var actual2 = value2.GetIndividualFlags();

            // Assert
            actual1.Should().Equal(GoodStuff.Bulldogs);
            actual2.Should().Equal(GoodStuff.WorkingFromHome);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags___Should_return_all_individual_flags___When_no_combined_flags_are_used()
        {
            // Arrange
            var value1 = TravelOptions.None;
            var value2 = TravelOptions.Speedboat | TravelOptions.Bus | TravelOptions.Taxi | TravelOptions.PropellerPlane;

            // Act
            var actual1 = value1.GetIndividualFlags();
            var actual2 = value2.GetIndividualFlags();

            // Assert
            actual1.Should().Equal(TravelOptions.None);
            actual2.Should().Equal(TravelOptions.Speedboat, TravelOptions.PropellerPlane, TravelOptions.Bus, TravelOptions.Taxi);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags___Should_return_all_individual_flags___When_only_combined_flags_are_used_and_they_have_no_overlapping_flags()
        {
            // Arrange
            var value1 = TravelOptions.Wheeled;
            var value2 = TravelOptions.Air | TravelOptions.MassTransit;

            // Act
            var actual1 = value1.GetIndividualFlags();
            var actual2 = value2.GetIndividualFlags();

            // Assert
            actual1.Should().Equal(TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.Taxi);
            actual2.Should().Equal(TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.Bus, TravelOptions.CommercialPlane);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags___Should_return_mix_of_combined_flags_and_individual_flags___When_only_combined_flags_are_used_but_they_have_an_overlapping_flag()
        {
            // Arrange
            var value = TravelOptions.Wheeled | TravelOptions.MassTransit;

            // Act
            var actual = value.GetIndividualFlags();

            // Assert
            actual.Should().Equal(TravelOptions.Train, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.Taxi);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_throw_ArgumentNullException___When_parameter_value_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).GetIndividualFlags<TravelOptions>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_throw_ArgumentException___When_TEnum_is_not_an_enum()
        {
            // Arrange
            var value = TravelOptions.PropellerPlane;

            // Act
            var ex = Record.Exception(() => value.GetIndividualFlags<int>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
            ex.Message.Should().Contain("typeof TEnum is not an Enum");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_return_enum_value___When_enum_is_not_a_flags_enum()
        {
            // Arrange
            var value1 = GoodStuff.Bulldogs;
            var value2 = GoodStuff.WorkingFromHome;

            // Act
            var actual1 = value1.GetIndividualFlags<GoodStuff>();
            var actual2 = value2.GetIndividualFlags<GoodStuff>();

            // Assert
            actual1.Should().Equal(GoodStuff.Bulldogs);
            actual2.Should().Equal(GoodStuff.WorkingFromHome);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_return_all_individual_flags___When_no_combined_flags_are_used()
        {
            // Arrange
            var value1 = TravelOptions.None;
            var value2 = TravelOptions.Speedboat | TravelOptions.Bus | TravelOptions.Taxi | TravelOptions.PropellerPlane;

            // Act
            var actual1 = value1.GetIndividualFlags<TravelOptions>();
            var actual2 = value2.GetIndividualFlags<TravelOptions>();

            // Assert
            actual1.Should().Equal(TravelOptions.None);
            actual2.Should().Equal(TravelOptions.Speedboat, TravelOptions.PropellerPlane, TravelOptions.Bus, TravelOptions.Taxi);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_return_all_individual_flags___When_only_combined_flags_are_used_and_they_have_no_overlapping_flags()
        {
            // Arrange
            var value1 = TravelOptions.Wheeled;
            var value2 = TravelOptions.Air | TravelOptions.MassTransit;

            // Act
            var actual1 = value1.GetIndividualFlags<TravelOptions>();
            var actual2 = value2.GetIndividualFlags<TravelOptions>();

            // Assert
            actual1.Should().Equal(TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.Taxi);
            actual2.Should().Equal(TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.Bus, TravelOptions.CommercialPlane);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_return_mix_of_combined_flags_and_individual_flags___When_only_combined_flags_are_used_but_they_have_an_overlapping_flag()
        {
            // Arrange
            var value = TravelOptions.Wheeled | TravelOptions.MassTransit;

            // Act
            var actual = value.GetIndividualFlags<TravelOptions>();

            // Assert
            actual.Should().Equal(TravelOptions.Train, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.Taxi);
        }

        // ReSharper restore InconsistentNaming
    }
}
