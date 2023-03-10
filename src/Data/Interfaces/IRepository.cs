namespace WebApp.Data.Interfaces;

public interface IRepository<T> {
    public void Create(T item, string userId);
    public void Delete(Guid id);
    public T? Read(Guid id);
    public List<T> Get();
    public void Update(T thing);
}