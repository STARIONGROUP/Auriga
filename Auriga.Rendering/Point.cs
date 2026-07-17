// ------------------------------------------------------------------------------------------------
// <copyright file="Point.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering
{
    using System;
    using System.Globalization;

    /// <summary>
    /// An immutable 2D point (or offset) in absolute diagram coordinates, in the pixel units the
    /// GMF notation model persists.
    /// </summary>
    public readonly struct Point : IEquatable<Point>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">the horizontal coordinate</param>
        /// <param name="y">the vertical coordinate</param>
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the horizontal coordinate.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the vertical coordinate.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Translates the point by the supplied offset.
        /// </summary>
        /// <param name="left">the point</param>
        /// <param name="right">the offset to add</param>
        /// <returns>the translated point</returns>
        public static Point operator +(Point left, Point right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// Whether the two points are equal.
        /// </summary>
        /// <param name="left">the left point</param>
        /// <param name="right">the right point</param>
        /// <returns>true when the points are equal</returns>
        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Whether the two points differ.
        /// </summary>
        /// <param name="left">the left point</param>
        /// <param name="right">the right point</param>
        /// <returns>true when the points differ</returns>
        public static bool operator !=(Point left, Point right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Whether this point equals the other point.
        /// </summary>
        /// <param name="other">the point to compare with</param>
        /// <returns>true when both coordinates are equal</returns>
        public bool Equals(Point other)
        {
            return this.X.Equals(other.X) && this.Y.Equals(other.Y);
        }

        /// <summary>
        /// Whether this point equals the supplied object.
        /// </summary>
        /// <param name="obj">the object to compare with</param>
        /// <returns>true when the object is an equal <see cref="Point"/></returns>
        public override bool Equals(object? obj)
        {
            return obj is Point other && this.Equals(other);
        }

        /// <summary>
        /// The hash code combining both coordinates.
        /// </summary>
        /// <returns>the hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y);
        }

        /// <summary>
        /// The invariant-culture <c>(x, y)</c> representation.
        /// </summary>
        /// <returns>the textual representation</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "({0}, {1})", this.X, this.Y);
        }
    }
}
