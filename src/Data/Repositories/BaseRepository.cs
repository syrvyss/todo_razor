using WebApp.Data.Interfaces;

namespace WebApp.Data.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class, IGuid {
    protected List<T> _list = new();

    public virtual void Create(T thing, string userId) {
        _list.Add(thing);
    }

    public void Delete(Guid id) {
        _list.RemoveAll(x => x.Id == id);
    }

    public T? Read(Guid id) {
        var item = _list.Find(x => x.Id == id);
        return item;
    }

    public List<T> Get() {
        return _list;
    }

    public void Update(T thing) {
        var index = _list.FindIndex(x => x.Id == thing.Id);

        if (index != -1) {
            _list[index] = thing;
        }
    }
}