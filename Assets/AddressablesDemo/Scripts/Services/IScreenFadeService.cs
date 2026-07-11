using System.Threading;
using System.Threading.Tasks;

namespace AddressablesDemo
{
    public interface IScreenFadeService
    {
        public Task ShowAsync(CancellationToken ctsToken);
        public Task HideAsync(CancellationToken ctsToken);
    }
}