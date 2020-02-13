using System;

public class Scale<T>
    where T : IComparable<T>
{
    private T first;
    private T second;

    public Scale(T first, T second)
    {
        this.first = first;
        this.second = second;
    }

    public T GetHavier()
    {
        if (this.first.CompareTo(this.second) > 0)
        {
            return this.first;
        }
        else if (this.first.CompareTo(this.second) < 0)
        {
            return this.second;
        }

        return default(T);
    }
}
