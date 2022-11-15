using System.Threading.Tasks;
using Sirenix.OdinInspector;

namespace SwampAttack.Root.Interfaces
{
    public abstract class CompositeRoot : SerializedMonoBehaviour
    {
        public abstract void Compose();
    }
}