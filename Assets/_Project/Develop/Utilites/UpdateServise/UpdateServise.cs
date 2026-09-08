using System.Collections.Generic;

namespace _Project.Develop
{
    public class UpdateServise
    {
        List<IUpdatable> _updatables = new();

        public void Add(IUpdatable updatable) => _updatables.Add(updatable);

        public void Remove(IUpdatable updatable) => _updatables.Remove(updatable);

        public void Update(float deltaTime)
        {
            foreach (IUpdatable updatable in _updatables)
                updatable.Update(deltaTime);
        }
    }
}