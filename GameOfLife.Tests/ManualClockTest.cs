using System.Runtime.InteropServices;
using Xunit;

namespace GameOfLife.Tests
{
    public class ManualClockTest
    {
        [Fact]
        public void ManualClock_TickOnce_ShouldIncrementTickCount()
        {
            var clock = new ManualClock();
            clock.TickOnce();

            Assert.Equal(1, clock.TickCount);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        public void ManualClock_TickMany_ShouldIncrementTickCount(int ticks)
        {
            var clock = new ManualClock();
            clock.TickMany(ticks);
            
            Assert.Equal(ticks, clock.TickCount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void ManualClock_EventHandler_ShouldInvoke(int ticks)
        {
            var clock = new ManualClock();
            int actualTickCount = 0;
            
            clock.Tick += delegate{ actualTickCount++; };
            
            clock.TickMany(ticks);
            
            Assert.Equal(ticks, actualTickCount);   
        }
    }
}