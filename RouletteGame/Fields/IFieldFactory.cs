using System.Collections.Generic;

namespace Roulette.Fields
{
    public interface IFieldFactory
    {
        List<IField> CreateFields();
    }
}