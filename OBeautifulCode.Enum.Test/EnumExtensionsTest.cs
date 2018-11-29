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
        [Fact]
        public static void GetEnumValues_TEnum___Should_throw_ArgumentException___When_generic_type_parameter_TEnum_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => EnumExtensions.GetEnumValues<int>());
            var actual2 = Record.Exception(() => EnumExtensions.GetEnumValues<bool>());
            var actual3 = Record.Exception(() => EnumExtensions.GetEnumValues<byte>());
            var actual4 = Record.Exception(() => EnumExtensions.GetEnumValues<char>());

            var actuals = new[] { actual1, actual2, actual3, actual4 };

            // Assert
            foreach (var actual in actuals)
            {
                actual.Should().BeOfType<ArgumentException>();
                actual.Message.Should().Contain("typeof(TEnum).IsEnum");
            }
        }

        [Fact]
        public static void GetEnumValues_TEnum___Should_return_enum_values_in_order___When_called()
        {
            // Arrange, Act
            var actual1 = EnumExtensions.GetEnumValues<Empty>();
            var actual2 = EnumExtensions.GetEnumValues<GoodStuff>();
            var actual3 = EnumExtensions.GetEnumValues<TravelOptions>();

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().Equal(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers);
            actual3.Should().Equal(TravelOptions.None, TravelOptions.Speedboat, TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.MassTransit, TravelOptions.Taxi, TravelOptions.Wheeled, TravelOptions.CommercialPlane, TravelOptions.Air);
        }

        [Fact]
        public static void GetEnumValues_enumType___Should_throw_ArgumentNullException___When_parameter_enumType_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => EnumExtensions.GetEnumValues(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("enumType");
        }

        [Fact]
        public static void GetEnumValues_enumType___Should_throw_ArgumentException___When_parameter_enumType_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => EnumExtensions.GetEnumValues(typeof(int)));
            var actual2 = Record.Exception(() => EnumExtensions.GetEnumValues(typeof(bool)));
            var actual3 = Record.Exception(() => EnumExtensions.GetEnumValues(typeof(byte)));
            var actual4 = Record.Exception(() => EnumExtensions.GetEnumValues(typeof(char)));

            var actuals = new[] { actual1, actual2, actual3, actual4 };

            // Assert
            foreach (var actual in actuals)
            {
                actual.Should().BeOfType<ArgumentException>();
                actual.Message.Should().Contain("enumType.IsEnum");
            }
        }

        [Fact]
        public static void GetEnumValues_Type___Should_return_enum_values_in_order___When_called()
        {
            // Arrange, Act
            var actual1 = EnumExtensions.GetEnumValues(typeof(Empty));
            var actual2 = EnumExtensions.GetEnumValues(typeof(GoodStuff));
            var actual3 = EnumExtensions.GetEnumValues(typeof(TravelOptions));

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().Equal(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers);
            actual3.Should().Equal(TravelOptions.None, TravelOptions.Speedboat, TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.MassTransit, TravelOptions.Taxi, TravelOptions.Wheeled, TravelOptions.CommercialPlane, TravelOptions.Air);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_TEnum___Should_throw_ArgumentException___When_generic_type_parameter_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => EnumExtensions.IsFlagsEnum<int>());
            var actual2 = Record.Exception(() => EnumExtensions.IsFlagsEnum<bool>());
            var actual3 = Record.Exception(() => EnumExtensions.IsFlagsEnum<byte>());
            var actual4 = Record.Exception(() => EnumExtensions.IsFlagsEnum<char>());

            var actuals = new[] { actual1, actual2, actual3, actual4 };

            // Assert
            foreach (var actual in actuals)
            {
                actual.Should().BeOfType<ArgumentException>();
                actual.Message.Should().Contain("typeof(TEnum).IsEnum");
            }
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
        public static void IsFlagsEnum_enumType___Should_throw_ArgumentNullException___When_parameter_enumType_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => EnumExtensions.IsFlagsEnum(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("enumType");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_enumType___Should_throw_ArgumentException___When_parameter_enumType_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => typeof(int).IsFlagsEnum());
            var actual2 = Record.Exception(() => typeof(bool).IsFlagsEnum());
            var actual3 = Record.Exception(() => typeof(byte).IsFlagsEnum());
            var actual4 = Record.Exception(() => typeof(char).IsFlagsEnum());

            var actuals = new[] { actual1, actual2, actual3, actual4 };

            // Assert
            foreach (var actual in actuals)
            {
                actual.Should().BeOfType<ArgumentException>();
                actual.Message.Should().Contain("enumType.IsEnum");
            }
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void IsFlagsEnum_enumType___Should_return_false___When_parameter_enumType_is_not_a_flags_enum()
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
        public static void IsFlagsEnum_enumType___Should_return_true___When_parameter_enumType_is_a_flags_enum()
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
        public static void GetFlagsCombinedWherePossible_value___Should_throw_ArgumentNullException___When_parameter_value_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ((Enum)null).GetFlagsCombinedWherePossible());

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("value");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_value___Should_return_enum_value___When_enum_is_not_a_flags_enum()
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
        public static void GetFlagsCombinedWherePossible_value___Should_return_all_individual_flags___When_no_combined_flags_are_used()
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
        public static void GetFlagsCombinedWherePossible_value___Should_return_all_combined_flags___When_only_combined_flags_are_used_and_they_have_no_overlapping_flags()
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
        public static void GetFlagsCombinedWherePossible_value___Should_return_mix_of_combined_flags_and_individual_flags___When_only_combined_flags_are_used_but_they_have_an_overlapping_flag()
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
        public static void GetFlagsCombinedWherePossible_TEnum_value___Should_throw_ArgumentNullException___When_parameter_value_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ((Enum)null).GetFlagsCombinedWherePossible<TravelOptions>());

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("value");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_TEnum_value___Should_throw_ArgumentException___When_generic_type_parameter_TEnum_is_not_of_type_Enum()
        {
            // Arrange
            var value = TravelOptions.PropellerPlane;

            // Act
            var acutal = Record.Exception(() => value.GetFlagsCombinedWherePossible<int>());

            // Assert
            acutal.Should().BeOfType<ArgumentException>();
            acutal.Message.Should().Contain("typeof(TEnum).IsEnum");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetFlagsCombinedWherePossible_TEnum_value___Should_return_enum_value___When_enum_is_not_a_flags_enum()
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
        public static void GetFlagsCombinedWherePossible_TEnum_value___Should_return_all_individual_flags___When_no_combined_flags_are_used()
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
        public static void GetFlagsCombinedWherePossible_TEnum_value___Should_return_all_combined_flags___When_only_combined_flags_are_used_and_they_have_no_overlapping_flags()
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
        public static void GetFlagsCombinedWherePossible_TEnum_value___Should_return_mix_of_combined_flags_and_individual_flags___When_only_combined_flags_are_used_but_they_have_an_overlapping_flag()
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
        public static void GetIndividualFlags_enumType___Should_throw_ArgumentNullException___When_parameter_enumType_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ((Type)null).GetIndividualFlags());

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("enumType");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_enumType___Should_throw_ArgumentException___When_parameter_enumType_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual = Record.Exception(() => typeof(string).GetIndividualFlags());

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("enumType.IsEnum");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_enumType___Should_return_all_enum_values___When_parameter_enumType_is_a_non_flags_enum()
        {
            // Arrange, Act
            var expected = new[] { GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers };
            var actual = typeof(GoodStuff).GetIndividualFlags();

            // Assert
            actual.Should().Equal(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_enumType___Should_return_all_individual_flags___When_parameter_enumType_is_a_flags_enum()
        {
            // Arrange, Act
            var expected = new[] { TravelOptions.None, TravelOptions.Speedboat, TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.Taxi, TravelOptions.CommercialPlane };
            var actual = typeof(TravelOptions).GetIndividualFlags();

            // Assert
            actual.Should().Equal(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_throw_ArgumentException___When_generic_type_parameter_TEnum_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual = Record.Exception(() => EnumExtensions.GetIndividualFlags<int>());

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("typeof(TEnum).IsEnum");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_return_all_enum_values___When_parameter_enumType_is_a_non_flags_enum()
        {
            // Arrange, Act
            var expected = new[] { GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers };
            var actual = EnumExtensions.GetIndividualFlags<GoodStuff>();

            // Assert
            actual.Should().Equal(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum___Should_return_all_individual_flags___When_parameter_enumType_is_a_flags_enum()
        {
            // Arrange, Act
            var expected = new[] { TravelOptions.None, TravelOptions.Speedboat, TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.Taxi, TravelOptions.CommercialPlane };
            var actual = EnumExtensions.GetIndividualFlags<TravelOptions>();

            // Assert
            actual.Should().Equal(expected);
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_value___Should_throw_ArgumentNullException___When_parameter_value_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ((Enum)null).GetIndividualFlags());

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("value");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_value___Should_return_enum_value___When_enum_is_not_a_flags_enum()
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
        public static void GetIndividualFlags_value___Should_return_all_individual_flags___When_no_combined_flags_are_used()
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
        public static void GetIndividualFlags_value___Should_return_all_individual_flags___When_only_combined_flags_are_used_and_they_have_no_overlapping_flags()
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
        public static void GetIndividualFlags_value___Should_return_mix_of_combined_flags_and_individual_flags___When_only_combined_flags_are_used_but_they_have_an_overlapping_flag()
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
        public static void GetIndividualFlags_TEnum_value___Should_throw_ArgumentNullException___When_parameter_value_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ((Enum)null).GetIndividualFlags<TravelOptions>());

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("value");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum_value___Should_throw_ArgumentException___When_generic_type_parameter_TEnum_is_not_of_type_Enum()
        {
            // Arrange
            var value = TravelOptions.PropellerPlane;

            // Act
            var actual = Record.Exception(() => value.GetIndividualFlags<int>());

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("typeof(TEnum).IsEnum");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void GetIndividualFlags_TEnum_value___Should_return_enum_value___When_enum_is_not_a_flags_enum()
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
        public static void GetIndividualFlags_TEnum_value___Should_return_all_individual_flags___When_no_combined_flags_are_used()
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
        public static void GetIndividualFlags_TEnum_value___Should_return_all_individual_flags___When_only_combined_flags_are_used_and_they_have_no_overlapping_flags()
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
        public static void GetIndividualFlags_TEnum_value___Should_return_mix_of_combined_flags_and_individual_flags___When_only_combined_flags_are_used_but_they_have_an_overlapping_flag()
        {
            // Arrange
            var value = TravelOptions.Wheeled | TravelOptions.MassTransit;

            // Act
            var actual = value.GetIndividualFlags<TravelOptions>();

            // Assert
            actual.Should().Equal(TravelOptions.Train, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.Taxi);
        }
    }
}
