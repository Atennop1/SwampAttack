using System;
using System.Collections.Generic;

namespace SwampAttack.Root.Update
{
    public interface ISystemUpdate
    {
        public void Add(params IUpdatable[] updatables);
        public void Remove(IUpdatable updatable);
        public void TryUpdateAll();
    }
}