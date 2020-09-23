namespace ksp.blog.data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
