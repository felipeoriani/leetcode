using System.Linq;

MyCalendar calendar = new MyCalendar();

Console.WriteLine($"calendar.Book(10, 20), expected True -- Result: {calendar.Book(10, 20)}");
Console.WriteLine($"calendar.Book(15, 25), expected False -- Result: {calendar.Book(15, 25)}");
Console.WriteLine($"calendar.Book(20, 30), expected True -- Result: {calendar.Book(20, 30)}");


MyCalendar calendar2 = new MyCalendar();

Console.WriteLine($"calendar2.BookLinq(10, 20), expected True -- Result: {calendar2.BookLinq(10, 20)}");
Console.WriteLine($"calendar2.BookLinq(15, 25), expected False -- Result: {calendar2.BookLinq(15, 25)}");
Console.WriteLine($"calendar2.BookLinq(20, 30), expected True -- Result: {calendar2.BookLinq(20, 30)}");

public class MyCalendar {

    private readonly List<Event> _events;

    public MyCalendar() {
        _events = new List<Event>();
    }

    public bool Book(int start, int end) {
        
        if (_events.Count > 0) {
            for (int i = 0; i < _events.Count; ++i) { // O(n) for worst case
                Event @event = _events[i];
                if (start < @event.End && end > @event.Start)
                    return false;
            }
        }

        _events.Add(new Event(Guid.NewGuid(), start, end));

        return true;
    }

    public bool BookLinq(int start, int end) {
        if (_events.Any(@event => start < @event.End && end > @event.Start))
            return false;

        _events.Add(new Event(Guid.NewGuid(), start, end));

        return true;
    }
}

public record Event(Guid Id, int Start, int End);
