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
        public static void GetDefinedEnumValues_TEnum___Should_throw_ArgumentException___When_generic_type_parameter_TEnum_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => EnumExtensions.GetDefinedEnumValues<int>());
            var actual2 = Record.Exception(() => EnumExtensions.GetDefinedEnumValues<bool>());
            var actual3 = Record.Exception(() => EnumExtensions.GetDefinedEnumValues<byte>());
            var actual4 = Record.Exception(() => EnumExtensions.GetDefinedEnumValues<char>());

            var actuals = new[] { actual1, actual2, actual3, actual4 };

            // Assert
            foreach (var actual in actuals)
            {
                actual.Should().BeOfType<ArgumentException>();
                actual.Message.Should().Contain("typeof(TEnum).IsEnum");
            }
        }

        [Fact]
        public static void GetDefinedEnumValues_TEnum___Should_return_enum_values_in_order___When_called()
        {
            // Arrange, Act
            var actual1 = EnumExtensions.GetDefinedEnumValues<Empty>();
            var actual2 = EnumExtensions.GetDefinedEnumValues<GoodStuff>();
            var actual3 = EnumExtensions.GetDefinedEnumValues<TravelOptions>();

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().Equal(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers);
            actual3.Should().Equal(TravelOptions.None, TravelOptions.Speedboat, TravelOptions.Train, TravelOptions.PropellerPlane, TravelOptions.RentalCar, TravelOptions.Bus, TravelOptions.MassTransit, TravelOptions.Taxi, TravelOptions.Wheeled, TravelOptions.CommercialPlane, TravelOptions.Air);
        }

        [Fact]
        public static void GetDefinedEnumValues_enumType___Should_throw_ArgumentNullException___When_parameter_enumType_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => EnumExtensions.GetDefinedEnumValues(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("enumType");
        }

        [Fact]
        public static void GetDefinedEnumValues_enumType___Should_throw_ArgumentException___When_parameter_enumType_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => EnumExtensions.GetDefinedEnumValues(typeof(int)));
            var actual2 = Record.Exception(() => EnumExtensions.GetDefinedEnumValues(typeof(bool)));
            var actual3 = Record.Exception(() => EnumExtensions.GetDefinedEnumValues(typeof(byte)));
            var actual4 = Record.Exception(() => EnumExtensions.GetDefinedEnumValues(typeof(char)));

            var actuals = new[] { actual1, actual2, actual3, actual4 };

            // Assert
            foreach (var actual in actuals)
            {
                actual.Should().BeOfType<ArgumentException>();
                actual.Message.Should().Contain("enumType.IsEnum");
            }
        }

        [Fact]
        public static void GetDefinedEnumValues_Type___Should_return_enum_values_in_order___When_called()
        {
            // Arrange, Act
            var actual1 = EnumExtensions.GetDefinedEnumValues(typeof(Empty));
            var actual2 = EnumExtensions.GetDefinedEnumValues(typeof(GoodStuff));
            var actual3 = EnumExtensions.GetDefinedEnumValues(typeof(TravelOptions));

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
        public static void GetAllPossibleEnumValues_TEnum___Should_throw_ArgumentException___When_generic_type_parameter_TEnum_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues<int>());
            var actual2 = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues<bool>());
            var actual3 = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues<byte>());
            var actual4 = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues<char>());

            var actuals = new[] { actual1, actual2, actual3, actual4 };

            // Assert
            foreach (var actual in actuals)
            {
                actual.Should().BeOfType<ArgumentException>();
                actual.Message.Should().Contain("typeof(TEnum).IsEnum");
            }
        }

        [Fact]
        public static void GetAllPossibleEnumValues_TEnum___Should_return_all_possible_enum_values___When_called()
        {
            // Arrange, Act
            var actual1 = EnumExtensions.GetAllPossibleEnumValues<Empty>();
            var actual2 = EnumExtensions.GetAllPossibleEnumValues<GoodStuff>();
            var actual3 = EnumExtensions.GetAllPossibleEnumValues<DaysWeWork>();

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().BeEquivalentTo(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers);
            actual3.Should().BeEquivalentTo(
                DaysWeWork.None,
                DaysWeWork.Monday,
                DaysWeWork.Tuesday,
                DaysWeWork.Wednesday,
                DaysWeWork.Thursday,
                DaysWeWork.Monday | DaysWeWork.Tuesday,
                DaysWeWork.Monday | DaysWeWork.Wednesday,
                DaysWeWork.Monday | DaysWeWork.Thursday,
                DaysWeWork.Tuesday | DaysWeWork.Wednesday,
                DaysWeWork.Tuesday | DaysWeWork.Thursday,
                DaysWeWork.Wednesday | DaysWeWork.Thursday,
                DaysWeWork.Monday | DaysWeWork.Tuesday | DaysWeWork.Wednesday,
                DaysWeWork.Monday | DaysWeWork.Tuesday | DaysWeWork.Thursday,
                DaysWeWork.Monday | DaysWeWork.Wednesday | DaysWeWork.Thursday,
                DaysWeWork.Tuesday | DaysWeWork.Wednesday | DaysWeWork.Thursday,
                DaysWeWork.Monday | DaysWeWork.Tuesday | DaysWeWork.Wednesday | DaysWeWork.Thursday);
        }

        [Fact]
        public static void GetAllPossibleEnumValues_enumType___Should_throw_ArgumentNullException___When_parameter_enumType_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("enumType");
        }

        [Fact]
        public static void GetAllPossibleEnumValues_enumType___Should_throw_ArgumentException___When_parameter_enumType_is_not_of_type_Enum()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues(typeof(int)));
            var actual2 = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues(typeof(bool)));
            var actual3 = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues(typeof(byte)));
            var actual4 = Record.Exception(() => EnumExtensions.GetAllPossibleEnumValues(typeof(char)));

            var actuals = new[] { actual1, actual2, actual3, actual4 };

            // Assert
            foreach (var actual in actuals)
            {
                actual.Should().BeOfType<ArgumentException>();
                actual.Message.Should().Contain("enumType.IsEnum");
            }
        }

        [Fact]
        public static void GetAllPossibleEnumValues_Type___Should_return_all_possible_enum_values___When_called()
        {
            // Arrange, Act
            var actual1 = EnumExtensions.GetAllPossibleEnumValues(typeof(Empty));
            var actual2 = EnumExtensions.GetAllPossibleEnumValues(typeof(GoodStuff));
            var actual3 = EnumExtensions.GetAllPossibleEnumValues(typeof(DaysWeWork));

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().BeEquivalentTo(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs, GoodStuff.Sunflowers);
            actual3.Should().BeEquivalentTo(
                DaysWeWork.None,
                DaysWeWork.Monday,
                DaysWeWork.Tuesday,
                DaysWeWork.Wednesday,
                DaysWeWork.Thursday,
                DaysWeWork.Monday | DaysWeWork.Tuesday,
                DaysWeWork.Monday | DaysWeWork.Wednesday,
                DaysWeWork.Monday | DaysWeWork.Thursday,
                DaysWeWork.Tuesday | DaysWeWork.Wednesday,
                DaysWeWork.Tuesday | DaysWeWork.Thursday,
                DaysWeWork.Wednesday | DaysWeWork.Thursday,
                DaysWeWork.Monday | DaysWeWork.Tuesday | DaysWeWork.Wednesday,
                DaysWeWork.Monday | DaysWeWork.Tuesday | DaysWeWork.Thursday,
                DaysWeWork.Monday | DaysWeWork.Wednesday | DaysWeWork.Thursday,
                DaysWeWork.Tuesday | DaysWeWork.Wednesday | DaysWeWork.Thursday,
                DaysWeWork.Monday | DaysWeWork.Tuesday | DaysWeWork.Wednesday | DaysWeWork.Thursday);
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
        public static void GetIndividualFlags_enumType___Should_return_all_enum_values___When_parameter_enumType_is_not_a_flags_enum()
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
        public static void GetIndividualFlags_TEnum___Should_return_all_enum_values___When_parameter_enumType_is_not_a_flags_enum()
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

        [Fact]
        public static void BitwiseOr___Should_throw_ArgumentNullException___When_parameter_value1_is_null()
        {
            // Arrange
            var value2 = TravelOptions.Speedboat;

            // Act
            var actual = Record.Exception(() => EnumExtensions.BitwiseOr(null, value2));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("value1");
        }

        [Fact]
        public static void BitwiseOr___Should_throw_ArgumentNullException___When_parameter_value2_is_null()
        {
            // Arrange
            var value1 = TravelOptions.Bus;

            // Act
            var actual = Record.Exception(() => value1.BitwiseOr(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("value2");
        }

        [Fact]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "flags", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "this is the best term")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "this is the best term")]
        public static void BitwiseOr___Should_throw_ArgumentException___When_parameter_value1_type_is_not_a_flags_enum()
        {
            // Arrange
            var value1 = GoodStuff.Bulldogs;
            var value2 = GoodStuff.Chocolate;

            // Act
            var actual = Record.Exception(() => value1.BitwiseOr(value2));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("value1.GetType().IsFlagsEnum()");
        }

        [Fact]
        public static void BitwiseOr___Should_throw_ArgumentException___When_parameter_value1_type_is_not_equal_to_parameter_value2_type()
        {
            // Arrange
            var value1 = TravelOptions.Bus;
            var value2 = GoodStuff.Chocolate;

            // Act
            var actual = Record.Exception(() => value1.BitwiseOr(value2));

            // Assert
            actual.Should().BeOfType<ArgumentException>();
            actual.Message.Should().Contain("value1.GetType() == value2.GetType()");
        }

        [Fact]
        public static void BitwiseOr___Should_return_bitwise_or_of_specified_values___When_called_on_signed_enum()
        {
            // Arrange
            var value1a = TravelOptions.Air;
            var value1b = TravelOptions.Bus;
            var expected1 = value1a | value1b;

            var value2a = TravelOptions.MassTransit;
            var value2b = TravelOptions.Speedboat;
            var expected2 = value2a | value2b;

            // Act
            var actual1 = value1a.BitwiseOr(value1b);
            var actual2 = value2a.BitwiseOr(value2b);

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
        }

        [Fact]
        public static void BitwiseOr___Should_return_bitwise_or_of_specified_values___When_called_on_unsigned_enum()
        {
            // Arrange
            var value1a = UnsignedTravelOptions.Air;
            var value1b = UnsignedTravelOptions.Bus;
            var expected1 = value1a | value1b;

            var value2a = UnsignedTravelOptions.MassTransit;
            var value2b = UnsignedTravelOptions.Speedboat;
            var expected2 = value2a | value2b;

            // Act
            var actual1 = value1a.BitwiseOr(value1b);
            var actual2 = value2a.BitwiseOr(value2b);

            // Assert
            actual1.Should().Be(expected1);
            actual2.Should().Be(expected2);
        }
    }
}
