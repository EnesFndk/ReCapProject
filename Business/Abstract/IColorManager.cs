using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorManager
    {
        List<Color> GetAll();
        Color GetById(int colorId);
        void Add(Color color);
        void Delete(Color color);
        void Update(Color color);
    }
}
