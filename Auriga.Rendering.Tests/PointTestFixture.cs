// ------------------------------------------------------------------------------------------------
// <copyright file="PointTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="Point"/> value semantics: translation, equality in all its forms, the
    /// hash code contract and the invariant textual representation.
    /// </summary>
    [TestFixture]
    public class PointTestFixture
    {
        [Test]
        public void Verify_that_addition_translates()
        {
            Assert.That(new Point(1.5, 2) + new Point(-0.5, 3), Is.EqualTo(new Point(1, 5)));
        }

        [Test]
        public void Verify_the_equality_contract()
        {
            var point = new Point(3, 4);
            var equal = new Point(3, 4);
            var different = new Point(3, 5);

            Assert.Multiple(() =>
            {
                Assert.That(point == equal, Is.True);
                Assert.That(point != different, Is.True);
                Assert.That(point.Equals((object)equal), Is.True);
                Assert.That(point.Equals("not a point"), Is.False);
                Assert.That(point.GetHashCode(), Is.EqualTo(equal.GetHashCode()));
            });
        }

        [Test]
        public void Verify_the_invariant_representation()
        {
            Assert.That(new Point(371.5, -9).ToString(), Is.EqualTo("(371.5, -9)"));
        }
    }
}
