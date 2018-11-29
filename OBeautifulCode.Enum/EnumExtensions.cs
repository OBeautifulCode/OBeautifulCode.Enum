﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Enum source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Enum.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    using OBeautifulCode.Validation.Recipes;

    /// <summary>
    /// Adds some convenient extension methods to enums.
    /// </summary>
#if !OBeautifulCodeEnumRecipesProject
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("OBeautifulCode.Enum", "See package version number")]
    internal
#else
    public
#endif
    static class EnumExtensions
    {
        /// <summary>
        /// Gets the members/values of a specified enum.
        /// </summary>
        /// <typeparam name="TEnum">The type of enum.</typeparam>
        /// <returns>
        /// The members/values of the specified enum.
        /// For flags enums, returns all individual and combined flags.
        /// </returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not of type <see cref="Enum"/>.</exception>
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static IReadOnlyCollection<TEnum> GetEnumValues<TEnum>()
            where TEnum : struct
        {
            typeof(TEnum).IsEnum.Named($"typeof({nameof(TEnum)}).{nameof(Type.IsEnum)}").Must().BeTrue();

            var result = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
            return result;
        }

        /// <summary>
        /// Gets the members/values of a specified enum.
        /// </summary>
        /// <param name="enumType">The enum type.</param>
        /// <returns>
        /// The members/values of the specified enum.
        /// For flags enums, returns all individual and combined flags.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="enumType"/> is not of type <see cref="Enum"/>.</exception>
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static IReadOnlyCollection<Enum> GetEnumValues(
            this Type enumType)
        {
            new { enumType }.Must().NotBeNull();
            enumType.IsEnum.Named($"{nameof(enumType)}.{nameof(Type.IsEnum)}").Must().BeTrue();

            var result = Enum.GetValues(enumType).Cast<Enum>().ToList().AsReadOnly();
            return result;
        }

        /// <summary>
        /// Determines if the specified enum is a flags enum.
        /// </summary>
        /// <typeparam name="TEnum">The type of enum.</typeparam>
        /// <returns>
        /// true if the specified enum is a flags enum, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not of type <see cref="Enum"/>.</exception>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "This method signature is here for completeness.")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "'Flags' is the most appropriate term here.")]
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static bool IsFlagsEnum<TEnum>()
            where TEnum : struct
        {
            typeof(TEnum).IsEnum.Named($"typeof({nameof(TEnum)}).{nameof(Type.IsEnum)}").Must().BeTrue();

            var result = typeof(TEnum).GetCustomAttributes<FlagsAttribute>().Any();
            return result;
        }

        /// <summary>
        /// Determines if the specified enum is a flags enum.
        /// </summary>
        /// <param name="enumType">The enum type.</param>
        /// <returns>
        /// true if the specified enum is a flags enum, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="enumType"/> is not of type <see cref="Enum"/>.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "'Flags' is the most appropriate term here.")]
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static bool IsFlagsEnum(
            this Type enumType)
        {
            new { enumType }.Must().NotBeNull();
            enumType.IsEnum.Named($"{nameof(enumType)}.{nameof(Type.IsEnum)}").Must().BeTrue();

            var result = enumType.GetCustomAttributes<FlagsAttribute>().Any();
            return result;
        }

        /// <summary>
        /// Gets the flags of a flags enum, with a preference for returning combined flags
        /// instead of individual flags where the enum value uses combined flags.
        /// </summary>
        /// <param name="value">The enum value to decompose into it's flags.</param>
        /// <remarks>
        /// Adapted from: <a href="http://stackoverflow.com/a/4171168/356790" />.
        /// </remarks>
        /// <returns>
        /// The flags of the specified enum, with combined flags instead of individual flags where possible.
        /// No bit will be repeated.  Thus, if two combined flags are represented in the value and they
        /// have an overlapping individual flag, only one of those combined flags will be returned and
        /// the other will be decomposed into it's non-overlapping individual flags.
        /// If value is 0, then a collection with only the 0 value is returned.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "'Flags' is the most appropriate term here.")]
        public static IReadOnlyCollection<Enum> GetFlagsCombinedWherePossible(
            this Enum value)
        {
            new { value }.Must().NotBeNull();

            var result = GetFlags(value, GetEnumValues(value.GetType()).ToArray()).ToList();
            return result;
        }

        /// <summary>
        /// Gets the flags of a flags enum, with a preference for returning combined flags
        /// instead of individual flags where the enum value uses combined flags.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value to decompose into it's flags.</param>
        /// <remarks>
        /// Adapted from: <a href="http://stackoverflow.com/a/4171168/356790" />.
        /// </remarks>
        /// <returns>
        /// The flags of the specified enum, with combined flags instead of individual flags where possible.
        /// No bit will be repeated.  Thus, if two combined flags are represented in the value and they
        /// have an overlapping individual flag, only one of those combined flags will be returned and
        /// the other will be decomposed into it's non-overlapping individual flags.
        /// If value is 0, then a collection with only the 0 value is returned.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not of type <see cref="Enum"/>.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "'Flags' is the most appropriate term here.")]
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static IReadOnlyCollection<TEnum> GetFlagsCombinedWherePossible<TEnum>(
            this Enum value)
            where TEnum : struct
        {
            new { value }.Must().NotBeNull();
            typeof(TEnum).IsEnum.Named($"typeof({nameof(TEnum)}).{nameof(Type.IsEnum)}").Must().BeTrue();

            var result = GetFlags(value, GetEnumValues(value.GetType()).ToArray()).Cast<TEnum>().ToList();
            return result;
        }

        /// <summary>
        /// Checks if there is any overlap between the two <see cref="FlagsAttribute" /> enumerations.
        /// </summary>
        /// <param name="first">First to check.</param>
        /// <param name="second">Second to check.</param>
        /// <returns>Value indicating whether there is any overlap.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="first"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="second"/> is null.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Justification = "'Flag' is the most appropriate term here.")]
        public static bool HasFlagOverlap(
            this Enum first,
            Enum second)
        {
            new { first }.Must().NotBeNull();
            new { second }.Must().NotBeNull();

            var ret = first.GetIndividualFlags().Intersect(second.GetIndividualFlags()).Any();
            return ret;
        }

        /// <summary>
        /// Gets the individual flags of a flags enum type.
        /// </summary>
        /// <param name="enumType">The enum type.</param>
        /// <returns>
        /// The individuals flags of the specified flags enum type (includes 0).
        /// If <paramref name="enumType"/> is not a flags enum then all enum values are returned.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="enumType"/> is not of type <see cref="Enum"/>.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "'Flags' is the most appropriate term here.")]
        public static IReadOnlyCollection<Enum> GetIndividualFlags(
            this Type enumType)
        {
            var values = GetEnumValues(enumType);

            var result = new List<Enum>();
            foreach (var value in values)
            {
                if (value.GetIndividualFlags().Count == 1)
                {
                    result.Add(value);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the individual flags of a flags enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of enum.</typeparam>
        /// <returns>
        /// The individuals flags of the specified flags enum type (includes 0).
        /// If <typeparamref name="TEnum"/> is not a flags enum then all enum values are returned.
        /// </returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not of type <see cref="Enum"/>.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "'Flags' is the most appropriate term here.")]
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static IReadOnlyCollection<TEnum> GetIndividualFlags<TEnum>()
            where TEnum : struct
        {
            typeof(TEnum).IsEnum.Named($"typeof({nameof(TEnum)}).{nameof(Type.IsEnum)}").Must().BeTrue();

            var result = typeof(TEnum).GetIndividualFlags().Cast<TEnum>().ToList();
            return result;
        }

        /// <summary>
        /// Gets the individual flags of a flags enum value.
        /// </summary>
        /// <param name="value">The enum value to decompose into it's individual flags.</param>
        /// <remarks>
        /// Adapted from: <a href="http://stackoverflow.com/a/4171168/356790" />.
        /// </remarks>
        /// <returns>
        /// The individuals flags of the specified flags enum value.
        /// If value is 0, then a collection with only the 0 value is returned.
        /// If the enum is not a flags enum then a collection with the enum value itself is returned.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "'Flags' is the most appropriate term here.")]
        public static IReadOnlyCollection<Enum> GetIndividualFlags(
            this Enum value)
        {
            new { value }.Must().NotBeNull();

            IReadOnlyCollection<Enum> result;
            var enumType = value.GetType();
            if (enumType.IsFlagsEnum())
            {
                result = GetFlags(value, GetFlagValues(value.GetType()).ToArray()).ToList();
            }
            else
            {
                result = new[] { value };
            }

            return result;
        }

        /// <summary>
        /// Gets the individual flags of a flags enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value to decompose into it's individual flags.</param>
        /// <remarks>
        /// Adapted from: <a href="http://stackoverflow.com/a/4171168/356790" />.
        /// </remarks>
        /// <returns>
        /// The individuals flags of the specified flags enum value.
        /// If value is 0, then a collection with only the 0 value is returned.
        /// If the enum is not a flags enum then a collection with the enum value itself is returned.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not of type <see cref="Enum"/>.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = "'Flags' is the most appropriate term here.")]
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static IReadOnlyCollection<TEnum> GetIndividualFlags<TEnum>(
            this Enum value)
            where TEnum : struct
        {
            new { value }.Must().NotBeNull();
            typeof(TEnum).IsEnum.Named($"typeof({nameof(TEnum)}).{nameof(Type.IsEnum)}").Must().BeTrue();

            IReadOnlyCollection<TEnum> result;
            var enumType = value.GetType();
            if (enumType.IsFlagsEnum())
            {
                result = GetFlags(value, GetFlagValues(value.GetType()).ToArray()).Cast<TEnum>().ToList();
            }
            else
            {
                result = new[] { value }.Cast<TEnum>().ToArray();
            }

            return result;
        }

        private static IEnumerable<Enum> GetFlags(
            Enum value,
            IList<Enum> values)
        {
            ulong bits = Convert.ToUInt64(value, CultureInfo.InvariantCulture);
            List<Enum> results = new List<Enum>();
            for (int i = values.Count - 1; i >= 0; i--)
            {
                ulong mask = Convert.ToUInt64(values[i], CultureInfo.InvariantCulture);
                if (i == 0 && mask == 0L)
                {
                    break;
                }

                if ((bits & mask) == mask)
                {
                    results.Add(values[i]);
                    bits -= mask;
                }
            }

            if (bits != 0L)
            {
                return Enumerable.Empty<Enum>();
            }

            if (Convert.ToUInt64(value, CultureInfo.InvariantCulture) != 0L)
            {
                return results.Reverse<Enum>();
            }

            if (bits == Convert.ToUInt64(value, CultureInfo.InvariantCulture) && values.Count > 0 &&
                Convert.ToUInt64(values[0], CultureInfo.InvariantCulture) == 0L)
            {
                return values.Take(1);
            }

            return Enumerable.Empty<Enum>();
        }

        private static IEnumerable<Enum> GetFlagValues(
            Type enumType)
        {
            ulong flag = 0x1;
            foreach (var value in Enum.GetValues(enumType).Cast<Enum>())
            {
                ulong bits = Convert.ToUInt64(value);
                if (bits == 0L)
                {
                    yield return value;
                }

                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits)
                {
                    yield return value;
                }
            }
        }
    }
}
