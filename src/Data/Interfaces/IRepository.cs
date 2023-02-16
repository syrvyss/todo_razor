namespace WebApp.Data.Interfaces;

public interface IRepository<T> {
    public void Create(T item);
    public void Delete(string id);
    public T? Read(string id);
    public List<T> Get();
    public void Update(string id, T thing);
}