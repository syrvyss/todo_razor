using WebApp.Data.Interfaces;
using WebApp.Models;

namespace WebApp.Data.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class, IGuid {
    protected List<T> _list = new();

    public virtual void Create(T thing) {
        _list.Add(thing);
    }

    public void Delete(Guid id) {
        _list.RemoveAll(x => x.Id == id);
    }

    public T? Read(Guid id) {
        T? item = _list.Find(x => x.Id == id);
        return item;
    }

    public List<T> Get() {
        return _list;
    }

    public void Update(Guid id, T thing) {
        T? item = _list.SingleOrDefault(x => x.Id == id);
        item = thing;
    }
}