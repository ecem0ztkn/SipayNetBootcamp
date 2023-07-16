namespace WeekOneTask.Results
{
    public class DataResult<T> where T:class,new()
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
