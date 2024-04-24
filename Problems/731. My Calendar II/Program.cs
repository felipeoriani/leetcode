MyCalendarTwo calendarTwo = new MyCalendarTwo();

Console.WriteLine($"calendarTwo.Book(10, 20), expected True -- Result: {calendarTwo.Book(10, 20)}");
Console.WriteLine($"calendarTwo.Book(50, 60), expected True -- Result: {calendarTwo.Book(50, 60)}");
Console.WriteLine($"calendarTwo.Book(10, 40), expected True -- Result: {calendarTwo.Book(10, 40)}");
Console.WriteLine($"calendarTwo.Book(5, 15), expected False -- Result: {calendarTwo.Book(5, 15)}");
Console.WriteLine($"calendarTwo.Book(5, 10), expected True -- Result: {calendarTwo.Book(5, 10)}");
Console.WriteLine($"calendarTwo.Book(25, 55), expected True -- Result: {calendarTwo.Book(25, 55)}");

MyCalendarTwo calendarTwo2 = new MyCalendarTwo();

Console.WriteLine($"calendarTwo2.BookLinq(10, 20), expected True -- Result: {calendarTwo2.BookLinq(10, 20)}");
Console.WriteLine($"calendarTwo2.BookLinq(50, 60), expected True -- Result: {calendarTwo2.BookLinq(50, 60)}");
Console.WriteLine($"calendarTwo2.BookLinq(10, 40), expected True -- Result: {calendarTwo2.BookLinq(10, 40)}");
Console.WriteLine($"calendarTwo2.BookLinq(5, 15), expected False -- Result: {calendarTwo2.BookLinq(5, 15)}");
Console.WriteLine($"calendarTwo2.BookLinq(5, 10), expected True -- Result: {calendarTwo2.BookLinq(5, 10)}");
Console.WriteLine($"calendarTwo2.BookLinq(25, 55), expected True -- Result: {calendarTwo2.BookLinq(25, 55)}");

//    0 5 10 15 20 25 30 35 40 45 50 55 60 65
// A      --------                              True  (no conflict)
// B                              -------       True  (no conflict)
// C      --------------------                  True  (single conflict with A)
// D    ------                                  False (triple conflict with A and C)
// E    ---                                     True  (no conflict)
// F               -------------------          True  (double conflict but doesn't generate a triple)

public class MyCalendarTwo {

    private readonly List<Event> _events;
    private readonly Dictionary<int, int> _map;

    public MyCalendarTwo() {
        _events = new List<Event>();
        _map = new Dictionary<int, int>();
    }
    
    public bool Book(int start, int end) {
        List<Event> conflicts = new List<Event>();

        for (int i = 0; i < _events.Count; ++i) {
            Event currentEvent = _events[i];
            if (start < currentEvent.End && end > currentEvent.Start) {
                conflicts.Add(currentEvent);
            }
        }

        // check if there is a conflict between conflicted events
        if (conflicts.Any(e => conflicts.Count(c => e.Start < c.End && e.End > c.Start) > 1)) 
            return false;

        _events.Add(new Event(start, end));

        return true;
    }

    public bool BookLinq(int start, int end) {
        if (_events.Count > 0) {
            var conflicts = _events.Where(e => start < e.End && end > e.Start).ToList();

            if (conflicts.Count > 0) {
                if (conflicts.Any(e => conflicts.Count(c => e.Start < c.End && e.End > c.Start) > 1)) 
                    return false;
            }
        }
        _events.Add(new Event(start, end));

        return true;
    }
}

public record Event(int Start, int End);
