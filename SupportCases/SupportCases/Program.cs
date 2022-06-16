using System;

namespace SupportCases
{
    public enum PriorityLevel
    {
        Critical,
        Important,
        Medium,
        Low
    }

    public struct SupportTicket
    {
        public long Id;
        public string Description;
        public PriorityLevel Priority;

        public SupportTicket(long id, string description, PriorityLevel priority)
        {
            this.Id = id;
            this.Description = description;
            this.Priority = priority;
        }
    }

    public class Program
    {
        public static void FinalSort(SupportTicket[] tickets)
        {
            TempSort(tickets, 0, tickets.Length - 1);
            Array.Reverse(tickets);
        }

        static void TempSort(SupportTicket[] tickets, int start, int end)
        {
            var pivot = tickets[(start + end) / 2].Priority;
            int i = start;
            int j = end;

            while (i <= j)
            {
                while (tickets[i].Priority > pivot)
                {
                    i++;
                }

                while (tickets[j].Priority < pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(tickets, i, j);

                    i++;
                    j--;
                }
            }

            if (start < j)
            {
                TempSort(tickets, start, j);
            }

            if (i >= end)
            {
                return;
            }

            TempSort(tickets, i, end);
        }

        static void Swap(SupportTicket[] tickets, int pivot, int secondIndex)
        {
            SupportTicket temp = tickets[secondIndex];
            tickets[secondIndex] = tickets[pivot];
            tickets[pivot] = temp;
        }

        static void Print(SupportTicket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                Console.WriteLine(tickets[i].Id + " - " + tickets[i].Description + " - " + tickets[i].Priority);
            }
        }

        static SupportTicket[] ReadSupportTickets()
        {
            const int ticketIdIndex = 0;
            const int descriptionIndex = 1;
            const int priorityLevelIndex = 2;

            int ticketsNumber = Convert.ToInt32(Console.ReadLine());
            SupportTicket[] result = new SupportTicket[ticketsNumber];

            for (int i = 0; i < ticketsNumber; i++)
            {
                string[] ticketData = Console.ReadLine().Split('-');
                long id = Convert.ToInt64(ticketData[ticketIdIndex]);
                result[i] = new SupportTicket(id, ticketData[descriptionIndex].Trim(), GetPriorityLevel(ticketData[priorityLevelIndex]));
            }

            return result;
        }

        static PriorityLevel GetPriorityLevel(string priority)
        {
            return priority.ToLower().Trim() switch
            {
                "critical" => PriorityLevel.Critical,
                "important" => PriorityLevel.Important,
                "medium" => PriorityLevel.Medium,
                _ => PriorityLevel.Low,
            };
        }

        static void Main()
        {
            SupportTicket[] tickets = ReadSupportTickets();
            FinalSort(tickets);
            Print(tickets);
            Console.Read();
        }
    }
}
