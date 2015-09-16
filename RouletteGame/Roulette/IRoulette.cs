using Roulette.Fields;

namespace Roulette.Roulette
{
    public interface IRoulette
    {
        void Spin();
        IField GetResult();
    }
}