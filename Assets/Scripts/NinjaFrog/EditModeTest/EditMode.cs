using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class NinjaFrog
{
    private NinjaFrogStats stats;
    [SetUp]
    public void SetUp()
    {
        stats = new NinjaFrogStats(); 
    }

    [Test] 
    public void DefaultLives_ShouldBeThree()
    {
        Assert.AreEqual(3, stats.maxLives, "The default lives should be " + 3 + " but was " + stats.maxLives);
    }

    // Case Test for power and range
    [TestCase(true, 1, 1)]
    [TestCase(true, 2, 1)]
    [TestCase(false, 0, 1)]
    [TestCase(false, 1, 0)]
    [TestCase(true, 1, 0)]
    public void AttackPower_Cases(bool expected, int attackPower, int attackRange)
    {
        bool actual = stats.CanAttack(attackPower, attackRange);
        Assert.AreEqual(expected, actual, "The expected value should be " + expected + " but was " + actual);
    }
    
    // Case Test for damage
    // Default lives is 3
    [TestCase(false, 0)]
    [TestCase(false, 1)]
    [TestCase(false, 2)]
    [TestCase(true, 3)]
    [TestCase(true, 4)]
    public void ReduceLife_Cases(bool expected, int damage)
    {
        bool actual = stats.reduceLife(damage);
        Assert.AreEqual(expected, actual, "The expected value should be " + expected + " but was " + actual);
    }
}
