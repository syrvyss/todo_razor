using WebApp.Data.Interfaces;
using WebApp.Models;

namespace WebApp.Data.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class, IGuid {
    protected List<T> _list = new();

    public virtual void Create(T thing) {
        _list.Add(thing);
    }

    public void Delete(string id) {
        _list.RemoveAll(x => x.Id.ToString() == id);
    }

    public T? Read(string id) {
        T? item = _list.Find(x => x.Id.ToString() == id);
        return item;
    }

    public List<T> Get() {
        return _list;
    }

    public void Update(string id, T thing) {
        T? item = _list.Find(x => x.Id.ToString() == id);
        item = thing;
    }
}