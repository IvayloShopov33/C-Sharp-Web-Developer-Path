namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T leftItem;
        private T rightItem;

        public EqualityScale(T leftItem, T rightItem)
        {
            this.leftItem = leftItem;
            this.rightItem = rightItem;
        }

        public bool AreEqual()
        {
            return this.leftItem.Equals(this.rightItem);
        }
    }
}
