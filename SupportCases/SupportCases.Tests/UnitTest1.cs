using System;
using Xunit;

namespace SupportCases.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void SupportCases_InputFromLowToCritical_ShouldSortThemFromCriticalToLow()
        {
            SupportTicket ticket1 = new SupportTicket ( 1, "Low error", PriorityLevel.Low );
            SupportTicket ticket2 = new SupportTicket(2, "Medioum error", PriorityLevel.Medium);
            SupportTicket ticket3 = new SupportTicket(3, "Important behavior", PriorityLevel.Important);
            SupportTicket ticket4 = new SupportTicket(4, "Critical behavior", PriorityLevel.Critical);

            SupportTicket[] tickets = new SupportTicket[] { ticket1, ticket2, ticket3, ticket4 };
            SupportTicket[] expectedSort = new SupportTicket[] { ticket4, ticket3, ticket2, ticket1 };

            Program.FinalSort(tickets);
            Assert.Equal(expectedSort, tickets);
        }

        [Fact]
        public void SupportCases_InputRandomOrder_ShouldSortThemFromCriticalToLow()
        {
            SupportTicket ticket3 = new SupportTicket(1, "Low error", PriorityLevel.Low);
            SupportTicket ticket1 = new SupportTicket(2, "Medioum error", PriorityLevel.Medium);
            SupportTicket ticket4 = new SupportTicket(3, "Important behavior", PriorityLevel.Important);
            SupportTicket ticket2 = new SupportTicket(4, "Critical behavior", PriorityLevel.Critical);

            SupportTicket[] tickets = new SupportTicket[] { ticket3, ticket1, ticket4, ticket2 };
            SupportTicket[] expectedSort = new SupportTicket[] { ticket2, ticket4, ticket1, ticket3 };

            Program.FinalSort(tickets);
            Assert.Equal(expectedSort, tickets);
        }
    }
}
