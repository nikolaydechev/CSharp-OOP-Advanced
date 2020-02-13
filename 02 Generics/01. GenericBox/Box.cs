namespace _01.GenericBox
{
    public class Box<T>
    {
        private readonly T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"{this.item.GetType().FullName}: {this.item}";
        }
    }
}
